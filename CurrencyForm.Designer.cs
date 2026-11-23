namespace AtmSystem
{
    partial class CurrencyForm
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
            lblStatus = new System.Windows.Forms.Label();
            btnRefresh = new System.Windows.Forms.Button();
            grid = new System.Windows.Forms.DataGridView();
            lblSum = new System.Windows.Forms.Label();
            txtSum = new System.Windows.Forms.TextBox();
            lblIn = new System.Windows.Forms.Label();
            cbCurrency = new System.Windows.Forms.ComboBox();
            btnConvert = new System.Windows.Forms.Button();
            lblResult = new System.Windows.Forms.Label();
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
            pnlHeader.Size = new System.Drawing.Size(640, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(173, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Курсы валют";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(20, 70);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(90, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Загрузка...";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(500, 64);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(120, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            grid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
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
            grid.Location = new System.Drawing.Point(20, 108);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.RowTemplate.Height = 28;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new System.Drawing.Size(600, 280);
            grid.TabIndex = 3;
            // 
            // lblSum
            // 
            lblSum.AutoSize = true;
            lblSum.Location = new System.Drawing.Point(20, 410);
            lblSum.Name = "lblSum";
            lblSum.Size = new System.Drawing.Size(103, 23);
            lblSum.TabIndex = 4;
            lblSum.Text = "Сумма, руб.";
            // 
            // txtSum
            // 
            txtSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSum.Location = new System.Drawing.Point(125, 405);
            txtSum.Name = "txtSum";
            txtSum.Size = new System.Drawing.Size(130, 30);
            txtSum.TabIndex = 5;
            txtSum.Text = "10000";
            // 
            // lblIn
            // 
            lblIn.AutoSize = true;
            lblIn.Location = new System.Drawing.Point(261, 410);
            lblIn.Name = "lblIn";
            lblIn.Size = new System.Drawing.Size(81, 23);
            lblIn.TabIndex = 6;
            lblIn.Text = "в валюте";
            // 
            // cbCurrency
            // 
            cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCurrency.FormattingEnabled = true;
            cbCurrency.Location = new System.Drawing.Point(345, 405);
            cbCurrency.Name = "cbCurrency";
            cbCurrency.Size = new System.Drawing.Size(120, 31);
            cbCurrency.TabIndex = 7;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConvert.ForeColor = System.Drawing.Color.White;
            btnConvert.Location = new System.Drawing.Point(480, 403);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(140, 32);
            btnConvert.TabIndex = 8;
            btnConvert.Text = "Пересчитать";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblResult.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            lblResult.Location = new System.Drawing.Point(20, 450);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(0, 25);
            lblResult.TabIndex = 9;
            // 
            // CurrencyForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(640, 500);
            Controls.Add(pnlHeader);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);
            Controls.Add(grid);
            Controls.Add(lblSum);
            Controls.Add(txtSum);
            Controls.Add(lblIn);
            Controls.Add(cbCurrency);
            Controls.Add(btnConvert);
            Controls.Add(lblResult);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CurrencyForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Курсы валют";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblResult;
    }
}
