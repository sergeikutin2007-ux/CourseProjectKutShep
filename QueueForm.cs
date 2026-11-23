using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class QueueForm : Form
    {
        public QueueForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);

            cbAtm.Items.Add("Все банкоматы");
            foreach (Atm a in AtmRepo.GetAll()) cbAtm.Items.Add(a);
            cbAtm.SelectedIndex = 0;

            SetValue(numDays, Config.PeriodDays);
            SetValue(numService, Config.ServiceSeconds);
            SetValue(numTarget, Config.TargetWaitMinutes);

            btnCalc_Click(null, EventArgs.Empty);
        }

        static void SetValue(NumericUpDown n, decimal v)
        {
            n.Value = Math.Max(n.Minimum, Math.Min(n.Maximum, v));
        }

        void btnCalc_Click(object sender, EventArgs e)
        {
            Atm atm = cbAtm.SelectedItem as Atm;
            int atmId = atm == null ? 0 : atm.Id;
            int days = (int)numDays.Value;

            PeriodStats st = Stats.ForPeriod(atmId, days);
            if (st.TotalOps == 0 || st.PeakLambda <= 0)
            {
                lblInfo.Text = "За выбранный период операций нет, считать не по чему.";
                grid.DataSource = null;
                chartHours.Values = new double[0];
                chartWait.Values = new double[0];
                chartHours.Invalidate();
                chartWait.Invalidate();
                return;
            }

            double mu = 3600.0 / (double)numService.Value;
            double lambda = st.PeakLambda;
            double target = (double)numTarget.Value;
            var table = new List<QueueRow>();
            int best = Queueing.FindMin(lambda, mu, target, 50, table);

            string text = "Операций за период: " + st.TotalOps + ". В среднем за день: " + st.AvgPerDay.ToString("0.0") +
                          ", медиана: " + st.Median.ToString("0.0") + ", дисперсия: " + st.Variance.ToString("0.0") + "." + Environment.NewLine +
                          "Час пик: с " + st.PeakHour + ":00 до " + (st.PeakHour + 1) + ":00, интенсивность потока λ = " + lambda.ToString("0.00") + " оп/час." + Environment.NewLine +
                          "Скорость обслуживания одного банкомата μ = " + mu.ToString("0.00") + " оп/час." + Environment.NewLine;
            if (best > 0)
                text += "Нужно банкоматов: " + best + ". При таком числе среднее ожидание в очереди не больше " + target.ToString("0.0") + " мин.";
            else
                text += "В пределах 50 банкоматов заданное ожидание не достигается.";
            lblInfo.Text = text;

            grid.DataSource = table;
            Ui.Header(grid, "Servers", "Банкоматов");
            Ui.Header(grid, "Utilization", "Загрузка ρ");
            Ui.Header(grid, "WaitProbability", "Вероятность ожидания");
            Ui.Header(grid, "AvgQueue", "Средняя очередь");
            Ui.Header(grid, "AvgWaitMin", "Ожидание, мин");
            foreach (string col in new string[] { "Utilization", "WaitProbability", "AvgQueue", "AvgWaitMin" })
                grid.Columns[col].DefaultCellStyle.Format = "0.000";
            Ui.Fit(grid);

            // график 1: средняя нагрузка по часам суток
            string[] hours = new string[24];
            for (int h = 0; h < 24; h++) hours[h] = h.ToString();
            chartHours.Title = "Операций в час (в среднем за день)";
            chartHours.XTitle = "час суток";
            chartHours.Bars = true;
            chartHours.Labels = hours;
            chartHours.Values = st.ByHour;
            chartHours.Highlight = st.PeakHour;
            chartHours.Threshold = double.NaN;
            chartHours.Invalidate();

            // график 2: ожидание в зависимости от числа банкоматов
            int upTo = best > 0 ? Math.Min(best + 3, 12) : 12;
            var labels = new List<string>();
            var vals = new List<double>();
            for (int c = 1; c <= upTo; c++)
            {
                QueueRow r = Queueing.Calc(lambda, mu, c);
                labels.Add(c.ToString());
                vals.Add(r.Utilization < 1 ? Math.Min(r.AvgWaitMin, target * 10) : double.NaN);
            }
            chartWait.Title = "Среднее ожидание в очереди, мин";
            chartWait.XTitle = "число банкоматов";
            chartWait.Bars = false;
            chartWait.Labels = labels.ToArray();
            chartWait.Values = vals.ToArray();
            chartWait.Highlight = best > 0 ? best - 1 : -1;
            chartWait.Threshold = target;
            chartWait.ThresholdText = "допустимое ожидание " + target.ToString("0.0") + " мин";
            chartWait.Invalidate();
        }
    }
}
