using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AtmSystem
{
    // простой график на GDI+: столбцы или линия, без внешних библиотек
    public class SimpleChart : Control
    {
        static readonly Color Navy = Color.FromArgb(31, 58, 95);
        static readonly Color Blue = Color.FromArgb(46, 111, 166);
        static readonly Color Orange = Color.FromArgb(230, 126, 34);
        static readonly Color Red = Color.FromArgb(192, 57, 43);
        static readonly Brush BlueBrush = new SolidBrush(Blue);
        static readonly Brush OrangeBrush = new SolidBrush(Orange);
        static readonly Brush NavyBrush = new SolidBrush(Navy);
        static readonly Brush RedBrush = new SolidBrush(Red);
        static readonly Brush GrayBrush = new SolidBrush(Color.FromArgb(108, 117, 125));

        public string Title = "";
        public string XTitle = "";
        public string[] Labels = new string[0];
        public double[] Values = new double[0];
        public bool Bars = true;
        public int Highlight = -1;
        public double Threshold = double.NaN;
        public string ThresholdText = "";

        public SimpleChart()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.White;
        }

        static bool Ok(double v)
        {
            return !double.IsNaN(v) && !double.IsInfinity(v);
        }

        static double NiceMax(double v)
        {
            if (v <= 0) return 1;
            double p = Math.Pow(10, Math.Floor(Math.Log10(v)));
            double f = v / p;
            double n = f <= 1 ? 1 : (f <= 2 ? 2 : (f <= 5 ? 5 : 10));
            return n * p;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(BackColor);

            using (var border = new Pen(Color.FromArgb(190, 200, 215)))
                g.DrawRectangle(border, 0, 0, Width - 1, Height - 1);
            using (var bold = new Font(Font, FontStyle.Bold))
                g.DrawString(Title, bold, NavyBrush, 8, 6);

            int n = Values.Length;
            float left = 58, top = 34, right = 14, bottom = 42;
            float w = Width - left - right;
            float h = Height - top - bottom;
            if (n == 0 || w < 20 || h < 20)
            {
                g.DrawString("Нет данных", Font, GrayBrush, left, top + 10);
                return;
            }

            double max = 0;
            foreach (double v in Values) if (Ok(v) && v > max) max = v;
            if (Ok(Threshold) && Threshold > max) max = Threshold;
            max = NiceMax(max * 1.05);

            using (var grid = new Pen(Color.Gainsboro))
            {
                for (int i = 0; i <= 4; i++)
                {
                    float y = top + h - h * i / 4f;
                    g.DrawLine(grid, left, y, left + w, y);
                    string t = (max * i / 4).ToString("0.##");
                    SizeF sz = g.MeasureString(t, Font);
                    g.DrawString(t, Font, GrayBrush, left - sz.Width - 2, y - sz.Height / 2);
                }
            }
            g.DrawLine(Pens.Gray, left, top, left, top + h);
            g.DrawLine(Pens.Gray, left, top + h, left + w, top + h);

            float slot = w / n;
            int step = Math.Max(1, (int)Math.Ceiling(n * 26.0 / w));
            for (int i = 0; i < n; i++)
            {
                if (i % step != 0 || i >= Labels.Length) continue;
                SizeF sz = g.MeasureString(Labels[i], Font);
                g.DrawString(Labels[i], Font, GrayBrush, left + slot * i + slot / 2 - sz.Width / 2, top + h + 3);
            }
            if (XTitle.Length > 0)
            {
                SizeF sz = g.MeasureString(XTitle, Font);
                g.DrawString(XTitle, Font, GrayBrush, left + w / 2 - sz.Width / 2, top + h + 22);
            }

            if (Bars)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!Ok(Values[i])) continue;
                    float bh = (float)(Values[i] / max) * h;
                    float bw = slot * 0.7f;
                    float x = left + slot * i + (slot - bw) / 2;
                    Brush b = i == Highlight ? OrangeBrush : BlueBrush;
                    g.FillRectangle(b, x, top + h - bh, bw, bh);
                }
            }
            else
            {
                using (var pen = new Pen(Blue, 2f))
                {
                    PointF prev = PointF.Empty;
                    bool hasPrev = false;
                    for (int i = 0; i < n; i++)
                    {
                        if (!Ok(Values[i])) { hasPrev = false; continue; }
                        PointF p = new PointF(left + slot * i + slot / 2, top + h - (float)(Math.Min(Values[i], max) / max) * h);
                        if (hasPrev) g.DrawLine(pen, prev, p);
                        g.FillEllipse(i == Highlight ? OrangeBrush : BlueBrush, p.X - 4, p.Y - 4, 8, 8);
                        prev = p;
                        hasPrev = true;
                    }
                }
            }

            if (Ok(Threshold))
            {
                float y = top + h - (float)(Threshold / max) * h;
                using (var dash = new Pen(Red, 1.5f))
                {
                    dash.DashStyle = DashStyle.Dash;
                    g.DrawLine(dash, left, y, left + w, y);
                }
                if (ThresholdText.Length > 0)
                    g.DrawString(ThresholdText, Font, RedBrush, left + 6, y - 18);
            }
        }
    }
}
