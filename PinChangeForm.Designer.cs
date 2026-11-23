namespace AtmSystem
{
    partial class PinChangeForm
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
            lblOld = new System.Windows.Forms.Label();
            txtOld = new System.Windows.Forms.TextBox();
            lblNew = new System.Windows.Forms.Label();
            txtNew = new System.Windows.Forms.TextBox();
            lblRepeat = new System.Windows.Forms.Label();
            txtRepeat = new System.Windows.Forms.TextBox();
            btnOk = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblOld
            // 
            lblOld.AutoSize = true;
            lblOld.Location = new System.Drawing.Point(15, 18);
            lblOld.Name = "lblOld";
            lblOld.Size = new System.Drawing.Size(147, 23);
            lblOld.TabIndex = 0;
            lblOld.Text = "Текущий пин-код";
            // 
            // txtOld
            // 
            txtOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOld.Location = new System.Drawing.Point(15, 43);
            txtOld.MaxLength = 4;
            txtOld.Name = "txtOld";
            txtOld.Size = new System.Drawing.Size(140, 30);
            txtOld.TabIndex = 1;
            txtOld.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new System.Drawing.Point(15, 83);
            lblNew.Name = "lblNew";
            lblNew.Size = new System.Drawing.Size(132, 23);
            lblNew.TabIndex = 2;
            lblNew.Text = "Новый пин-код";
            // 
            // txtNew
            // 
            txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNew.Location = new System.Drawing.Point(15, 108);
            txtNew.MaxLength = 4;
            txtNew.Name = "txtNew";
            txtNew.Size = new System.Drawing.Size(140, 30);
            txtNew.TabIndex = 3;
            txtNew.UseSystemPasswordChar = true;
            // 
            // lblRepeat
            // 
            lblRepeat.AutoSize = true;
            lblRepeat.Location = new System.Drawing.Point(12, 147);
            lblRepeat.Name = "lblRepeat";
            lblRepeat.Size = new System.Drawing.Size(219, 23);
            lblRepeat.TabIndex = 4;
            lblRepeat.Text = "Повторите новый пин-код";
            // 
            // txtRepeat
            // 
            txtRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRepeat.Location = new System.Drawing.Point(15, 176);
            txtRepeat.MaxLength = 4;
            txtRepeat.Name = "txtRepeat";
            txtRepeat.Size = new System.Drawing.Size(140, 30);
            txtRepeat.TabIndex = 5;
            txtRepeat.UseSystemPasswordChar = true;
            // 
            // btnOk
            // 
            btnOk.BackColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(46, 111, 166);
            btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOk.ForeColor = System.Drawing.Color.White;
            btnOk.Location = new System.Drawing.Point(190, 105);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(120, 32);
            btnOk.TabIndex = 6;
            btnOk.Text = "Сменить";
            btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.White;
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 200, 215);
            btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 238, 247);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(31, 58, 95);
            btnCancel.Location = new System.Drawing.Point(190, 173);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(120, 32);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // PinChangeForm
            // 
            AcceptButton = btnOk;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(340, 250);
            Controls.Add(lblOld);
            Controls.Add(txtOld);
            Controls.Add(lblNew);
            Controls.Add(txtNew);
            Controls.Add(lblRepeat);
            Controls.Add(txtRepeat);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PinChangeForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Смена пин-кода";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblOld;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
