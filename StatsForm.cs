using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);

            cbAtm.Items.Add("Все банкоматы");
            foreach (Atm a in AtmRepo.GetAll()) cbAtm.Items.Add(a);
            cbAtm.SelectedIndex = 0;
            numDays.Value = Math.Min(numDays.Maximum, Math.Max(numDays.Minimum, Config.PeriodDays));
            Calc();
        }

        void btnCalc_Click(object sender, EventArgs e)
        {
            Calc();
        }

        void Calc()
        {
            Atm atm = cbAtm.SelectedItem as Atm;
            int days = (int)numDays.Value;
            PeriodStats st = Stats.ForPeriod(atm == null ? 0 : atm.Id, days);

            if (st.TotalOps == 0)
            {
                lblResult.Text = "За выбранный период операций нет.";
                chartDays.Values = new double[0];
                chartDays.Invalidate();
                return;
            }

            lblResult.Text =
                "Период: " + days + " дн.\n" +
                "Всего операций: " + st.TotalOps + "\n\n" +
                "Среднее число операций в день: " + st.AvgPerDay.ToString("0.00") + "\n" +
                "Дисперсия: " + st.Variance.ToString("0.00") + "\n" +
                "Среднее квадратичное отклонение: " + st.StdDev.ToString("0.00") + "\n" +
                "Медиана: " + st.Median.ToString("0.0") + "\n\n" +
                "Час пик: " + st.PeakHour + ":00, " + st.PeakLambda.ToString("0.0") + " операций в час";

            string[] labels = new string[st.PerDay.Length];
            for (int i = 0; i < labels.Length; i++)
                labels[i] = DateTime.Today.AddDays(-days + i).ToString("dd.MM");
            chartDays.Title = "Операций по дням";
            chartDays.XTitle = "дата";
            chartDays.Bars = true;
            chartDays.Labels = labels;
            chartDays.Values = st.PerDay;
            chartDays.Highlight = -1;
            chartDays.Threshold = st.AvgPerDay;
            chartDays.ThresholdText = "среднее " + st.AvgPerDay.ToString("0.0");
            chartDays.Invalidate();
        }
    }
}
