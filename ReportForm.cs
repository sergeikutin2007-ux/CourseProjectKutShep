using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class ReportForm : Form
    {
        List<OperationRow> rows = new List<OperationRow>();
        int page;
        int pageCount = 1;

        public ReportForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);

            dtFrom.Value = DateTime.Today.AddDays(-7);
            dtTo.Value = DateTime.Today;
            cbType.SelectedIndex = 0;
            cbResult.SelectedIndex = 0;

            cbAtm.Items.Add("Все");
            foreach (Atm a in AtmRepo.GetAll()) cbAtm.Items.Add(a);
            cbAtm.SelectedIndex = 0;

            Build();
        }

        void btnShow_Click(object sender, EventArgs e)
        {
            Build();
        }

        void Build()
        {
            if (dtFrom.Value.Date > dtTo.Value.Date)
            {
                Ui.Error("Дата начала позже даты окончания");
                return;
            }
            string type = ReportService.TypeDb((string)cbType.SelectedItem);
            int success = cbResult.SelectedIndex == 0 ? -1 : (cbResult.SelectedIndex == 1 ? 1 : 0);
            Atm atm = cbAtm.SelectedItem as Atm;
            rows = ReportService.Query(dtFrom.Value, dtTo.Value, txtAccount.Text, type, success, atm == null ? 0 : atm.Id);

            page = 0;
            ShowPage();

            decimal withdrawn = rows.Where(r => r.OpType == "Снятие" && r.Result == "Успешно").Sum(r => r.Amount);
            decimal deposited = rows.Where(r => r.OpType == "Внесение" && r.Result == "Успешно").Sum(r => r.Amount);
            int failed = rows.Count(r => r.Result == "Отказ");
            lblTotals.Text = "Операций: " + rows.Count + ".  Снято: " + withdrawn.ToString("N2") +
                             " руб.  Внесено: " + deposited.ToString("N2") + " руб.  Отказов: " + failed;
        }

        void ShowPage()
        {
            int size = Config.PageSize;
            pageCount = Math.Max(1, (rows.Count + size - 1) / size);
            if (page >= pageCount) page = pageCount - 1;
            if (page < 0) page = 0;
            grid.DataSource = rows.Skip(page * size).Take(size).ToList();
            Ui.Hide(grid, "Id");
            Ui.Header(grid, "OpTime", "Дата и время");
            Ui.Header(grid, "AtmAddress", "Банкомат");
            Ui.Header(grid, "CardNumber", "Карта");
            Ui.Header(grid, "AccountNumber", "Счет");
            Ui.Header(grid, "OpType", "Операция");
            Ui.Header(grid, "Amount", "Сумма");
            Ui.Header(grid, "Result", "Результат");
            Ui.Header(grid, "Reason", "Причина отказа");
            grid.Columns["Amount"].DefaultCellStyle.Format = "N2";
            Ui.Fit(grid);
            lblPage.Text = "Стр. " + (page + 1) + " из " + pageCount;
            btnPrev.Enabled = page > 0;
            btnNext.Enabled = page < pageCount - 1;
        }

        void btnPrev_Click(object sender, EventArgs e)
        {
            page--;
            ShowPage();
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            ShowPage();
        }

        void btnPdf_Click(object sender, EventArgs e)
        {
            if (rows.Count == 0) { Ui.Error("Нет данных для выгрузки"); return; }
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF (*.pdf)|*.pdf";
                dlg.FileName = "operations_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
                if (dlg.ShowDialog() != DialogResult.OK) return;
                try
                {
                    ReportService.ExportPdf(dlg.FileName, rows);
                    Log.Write("INFO", "Отчет выгружен в " + dlg.FileName);
                    Ui.Info("Файл сохранен");
                }
                catch (Exception ex)
                {
                    Log.Write("ERROR", "Ошибка выгрузки в PDF: " + ex.Message);
                    Ui.Error("Не удалось сохранить PDF: " + ex.Message);
                }
            }
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            if (rows.Count == 0) { Ui.Error("Нет данных для выгрузки"); return; }
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Книга Excel (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv";
                dlg.FileName = "operations_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
                if (dlg.ShowDialog() != DialogResult.OK) return;
                try
                {
                    if (dlg.FilterIndex == 1) ReportService.ExportXlsx(dlg.FileName, rows);
                    else ReportService.ExportCsv(dlg.FileName, rows);
                    Log.Write("INFO", "Отчет выгружен в " + dlg.FileName);
                    Ui.Info("Файл сохранен");
                }
                catch (Exception ex)
                {
                    Log.Write("ERROR", "Ошибка выгрузки: " + ex.Message);
                    Ui.Error("Не удалось сохранить файл: " + ex.Message);
                }
            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void cbAtm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
