namespace AtmSystem
{
    partial class CardsForm
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
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            btnFind = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            grid = new System.Windows.Forms.DataGridView();
            lblAccount = new System.Windows.Forms.Label();
            cbAccount = new System.Windows.Forms.ComboBox();
            lblCardNumber = new System.Windows.Forms.Label();
            txtNumber = new System.Windows.Forms.TextBox();
            lblExpiry = new System.Windows.Forms.Label();
            txtExpiry = new System.Windows.Forms.TextBox();
            lblPin = new System.Windows.Forms.Label();
            txtPin = new System.Windows.Forms.TextBox();
            lblStatus = new System.Windows.Forms.Label();
            cbStatus = new System.Windows.Forms.ComboBox();
            btnAdd = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            lblViewOnly = new System.Windows.Forms.Label();
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
            lblTitle.Size = new System.Drawing.Size(225, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Справочник карт";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(15, 74);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(58, 23);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Поиск";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(79, 68);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(260, 30);
            txtSearch.TabIndex = 2;
            // 
            // btnFind
            // 
            btnFind.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFind.FlatAppearance.BorderSize = 0;
            btnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFind.ForeColor = System.Drawing.Color.White;
            btnFind.Location = new System.Drawing.Point(355, 68);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(80, 32);
            btnFind.TabIndex = 3;
            btnFind.Text = "Найти";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = System.Drawing.Color.White;
            btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReset.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnReset.Location = new System.Drawing.Point(441, 68);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(100, 32);
            btnReset.TabIndex = 4;
            btnReset.Text = "Сбросить";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
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
            grid.Location = new System.Drawing.Point(15, 106);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.RowTemplate.Height = 28;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new System.Drawing.Size(939, 490);
            grid.TabIndex = 5;
            grid.SelectionChanged += grid_SelectionChanged;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new System.Drawing.Point(968, 103);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new System.Drawing.Size(47, 23);
            lblAccount.TabIndex = 6;
            lblAccount.Text = "Счет";
            // 
            // cbAccount
            // 
            cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAccount.FormattingEnabled = true;
            cbAccount.Location = new System.Drawing.Point(968, 129);
            cbAccount.Name = "cbAccount";
            cbAccount.Size = new System.Drawing.Size(340, 31);
            cbAccount.TabIndex = 7;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.Location = new System.Drawing.Point(968, 173);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new System.Drawing.Size(194, 23);
            lblCardNumber.TabIndex = 8;
            lblCardNumber.Text = "Номер карты (16 цифр)";
            // 
            // txtNumber
            // 
            txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNumber.Location = new System.Drawing.Point(968, 199);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new System.Drawing.Size(340, 30);
            txtNumber.TabIndex = 9;
            // 
            // lblExpiry
            // 
            lblExpiry.AutoSize = true;
            lblExpiry.Location = new System.Drawing.Point(968, 238);
            lblExpiry.Name = "lblExpiry";
            lblExpiry.Size = new System.Drawing.Size(193, 23);
            lblExpiry.TabIndex = 10;
            lblExpiry.Text = "Срок действия (ММ/ГГ)";
            // 
            // txtExpiry
            // 
            txtExpiry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtExpiry.Location = new System.Drawing.Point(969, 264);
            txtExpiry.Name = "txtExpiry";
            txtExpiry.Size = new System.Drawing.Size(150, 30);
            txtExpiry.TabIndex = 11;
            // 
            // lblPin
            // 
            lblPin.AutoSize = true;
            lblPin.Location = new System.Drawing.Point(968, 304);
            lblPin.Name = "lblPin";
            lblPin.Size = new System.Drawing.Size(76, 23);
            lblPin.TabIndex = 12;
            lblPin.Text = "Пин-код";
            lblPin.Click += lblPin_Click;
            // 
            // txtPin
            // 
            txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPin.Location = new System.Drawing.Point(968, 330);
            txtPin.Name = "txtPin";
            txtPin.Size = new System.Drawing.Size(150, 30);
            txtPin.TabIndex = 13;
            txtPin.UseSystemPasswordChar = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(968, 369);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(94, 23);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Состояние";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Активна", "Заблокирована" });
            cbStatus.Location = new System.Drawing.Point(969, 395);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new System.Drawing.Size(150, 31);
            cbStatus.TabIndex = 15;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(968, 446);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(165, 32);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(1143, 446);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(165, 32);
            btnSave.TabIndex = 17;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(169, 50, 38);
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(968, 484);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(165, 32);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.White;
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnClear.Location = new System.Drawing.Point(1143, 484);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(165, 32);
            btnClear.TabIndex = 19;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblViewOnly
            // 
            lblViewOnly.AutoSize = true;
            lblViewOnly.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            lblViewOnly.Location = new System.Drawing.Point(900, 539);
            lblViewOnly.Name = "lblViewOnly";
            lblViewOnly.Size = new System.Drawing.Size(390, 23);
            lblViewOnly.TabIndex = 20;
            lblViewOnly.Text = "Только просмотр (нужна роль администратора)";
            lblViewOnly.Visible = false;
            // 
            // CardsForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(1320, 616);
            Controls.Add(pnlHeader);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnFind);
            Controls.Add(btnReset);
            Controls.Add(grid);
            Controls.Add(lblAccount);
            Controls.Add(cbAccount);
            Controls.Add(lblCardNumber);
            Controls.Add(txtNumber);
            Controls.Add(lblExpiry);
            Controls.Add(txtExpiry);
            Controls.Add(lblPin);
            Controls.Add(txtPin);
            Controls.Add(lblStatus);
            Controls.Add(cbStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(lblViewOnly);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            Name = "CardsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Справочник карт";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblViewOnly;
    }
}
