using System;
using System.Linq;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class CurrencyForm : Form
    {
        CurrencyResult current;

        public CurrencyForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
            Shown += async (s, e) => await Reload();
        }

        async System.Threading.Tasks.Task Reload()
        {
            btnRefresh.Enabled = false;
            lblStatus.Text = "Загрузка курсов...";
            CurrencyResult res = await CurrencyService.LoadAsync();
            if (IsDisposed) return;
            btnRefresh.Enabled = true;

            if (res.Rates.Count == 0)
            {
                lblStatus.Text = res.Message;
                grid.DataSource = null;
                return;
            }
            current = res;
            lblStatus.Text = res.FromCache ? res.Message : "Курсы ЦБ РФ на " + res.Date;

            grid.DataSource = res.Rates.Select(r => new
            {
                r.Code,
                r.Name,
                r.Nominal,
                Rate = r.Value
            }).ToList();
            Ui.Header(grid, "Code", "Код");
            Ui.Header(grid, "Name", "Валюта");
            Ui.Header(grid, "Nominal", "Номинал");
            Ui.Header(grid, "Rate", "Курс, руб.");
            grid.Columns["Rate"].DefaultCellStyle.Format = "N4";
            Ui.Fit(grid);

            string selected = cbCurrency.SelectedItem as string;
            cbCurrency.Items.Clear();
            foreach (CurrencyRate r in res.Rates) cbCurrency.Items.Add(r.Code);
            int idx = selected == null ? cbCurrency.Items.IndexOf("USD") : cbCurrency.Items.IndexOf(selected);
            cbCurrency.SelectedIndex = idx >= 0 ? idx : 0;
            btnConvert_Click(null, EventArgs.Empty);
        }

        async void btnRefresh_Click(object sender, EventArgs e)
        {
            await Reload();
        }

        void btnConvert_Click(object sender, EventArgs e)
        {
            if (current == null || cbCurrency.SelectedItem == null) return;
            decimal rub;
            if (!Validator.ParseMoney(txtSum.Text, out rub) || rub < 0)
            {
                lblResult.Text = "Введите сумму числом";
                return;
            }
            CurrencyRate rate = current.Rates.First(r => r.Code == (string)cbCurrency.SelectedItem);
            lblResult.Text = rub.ToString("N2") + " руб. = " + CurrencyService.FromRub(rub, rate).ToString("N2") + " " + rate.Code;
        }
    }
}
