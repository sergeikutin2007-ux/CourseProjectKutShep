namespace AtmSystem
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblFrom = new System.Windows.Forms.Label();
            dtFrom = new System.Windows.Forms.DateTimePicker();
            lblTo = new System.Windows.Forms.Label();
            dtTo = new System.Windows.Forms.DateTimePicker();
            lblAccount = new System.Windows.Forms.Label();
            txtAccount = new System.Windows.Forms.TextBox();
            lblType = new System.Windows.Forms.Label();
            cbType = new System.Windows.Forms.ComboBox();
            lblResult = new System.Windows.Forms.Label();
            cbResult = new System.Windows.Forms.ComboBox();
            lblAtm = new System.Windows.Forms.Label();
            cbAtm = new System.Windows.Forms.ComboBox();
            btnShow = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            grid = new System.Windows.Forms.DataGridView();
            lblTotals = new System.Windows.Forms.Label();
            btnPdf = new System.Windows.Forms.Button();
            btnPrev = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            lblPage = new System.Windows.Forms.Label();
            pnlHeader.SuspendLayout();
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
            pnlHeader.Size = new System.Drawing.Size(1320, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(267, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Отчет по операциям";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new System.Drawing.Point(15, 74);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(21, 23);
            lblFrom.TabIndex = 1;
            lblFrom.Text = "С";
            // 
            // dtFrom
            // 
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtFrom.Location = new System.Drawing.Point(40, 68);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new System.Drawing.Size(120, 30);
            dtFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new System.Drawing.Point(166, 74);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(35, 23);
            lblTo.TabIndex = 3;
            lblTo.Text = "ПО";
            // 
            // dtTo
            // 
            dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtTo.Location = new System.Drawing.Point(205, 68);
            dtTo.Name = "dtTo";
            dtTo.Size = new System.Drawing.Size(120, 30);
            dtTo.TabIndex = 4;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new System.Drawing.Point(345, 74);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new System.Drawing.Size(47, 23);
            lblAccount.TabIndex = 5;
            lblAccount.Text = "Счет";
            // 
            // txtAccount
            // 
            txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAccount.Location = new System.Drawing.Point(395, 68);
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new System.Drawing.Size(190, 30);
            txtAccount.TabIndex = 6;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new System.Drawing.Point(591, 74);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(90, 23);
            lblType.TabIndex = 7;
            lblType.Text = "Операция";
            // 
            // cbType
            // 
            cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Items.AddRange(new object[] { "Все", "Снятие", "Внесение", "Баланс" });
            cbType.Location = new System.Drawing.Point(687, 67);
            cbType.Name = "cbType";
            cbType.Size = new System.Drawing.Size(110, 31);
            cbType.TabIndex = 8;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new System.Drawing.Point(805, 74);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(86, 23);
            lblResult.TabIndex = 9;
            lblResult.Text = "Результат";
            lblResult.Click += lblResult_Click;
            // 
            // cbResult
            // 
            cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbResult.FormattingEnabled = true;
            cbResult.Items.AddRange(new object[] { "Все", "Успешные", "Отказы" });
            cbResult.Location = new System.Drawing.Point(897, 68);
            cbResult.Name = "cbResult";
            cbResult.Size = new System.Drawing.Size(110, 31);
            cbResult.TabIndex = 10;
            // 
            // lblAtm
            // 
            lblAtm.AutoSize = true;
            lblAtm.Location = new System.Drawing.Point(15, 114);
            lblAtm.Name = "lblAtm";
            lblAtm.Size = new System.Drawing.Size(85, 23);
            lblAtm.TabIndex = 11;
            lblAtm.Text = "Банкомат";
            // 
            // cbAtm
            // 
            cbAtm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtm.FormattingEnabled = true;
            cbAtm.Location = new System.Drawing.Point(104, 108);
            cbAtm.Name = "cbAtm";
            cbAtm.Size = new System.Drawing.Size(380, 31);
            cbAtm.TabIndex = 12;
            cbAtm.SelectedIndexChanged += cbAtm_SelectedIndexChanged;
            // 
            // btnShow
            // 
            btnShow.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            btnShow.FlatAppearance.BorderSize = 0;
            btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnShow.ForeColor = System.Drawing.Color.White;
            btnShow.Location = new System.Drawing.Point(490, 106);
            btnShow.Name = "btnShow";
            btnShow.Size = new System.Drawing.Size(110, 32);
            btnShow.TabIndex = 13;
            btnShow.Text = "Показать";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.White;
            btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExport.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnExport.Location = new System.Drawing.Point(610, 106);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(150, 32);
            btnExport.TabIndex = 14;
            btnExport.Text = "Экспорт в Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            grid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            grid.DefaultCellStyle = dataGridViewCellStyle9;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = System.Drawing.Color.FromArgb(225, 230, 238);
            grid.Location = new System.Drawing.Point(15, 151);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.RowTemplate.Height = 28;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new System.Drawing.Size(1290, 490);
            grid.TabIndex = 15;
            // 
            // lblTotals
            // 
            lblTotals.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblTotals.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTotals.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            lblTotals.Location = new System.Drawing.Point(15, 654);
            lblTotals.Name = "lblTotals";
            lblTotals.Size = new System.Drawing.Size(980, 30);
            lblTotals.TabIndex = 16;
            lblTotals.Text = "Итоги";
            // 
            // btnPdf
            // 
            btnPdf.BackColor = System.Drawing.Color.White;
            btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPdf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPdf.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnPdf.Location = new System.Drawing.Point(770, 106);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new System.Drawing.Size(150, 32);
            btnPdf.TabIndex = 17;
            btnPdf.Text = "Экспорт в PDF";
            btnPdf.UseVisualStyleBackColor = false;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnPrev
            // 
            btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPrev.BackColor = System.Drawing.Color.White;
            btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrev.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnPrev.Location = new System.Drawing.Point(1010, 650);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new System.Drawing.Size(40, 30);
            btnPrev.TabIndex = 18;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnNext.BackColor = System.Drawing.Color.White;
            btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNext.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnNext.Location = new System.Drawing.Point(1200, 650);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(40, 30);
            btnNext.TabIndex = 20;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblPage
            // 
            lblPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblPage.Location = new System.Drawing.Point(1055, 650);
            lblPage.Name = "lblPage";
            lblPage.Size = new System.Drawing.Size(140, 30);
            lblPage.TabIndex = 19;
            lblPage.Text = "Стр. 1 из 1";
            lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(1320, 696);
            Controls.Add(pnlHeader);
            Controls.Add(lblFrom);
            Controls.Add(dtFrom);
            Controls.Add(lblTo);
            Controls.Add(dtTo);
            Controls.Add(lblAccount);
            Controls.Add(txtAccount);
            Controls.Add(lblType);
            Controls.Add(cbType);
            Controls.Add(lblResult);
            Controls.Add(cbResult);
            Controls.Add(lblAtm);
            Controls.Add(cbAtm);
            Controls.Add(btnShow);
            Controls.Add(btnExport);
            Controls.Add(grid);
            Controls.Add(lblTotals);
            Controls.Add(btnPdf);
            Controls.Add(btnPrev);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            Name = "ReportForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Отчет по операциям";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.Label lblAtm;
        private System.Windows.Forms.ComboBox cbAtm;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblTotals;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPage;
    }
}
