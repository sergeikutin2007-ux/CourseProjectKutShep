namespace AtmSystem
{
    partial class MainForm
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
            lblUser = new System.Windows.Forms.Label();
            btnAccounts = new System.Windows.Forms.Button();
            btnCards = new System.Windows.Forms.Button();
            btnAtms = new System.Windows.Forms.Button();
            btnTerminal = new System.Windows.Forms.Button();
            btnReport = new System.Windows.Forms.Button();
            btnQueue = new System.Windows.Forms.Button();
            btnStats = new System.Windows.Forms.Button();
            btnCurrency = new System.Windows.Forms.Button();
            btnBackup = new System.Windows.Forms.Button();
            btnLogout = new System.Windows.Forms.Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(420, 81);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(251, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Система банкомата";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.ForeColor = System.Drawing.Color.FromArgb(200, 215, 235);
            lblUser.Location = new System.Drawing.Point(18, 48);
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(120, 23);
            lblUser.TabIndex = 1;
            lblUser.Text = "Пользователь";
            // 
            // btnAccounts
            // 
            btnAccounts.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAccounts.FlatAppearance.BorderSize = 0;
            btnAccounts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAccounts.ForeColor = System.Drawing.Color.White;
            btnAccounts.Location = new System.Drawing.Point(20, 104);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Size = new System.Drawing.Size(380, 32);
            btnAccounts.TabIndex = 2;
            btnAccounts.Text = "Счета";
            btnAccounts.UseVisualStyleBackColor = false;
            btnAccounts.Click += btnAccounts_Click;
            // 
            // btnCards
            // 
            btnCards.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnCards.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCards.FlatAppearance.BorderSize = 0;
            btnCards.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCards.ForeColor = System.Drawing.Color.White;
            btnCards.Location = new System.Drawing.Point(20, 149);
            btnCards.Name = "btnCards";
            btnCards.Size = new System.Drawing.Size(380, 32);
            btnCards.TabIndex = 3;
            btnCards.Text = "Карты";
            btnCards.UseVisualStyleBackColor = false;
            btnCards.Click += btnCards_Click;
            // 
            // btnAtms
            // 
            btnAtms.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnAtms.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAtms.FlatAppearance.BorderSize = 0;
            btnAtms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnAtms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAtms.ForeColor = System.Drawing.Color.White;
            btnAtms.Location = new System.Drawing.Point(20, 194);
            btnAtms.Name = "btnAtms";
            btnAtms.Size = new System.Drawing.Size(380, 32);
            btnAtms.TabIndex = 4;
            btnAtms.Text = "Банкоматы";
            btnAtms.UseVisualStyleBackColor = false;
            btnAtms.Click += btnAtms_Click;
            // 
            // btnTerminal
            // 
            btnTerminal.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnTerminal.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTerminal.FlatAppearance.BorderSize = 0;
            btnTerminal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTerminal.ForeColor = System.Drawing.Color.White;
            btnTerminal.Location = new System.Drawing.Point(20, 239);
            btnTerminal.Name = "btnTerminal";
            btnTerminal.Size = new System.Drawing.Size(380, 32);
            btnTerminal.TabIndex = 5;
            btnTerminal.Text = "Терминал";
            btnTerminal.UseVisualStyleBackColor = false;
            btnTerminal.Click += btnTerminal_Click;
            // 
            // btnReport
            // 
            btnReport.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReport.ForeColor = System.Drawing.Color.White;
            btnReport.Location = new System.Drawing.Point(20, 284);
            btnReport.Name = "btnReport";
            btnReport.Size = new System.Drawing.Size(380, 32);
            btnReport.TabIndex = 6;
            btnReport.Text = "Отчет по операциям";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += btnReport_Click;
            // 
            // btnQueue
            // 
            btnQueue.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnQueue.Cursor = System.Windows.Forms.Cursors.Hand;
            btnQueue.FlatAppearance.BorderSize = 0;
            btnQueue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQueue.ForeColor = System.Drawing.Color.White;
            btnQueue.Location = new System.Drawing.Point(20, 329);
            btnQueue.Name = "btnQueue";
            btnQueue.Size = new System.Drawing.Size(380, 32);
            btnQueue.TabIndex = 7;
            btnQueue.Text = "Расчет числа банкоматов";
            btnQueue.UseVisualStyleBackColor = false;
            btnQueue.Click += btnQueue_Click;
            // 
            // btnStats
            // 
            btnStats.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnStats.Cursor = System.Windows.Forms.Cursors.Hand;
            btnStats.FlatAppearance.BorderSize = 0;
            btnStats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnStats.ForeColor = System.Drawing.Color.White;
            btnStats.Location = new System.Drawing.Point(20, 374);
            btnStats.Name = "btnStats";
            btnStats.Size = new System.Drawing.Size(380, 32);
            btnStats.TabIndex = 8;
            btnStats.Text = "Статистика операций";
            btnStats.UseVisualStyleBackColor = false;
            btnStats.Click += btnStats_Click;
            // 
            // btnCurrency
            // 
            btnCurrency.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnCurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCurrency.FlatAppearance.BorderSize = 0;
            btnCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCurrency.ForeColor = System.Drawing.Color.White;
            btnCurrency.Location = new System.Drawing.Point(20, 419);
            btnCurrency.Name = "btnCurrency";
            btnCurrency.Size = new System.Drawing.Size(380, 32);
            btnCurrency.TabIndex = 9;
            btnCurrency.Text = "Курсы валют";
            btnCurrency.UseVisualStyleBackColor = false;
            btnCurrency.Click += btnCurrency_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBackup.FlatAppearance.BorderSize = 0;
            btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackup.ForeColor = System.Drawing.Color.White;
            btnBackup.Location = new System.Drawing.Point(20, 464);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new System.Drawing.Size(380, 32);
            btnBackup.TabIndex = 10;
            btnBackup.Text = "Резервная копия базы";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = System.Drawing.Color.White;
            btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnLogout.Location = new System.Drawing.Point(20, 509);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(380, 32);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Сменить пользователя";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            ClientSize = new System.Drawing.Size(420, 555);
            Controls.Add(pnlHeader);
            Controls.Add(btnAccounts);
            Controls.Add(btnCards);
            Controls.Add(btnAtms);
            Controls.Add(btnTerminal);
            Controls.Add(btnReport);
            Controls.Add(btnQueue);
            Controls.Add(btnStats);
            Controls.Add(btnCurrency);
            Controls.Add(btnBackup);
            Controls.Add(btnLogout);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Система банкомата";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnCards;
        private System.Windows.Forms.Button btnAtms;
        private System.Windows.Forms.Button btnTerminal;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnLogout;
    }
}
