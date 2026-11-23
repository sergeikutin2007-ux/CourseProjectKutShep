using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class CardsForm : Form
    {
        class AccountItem
        {
            public int Id;
            public string Text;
            public override string ToString() { return Text; }
        }

        Card selected;

        public CardsForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
            cbStatus.SelectedIndex = 0;

            if (!Session.IsAdmin)
            {
                Ui.Disable(btnAdd, btnSave, btnDelete);
                lblViewOnly.Visible = true;
            }

            foreach (Account a in AccountRepo.GetAll(null))
                cbAccount.Items.Add(new AccountItem { Id = a.Id, Text = a.AccountNumber + " - " + a.OwnerName });
            if (cbAccount.Items.Count > 0) cbAccount.SelectedIndex = 0;
            Reload();
        }

        void btnFind_Click(object sender, EventArgs e)
        {
            Reload();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            Reload();
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        void Reload()
        {
            grid.DataSource = CardRepo.GetAll(txtSearch.Text.Trim());
            Ui.Hide(grid, "Id");
            Ui.Hide(grid, "AccountId");
            Ui.Hide(grid, "Expiry");
            Ui.Hide(grid, "Status");
            Ui.Header(grid, "CardNumber", "Номер карты");
            Ui.Header(grid, "AccountNumber", "Счет");
            Ui.Header(grid, "OwnerName", "Владелец");
            Ui.Header(grid, "ExpiryView", "Срок");
            Ui.Header(grid, "StatusRu", "Состояние");
            Ui.Header(grid, "FailedAttempts", "Неверных вводов пин-кода");
            Ui.Fit(grid);
            selected = grid.CurrentRow == null ? null : grid.CurrentRow.DataBoundItem as Card;
        }

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;
            selected = grid.CurrentRow.DataBoundItem as Card;
            if (selected == null) return;
            txtNumber.Text = selected.CardNumber;
            txtExpiry.Text = Validator.ExpiryView(selected.Expiry);
            txtPin.Clear();
            cbStatus.SelectedIndex = selected.Status == "Active" ? 0 : 1;
            for (int i = 0; i < cbAccount.Items.Count; i++)
                if (((AccountItem)cbAccount.Items[i]).Id == selected.AccountId) cbAccount.SelectedIndex = i;
        }

        void ClearFields()
        {
            selected = null;
            txtNumber.Clear(); txtExpiry.Clear(); txtPin.Clear();
            cbStatus.SelectedIndex = 0;
            grid.ClearSelection();
        }

        Card FromFields(bool pinRequired)
        {
            string stored;
            string err = null;
            if (cbAccount.SelectedItem == null) err = "Сначала заведите счет";
            if (err == null) err = Validator.CardNumber(txtNumber.Text.Trim());
            if (err == null) err = Validator.ExpiryInput(txtExpiry.Text.Trim(), out stored);
            if (err == null && (pinRequired || txtPin.Text.Length > 0)) err = Validator.Pin(txtPin.Text);
            if (err != null)
            {
                Ui.Error(err);
                return null;
            }
            Validator.ExpiryInput(txtExpiry.Text.Trim(), out stored);
            return new Card
            {
                CardNumber = txtNumber.Text.Trim(),
                AccountId = ((AccountItem)cbAccount.SelectedItem).Id,
                Expiry = stored,
                Status = cbStatus.SelectedIndex == 0 ? "Active" : "Blocked"
            };
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            Card k = FromFields(true);
            if (k == null) return;
            string err = CardRepo.Add(k, txtPin.Text);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Добавлена карта " + AtmService.Mask(k.CardNumber));
            Reload();
            ClearFields();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите карту в таблице"); return; }
            Card k = FromFields(false);
            if (k == null) return;
            k.Id = selected.Id;
            string err = CardRepo.Update(k, txtPin.Text);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Изменена карта " + AtmService.Mask(k.CardNumber));
            Reload();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите карту в таблице"); return; }
            if (!Ui.Ask("Удалить карту " + AtmService.Mask(selected.CardNumber) + "?")) return;
            string err = CardRepo.Delete(selected.Id);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Удалена карта " + AtmService.Mask(selected.CardNumber));
            Reload();
            ClearFields();
        }

        private void lblPin_Click(object sender, EventArgs e)
        {

        }
    }
}
