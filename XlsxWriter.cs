using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Security;
using System.Text;

namespace AtmSystem
{
    // минимальная запись xlsx без сторонних библиотек: xlsx это обычный zip с xml внутри
    public static class XlsxWriter
    {
        const string Main = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        const string Rel = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

        static string ColName(int i)
        {
            string s = "";
            i++;
            while (i > 0)
            {
                int m = (i - 1) % 26;
                s = (char)('A' + m) + s;
                i = (i - 1) / 26;
            }
            return s;
        }

        static void Entry(ZipArchive zip, string name, string content)
        {
            ZipArchiveEntry e = zip.CreateEntry(name);
            using (var w = new StreamWriter(e.Open(), new UTF8Encoding(false)))
                w.Write(content);
        }

        static string Cell(int col, int row, object v, int style)
        {
            string r = ColName(col) + row;
            if (v == null) return "<c r=\"" + r + "\"/>";
            if (v is decimal || v is double || v is int)
            {
                string num = Convert.ToDecimal(v).ToString(CultureInfo.InvariantCulture);
                if (style == 0 && !(v is int)) style = 2;
                return "<c r=\"" + r + "\" s=\"" + style + "\"><v>" + num + "</v></c>";
            }
            return "<c r=\"" + r + "\" t=\"inlineStr\" s=\"" + style + "\"><is><t xml:space=\"preserve\">" +
                   SecurityElement.Escape(v.ToString()) + "</t></is></c>";
        }

        public static void Write(string path, string sheetName, string[] headers, List<object[]> rows, List<object[]> footer)
        {
            int cols = headers.Length;
            int[] width = new int[cols];
            for (int i = 0; i < cols; i++) width[i] = headers[i].Length + 2;
            foreach (object[] row in rows)
                for (int i = 0; i < cols && i < row.Length; i++)
                {
                    int len = row[i] == null ? 0 : row[i].ToString().Length + 2;
                    if (len > width[i]) width[i] = Math.Min(len, 60);
                }

            var sheet = new StringBuilder();
            sheet.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sheet.Append("<worksheet xmlns=\"" + Main + "\">");
            sheet.Append("<sheetViews><sheetView workbookViewId=\"0\"><pane ySplit=\"1\" topLeftCell=\"A2\" activePane=\"bottomLeft\" state=\"frozen\"/></sheetView></sheetViews>");
            sheet.Append("<cols>");
            for (int i = 0; i < cols; i++)
                sheet.Append("<col min=\"" + (i + 1) + "\" max=\"" + (i + 1) + "\" width=\"" + Math.Max(width[i], 8) + "\" customWidth=\"1\"/>");
            sheet.Append("</cols><sheetData>");

            int rowNo = 1;
            sheet.Append("<row r=\"1\">");
            for (int i = 0; i < cols; i++) sheet.Append(Cell(i, 1, headers[i], 1));
            sheet.Append("</row>");

            foreach (object[] row in rows)
            {
                rowNo++;
                sheet.Append("<row r=\"" + rowNo + "\">");
                for (int i = 0; i < cols && i < row.Length; i++) sheet.Append(Cell(i, rowNo, row[i], 0));
                sheet.Append("</row>");
            }

            if (footer != null && footer.Count > 0)
            {
                rowNo++;
                foreach (object[] row in footer)
                {
                    rowNo++;
                    sheet.Append("<row r=\"" + rowNo + "\">");
                    for (int i = 0; i < row.Length; i++) sheet.Append(Cell(i, rowNo, row[i], i == 0 ? 3 : 0));
                    sheet.Append("</row>");
                }
            }
            sheet.Append("</sheetData></worksheet>");

            string styles =
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<styleSheet xmlns=\"" + Main + "\">" +
                "<fonts count=\"2\"><font><sz val=\"11\"/><name val=\"Calibri\"/></font><font><b/><sz val=\"11\"/><name val=\"Calibri\"/></font></fonts>" +
                "<fills count=\"3\"><fill><patternFill patternType=\"none\"/></fill><fill><patternFill patternType=\"gray125\"/></fill>" +
                "<fill><patternFill patternType=\"solid\"><fgColor rgb=\"FFD9E1F2\"/><bgColor indexed=\"64\"/></patternFill></fill></fills>" +
                "<borders count=\"1\"><border><left/><right/><top/><bottom/><diagonal/></border></borders>" +
                "<cellStyleXfs count=\"1\"><xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\"/></cellStyleXfs>" +
                "<cellXfs count=\"4\">" +
                "<xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\"/>" +
                "<xf numFmtId=\"0\" fontId=\"1\" fillId=\"2\" borderId=\"0\" xfId=\"0\" applyFont=\"1\" applyFill=\"1\"/>" +
                "<xf numFmtId=\"4\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyNumberFormat=\"1\"/>" +
                "<xf numFmtId=\"0\" fontId=\"1\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyFont=\"1\"/>" +
                "</cellXfs><cellStyles count=\"1\"><cellStyle name=\"Normal\" xfId=\"0\" builtinId=\"0\"/></cellStyles></styleSheet>";

            string workbook =
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<workbook xmlns=\"" + Main + "\" xmlns:r=\"" + Rel + "\"><sheets>" +
                "<sheet name=\"" + SecurityElement.Escape(sheetName) + "\" sheetId=\"1\" r:id=\"rId1\"/></sheets></workbook>";

            string workbookRels =
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                "<Relationship Id=\"rId1\" Type=\"" + Rel + "/worksheet\" Target=\"worksheets/sheet1.xml\"/>" +
                "<Relationship Id=\"rId2\" Type=\"" + Rel + "/styles\" Target=\"styles.xml\"/></Relationships>";

            string rootRels =
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                "<Relationship Id=\"rId1\" Type=\"" + Rel + "/officeDocument\" Target=\"xl/workbook.xml\"/></Relationships>";

            string types =
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">" +
                "<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\"/>" +
                "<Default Extension=\"xml\" ContentType=\"application/xml\"/>" +
                "<Override PartName=\"/xl/workbook.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml\"/>" +
                "<Override PartName=\"/xl/worksheets/sheet1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml\"/>" +
                "<Override PartName=\"/xl/styles.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml\"/></Types>";

            if (File.Exists(path)) File.Delete(path);
            using (var fs = new FileStream(path, FileMode.Create))
            using (var zip = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                Entry(zip, "[Content_Types].xml", types);
                Entry(zip, "_rels/.rels", rootRels);
                Entry(zip, "xl/workbook.xml", workbook);
                Entry(zip, "xl/_rels/workbook.xml.rels", workbookRels);
                Entry(zip, "xl/styles.xml", styles);
                Entry(zip, "xl/worksheets/sheet1.xml", sheet.ToString());
            }
        }
    }
}
