namespace AtmSystem
{
    partial class StatsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblAtm = new System.Windows.Forms.Label();
            cbAtm = new System.Windows.Forms.ComboBox();
            lblDays = new System.Windows.Forms.Label();
            numDays = new System.Windows.Forms.NumericUpDown();
            btnCalc = new System.Windows.Forms.Button();
            lblResult = new System.Windows.Forms.Label();
            chartDays = new SimpleChart();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDays).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(900, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(276, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Статистика операций";
            // 
            // lblAtm
            // 
            lblAtm.AutoSize = true;
            lblAtm.Location = new System.Drawing.Point(20, 74);
            lblAtm.Name = "lblAtm";
            lblAtm.Size = new System.Drawing.Size(85, 23);
            lblAtm.TabIndex = 1;
            lblAtm.Text = "Банкомат";
            // 
            // cbAtm
            // 
            cbAtm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtm.FormattingEnabled = true;
            cbAtm.Location = new System.Drawing.Point(114, 68);
            cbAtm.Name = "cbAtm";
            cbAtm.Size = new System.Drawing.Size(330, 31);
            cbAtm.TabIndex = 2;
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Location = new System.Drawing.Point(450, 74);
            lblDays.Name = "lblDays";
            lblDays.Size = new System.Drawing.Size(117, 23);
            lblDays.TabIndex = 3;
            lblDays.Text = "Период, дней";
            // 
            // numDays
            // 
            numDays.Location = new System.Drawing.Point(573, 68);
            numDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numDays.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numDays.Name = "numDays";
            numDays.Size = new System.Drawing.Size(70, 30);
            numDays.TabIndex = 4;
            numDays.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // btnCalc
            // 
            btnCalc.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnCalc.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCalc.FlatAppearance.BorderSize = 0;
            btnCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCalc.ForeColor = System.Drawing.Color.White;
            btnCalc.Location = new System.Drawing.Point(650, 66);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new System.Drawing.Size(120, 32);
            btnCalc.TabIndex = 5;
            btnCalc.Text = "Рассчитать";
            btnCalc.UseVisualStyleBackColor = false;
            btnCalc.Click += btnCalc_Click;
            // 
            // lblResult
            // 
            lblResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            lblResult.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblResult.Location = new System.Drawing.Point(20, 115);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(250, 340);
            lblResult.TabIndex = 6;
            // 
            // chartDays
            // 
            chartDays.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chartDays.BackColor = System.Drawing.Color.White;
            chartDays.Location = new System.Drawing.Point(290, 115);
            chartDays.Name = "chartDays";
            chartDays.Size = new System.Drawing.Size(590, 340);
            chartDays.TabIndex = 7;
            // 
            // StatsForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(900, 480);
            Controls.Add(pnlHeader);
            Controls.Add(lblAtm);
            Controls.Add(cbAtm);
            Controls.Add(lblDays);
            Controls.Add(numDays);
            Controls.Add(btnCalc);
            Controls.Add(lblResult);
            Controls.Add(chartDays);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            Name = "StatsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Статистика операций";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAtm;
        private System.Windows.Forms.ComboBox cbAtm;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label lblResult;
        private AtmSystem.SimpleChart chartDays;
    }
}
