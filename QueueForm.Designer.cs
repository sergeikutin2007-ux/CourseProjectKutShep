namespace AtmSystem
{
    partial class QueueForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblAtm = new System.Windows.Forms.Label();
            cbAtm = new System.Windows.Forms.ComboBox();
            lblDays = new System.Windows.Forms.Label();
            numDays = new System.Windows.Forms.NumericUpDown();
            lblService = new System.Windows.Forms.Label();
            numService = new System.Windows.Forms.NumericUpDown();
            lblTarget = new System.Windows.Forms.Label();
            numTarget = new System.Windows.Forms.NumericUpDown();
            btnCalc = new System.Windows.Forms.Button();
            lblInfo = new System.Windows.Forms.Label();
            grid = new System.Windows.Forms.DataGridView();
            chartHours = new SimpleChart();
            chartWait = new SimpleChart();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numService).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTarget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1200, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(503, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Расчет оптимального числа банкоматов";
            // 
            // lblAtm
            // 
            lblAtm.AutoSize = true;
            lblAtm.Location = new System.Drawing.Point(15, 74);
            lblAtm.Name = "lblAtm";
            lblAtm.Size = new System.Drawing.Size(144, 23);
            lblAtm.TabIndex = 1;
            lblAtm.Text = "Банкомат (точка)";
            // 
            // cbAtm
            // 
            cbAtm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtm.FormattingEnabled = true;
            cbAtm.Location = new System.Drawing.Point(165, 66);
            cbAtm.Name = "cbAtm";
            cbAtm.Size = new System.Drawing.Size(340, 31);
            cbAtm.TabIndex = 2;
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Location = new System.Drawing.Point(15, 114);
            lblDays.Name = "lblDays";
            lblDays.Size = new System.Drawing.Size(117, 23);
            lblDays.TabIndex = 3;
            lblDays.Text = "Период, дней";
            // 
            // numDays
            // 
            numDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numDays.Location = new System.Drawing.Point(138, 112);
            numDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDays.Name = "numDays";
            numDays.Size = new System.Drawing.Size(80, 30);
            numDays.TabIndex = 4;
            numDays.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new System.Drawing.Point(234, 114);
            lblService.Name = "lblService";
            lblService.Size = new System.Drawing.Size(285, 23);
            lblService.TabIndex = 5;
            lblService.Text = "Среднее время обслуживания, сек";
            // 
            // numService
            // 
            numService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numService.Location = new System.Drawing.Point(525, 112);
            numService.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            numService.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numService.Name = "numService";
            numService.Size = new System.Drawing.Size(80, 30);
            numService.TabIndex = 6;
            numService.Value = new decimal(new int[] { 90, 0, 0, 0 });
            // 
            // lblTarget
            // 
            lblTarget.AutoSize = true;
            lblTarget.Location = new System.Drawing.Point(15, 154);
            lblTarget.Name = "lblTarget";
            lblTarget.Size = new System.Drawing.Size(232, 23);
            lblTarget.TabIndex = 7;
            lblTarget.Text = "Допустимое ожидание, мин";
            // 
            // numTarget
            // 
            numTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numTarget.DecimalPlaces = 1;
            numTarget.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numTarget.Location = new System.Drawing.Point(253, 149);
            numTarget.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numTarget.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numTarget.Name = "numTarget";
            numTarget.Size = new System.Drawing.Size(80, 30);
            numTarget.TabIndex = 8;
            numTarget.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // btnCalc
            // 
            btnCalc.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnCalc.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCalc.FlatAppearance.BorderSize = 0;
            btnCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCalc.ForeColor = System.Drawing.Color.White;
            btnCalc.Location = new System.Drawing.Point(345, 147);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new System.Drawing.Size(140, 32);
            btnCalc.TabIndex = 9;
            btnCalc.Text = "Рассчитать";
            btnCalc.UseVisualStyleBackColor = false;
            btnCalc.Click += btnCalc_Click;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblInfo.Location = new System.Drawing.Point(15, 191);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new System.Drawing.Size(1160, 100);
            lblInfo.TabIndex = 10;
            lblInfo.Text = "Результат расчета";
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            grid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            grid.DefaultCellStyle = dataGridViewCellStyle3;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = System.Drawing.Color.FromArgb(225, 230, 238);
            grid.Location = new System.Drawing.Point(15, 301);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.RowTemplate.Height = 28;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new System.Drawing.Size(470, 440);
            grid.TabIndex = 11;
            // 
            // chartHours
            // 
            chartHours.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chartHours.BackColor = System.Drawing.Color.White;
            chartHours.Location = new System.Drawing.Point(500, 301);
            chartHours.Name = "chartHours";
            chartHours.Size = new System.Drawing.Size(675, 215);
            chartHours.TabIndex = 12;
            // 
            // chartWait
            // 
            chartWait.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chartWait.BackColor = System.Drawing.Color.White;
            chartWait.Location = new System.Drawing.Point(500, 526);
            chartWait.Name = "chartWait";
            chartWait.Size = new System.Drawing.Size(675, 215);
            chartWait.TabIndex = 13;
            // 
            // QueueForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(1200, 756);
            Controls.Add(pnlHeader);
            Controls.Add(lblAtm);
            Controls.Add(cbAtm);
            Controls.Add(lblDays);
            Controls.Add(numDays);
            Controls.Add(lblService);
            Controls.Add(numService);
            Controls.Add(lblTarget);
            Controls.Add(numTarget);
            Controls.Add(btnCalc);
            Controls.Add(lblInfo);
            Controls.Add(grid);
            Controls.Add(chartHours);
            Controls.Add(chartWait);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            MinimumSize = new System.Drawing.Size(1100, 706);
            Name = "QueueForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Расчет оптимального числа банкоматов";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)numService).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTarget).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
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
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.NumericUpDown numService;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.NumericUpDown numTarget;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView grid;
        private AtmSystem.SimpleChart chartHours;
        private AtmSystem.SimpleChart chartWait;
    }
}
