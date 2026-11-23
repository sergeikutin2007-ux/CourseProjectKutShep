namespace AtmSystem
{
    partial class TerminalForm
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
            pnlLogin = new System.Windows.Forms.Panel();
            lblAtm = new System.Windows.Forms.Label();
            cbAtm = new System.Windows.Forms.ComboBox();
            lblCardNumber = new System.Windows.Forms.Label();
            txtCard = new System.Windows.Forms.TextBox();
            lblPin = new System.Windows.Forms.Label();
            txtPin = new System.Windows.Forms.TextBox();
            btnEnter = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            pnlMenu = new System.Windows.Forms.Panel();
            lblOwner = new System.Windows.Forms.Label();
            lblCardMask = new System.Windows.Forms.Label();
            btnBalance = new System.Windows.Forms.Button();
            btnStatement = new System.Windows.Forms.Button();
            btnChangePin = new System.Windows.Forms.Button();
            lblAmount = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            btnWithdraw = new System.Windows.Forms.Button();
            btnDeposit = new System.Windows.Forms.Button();
            txtReceipt = new System.Windows.Forms.TextBox();
            btnEject = new System.Windows.Forms.Button();
            pnlHeader.SuspendLayout();
            pnlLogin.SuspendLayout();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(480, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(271, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Терминал банкомата";
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(lblAtm);
            pnlLogin.Controls.Add(cbAtm);
            pnlLogin.Controls.Add(lblCardNumber);
            pnlLogin.Controls.Add(txtCard);
            pnlLogin.Controls.Add(lblPin);
            pnlLogin.Controls.Add(txtPin);
            pnlLogin.Controls.Add(btnEnter);
            pnlLogin.Controls.Add(btnClose);
            pnlLogin.Location = new System.Drawing.Point(0, 56);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new System.Drawing.Size(480, 540);
            pnlLogin.TabIndex = 1;
            // 
            // lblAtm
            // 
            lblAtm.AutoSize = true;
            lblAtm.Location = new System.Drawing.Point(20, 25);
            lblAtm.Name = "lblAtm";
            lblAtm.Size = new System.Drawing.Size(85, 23);
            lblAtm.TabIndex = 0;
            lblAtm.Text = "Банкомат";
            // 
            // cbAtm
            // 
            cbAtm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAtm.FormattingEnabled = true;
            cbAtm.Location = new System.Drawing.Point(140, 20);
            cbAtm.Name = "cbAtm";
            cbAtm.Size = new System.Drawing.Size(310, 31);
            cbAtm.TabIndex = 1;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.Location = new System.Drawing.Point(20, 70);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new System.Drawing.Size(114, 23);
            lblCardNumber.TabIndex = 2;
            lblCardNumber.Text = "Номер карты";
            // 
            // txtCard
            // 
            txtCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCard.Location = new System.Drawing.Point(140, 65);
            txtCard.MaxLength = 16;
            txtCard.Name = "txtCard";
            txtCard.Size = new System.Drawing.Size(310, 30);
            txtCard.TabIndex = 3;
            // 
            // lblPin
            // 
            lblPin.AutoSize = true;
            lblPin.Location = new System.Drawing.Point(20, 115);
            lblPin.Name = "lblPin";
            lblPin.Size = new System.Drawing.Size(76, 23);
            lblPin.TabIndex = 4;
            lblPin.Text = "Пин-код";
            // 
            // txtPin
            // 
            txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPin.Location = new System.Drawing.Point(140, 110);
            txtPin.MaxLength = 4;
            txtPin.Name = "txtPin";
            txtPin.Size = new System.Drawing.Size(120, 30);
            txtPin.TabIndex = 5;
            txtPin.UseSystemPasswordChar = true;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEnter.FlatAppearance.BorderSize = 0;
            btnEnter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEnter.ForeColor = System.Drawing.Color.White;
            btnEnter.Location = new System.Drawing.Point(140, 160);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(150, 32);
            btnEnter.TabIndex = 6;
            btnEnter.Text = "Вставить карту";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += btnEnter_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.White;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnClose.Location = new System.Drawing.Point(300, 160);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(150, 32);
            btnClose.TabIndex = 7;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(lblOwner);
            pnlMenu.Controls.Add(lblCardMask);
            pnlMenu.Controls.Add(btnBalance);
            pnlMenu.Controls.Add(btnStatement);
            pnlMenu.Controls.Add(btnChangePin);
            pnlMenu.Controls.Add(lblAmount);
            pnlMenu.Controls.Add(txtAmount);
            pnlMenu.Controls.Add(btnWithdraw);
            pnlMenu.Controls.Add(btnDeposit);
            pnlMenu.Controls.Add(txtReceipt);
            pnlMenu.Controls.Add(btnEject);
            pnlMenu.Location = new System.Drawing.Point(0, 56);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new System.Drawing.Size(480, 540);
            pnlMenu.TabIndex = 2;
            // 
            // lblOwner
            // 
            lblOwner.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblOwner.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            lblOwner.Location = new System.Drawing.Point(20, 15);
            lblOwner.Name = "lblOwner";
            lblOwner.Size = new System.Drawing.Size(440, 26);
            lblOwner.TabIndex = 0;
            lblOwner.Text = "Владелец";
            // 
            // lblCardMask
            // 
            lblCardMask.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            lblCardMask.Location = new System.Drawing.Point(20, 43);
            lblCardMask.Name = "lblCardMask";
            lblCardMask.Size = new System.Drawing.Size(440, 22);
            lblCardMask.TabIndex = 1;
            lblCardMask.Text = "Карта";
            // 
            // btnBalance
            // 
            btnBalance.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBalance.FlatAppearance.BorderSize = 0;
            btnBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBalance.ForeColor = System.Drawing.Color.White;
            btnBalance.Location = new System.Drawing.Point(20, 80);
            btnBalance.Name = "btnBalance";
            btnBalance.Size = new System.Drawing.Size(140, 32);
            btnBalance.TabIndex = 2;
            btnBalance.Text = "Баланс";
            btnBalance.UseVisualStyleBackColor = false;
            btnBalance.Click += btnBalance_Click;
            // 
            // btnStatement
            // 
            btnStatement.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnStatement.Cursor = System.Windows.Forms.Cursors.Hand;
            btnStatement.FlatAppearance.BorderSize = 0;
            btnStatement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnStatement.ForeColor = System.Drawing.Color.White;
            btnStatement.Location = new System.Drawing.Point(170, 80);
            btnStatement.Name = "btnStatement";
            btnStatement.Size = new System.Drawing.Size(140, 32);
            btnStatement.TabIndex = 3;
            btnStatement.Text = "Выписка";
            btnStatement.UseVisualStyleBackColor = false;
            btnStatement.Click += btnStatement_Click;
            // 
            // btnChangePin
            // 
            btnChangePin.BackColor = System.Drawing.Color.White;
            btnChangePin.Cursor = System.Windows.Forms.Cursors.Hand;
            btnChangePin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnChangePin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnChangePin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangePin.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnChangePin.Location = new System.Drawing.Point(320, 80);
            btnChangePin.Name = "btnChangePin";
            btnChangePin.Size = new System.Drawing.Size(140, 32);
            btnChangePin.TabIndex = 4;
            btnChangePin.Text = "Сменить пин";
            btnChangePin.UseVisualStyleBackColor = false;
            btnChangePin.Click += btnChangePin_Click;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new System.Drawing.Point(20, 133);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(103, 23);
            lblAmount.TabIndex = 5;
            lblAmount.Text = "Сумма, руб.";
            // 
            // txtAmount
            // 
            txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAmount.Location = new System.Drawing.Point(120, 127);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new System.Drawing.Size(160, 30);
            txtAmount.TabIndex = 6;
            // 
            // btnWithdraw
            // 
            btnWithdraw.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnWithdraw.Cursor = System.Windows.Forms.Cursors.Hand;
            btnWithdraw.FlatAppearance.BorderSize = 0;
            btnWithdraw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnWithdraw.ForeColor = System.Drawing.Color.White;
            btnWithdraw.Location = new System.Drawing.Point(20, 170);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new System.Drawing.Size(140, 32);
            btnWithdraw.TabIndex = 7;
            btnWithdraw.Text = "Снять";
            btnWithdraw.UseVisualStyleBackColor = false;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnDeposit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDeposit.FlatAppearance.BorderSize = 0;
            btnDeposit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeposit.ForeColor = System.Drawing.Color.White;
            btnDeposit.Location = new System.Drawing.Point(170, 170);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new System.Drawing.Size(140, 32);
            btnDeposit.TabIndex = 8;
            btnDeposit.Text = "Внести";
            btnDeposit.UseVisualStyleBackColor = false;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // txtReceipt
            // 
            txtReceipt.BackColor = System.Drawing.Color.White;
            txtReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtReceipt.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            txtReceipt.Location = new System.Drawing.Point(20, 220);
            txtReceipt.Multiline = true;
            txtReceipt.Name = "txtReceipt";
            txtReceipt.ReadOnly = true;
            txtReceipt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtReceipt.Size = new System.Drawing.Size(440, 240);
            txtReceipt.TabIndex = 9;
            // 
            // btnEject
            // 
            btnEject.BackColor = System.Drawing.Color.White;
            btnEject.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnEject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnEject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEject.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnEject.Location = new System.Drawing.Point(20, 475);
            btnEject.Name = "btnEject";
            btnEject.Size = new System.Drawing.Size(150, 32);
            btnEject.TabIndex = 10;
            btnEject.Text = "Забрать карту";
            btnEject.UseVisualStyleBackColor = false;
            btnEject.Click += btnEject_Click;
            // 
            // TerminalForm
            // 
            AcceptButton = btnEnter;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(480, 280);
            Controls.Add(pnlHeader);
            Controls.Add(pnlLogin);
            Controls.Add(pnlMenu);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TerminalForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Терминал банкомата";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblAtm;
        private System.Windows.Forms.ComboBox cbAtm;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblCardMask;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Button btnStatement;
        private System.Windows.Forms.Button btnChangePin;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Button btnEject;
    }
}
