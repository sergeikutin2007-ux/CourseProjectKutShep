using System;
using System.Drawing;
using System.Windows.Forms;

namespace AtmSystem
{
    public static class Ui
    {
        public static void Header(DataGridView g, string column, string text)
        {
            if (g.Columns[column] != null) g.Columns[column].HeaderText = text;
        }

        public static void Hide(DataGridView g, string column)
        {
            if (g.Columns[column] != null) g.Columns[column].Visible = false;
        }

        // колонки по ширине содержимого, последняя занимает остаток
        public static void Fit(DataGridView g)
        {
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewColumn last = null;
            foreach (DataGridViewColumn c in g.Columns)
                if (c.Visible) last = c;
            if (last != null) last.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static string Prompt(string title, string label, string initial)
        {
            using (var f = new InputForm(title, label, initial))
                return f.ShowDialog() == DialogResult.OK ? f.Value : null;
        }

        // отключенная кнопка серая, чтобы было видно, что действие недоступно
        public static void Disable(params Button[] buttons)
        {
            foreach (Button b in buttons)
            {
                b.Enabled = false;
                b.BackColor = Color.FromArgb(190, 198, 208);
                b.ForeColor = Color.White;
            }
        }

        static Icon appIcon;

        public static void SetIcon(Form f)
        {
            try
            {
                if (appIcon == null) appIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                if (appIcon != null) f.Icon = appIcon;
            }
            catch
            {
                // без иконки форма тоже работает
            }
        }

        public static void Info(string text)
        {
            MessageBox.Show(text, "Банкомат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Ask(string text)
        {
            return MessageBox.Show(text, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
