using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class AccountsForm : Form
    {
        Account selected;

        public AccountsForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);

            if (!Session.IsAdmin)
            {
                Ui.Disable(btnAdd, btnSave, btnDelete);
                lblViewOnly.Visible = true;
            }
            ClearFields();
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
            List<Account> list = AccountRepo.GetAll(txtSearch.Text.Trim());
            grid.DataSource = list;
            Ui.Hide(grid, "Id");
            Ui.Header(grid, "AccountNumber", "Номер счета");
            Ui.Header(grid, "OwnerName", "Владелец");
            Ui.Header(grid, "Balance", "Баланс");
            Ui.Header(grid, "DailyLimit", "Лимит в сутки");
            grid.Columns["Balance"].DefaultCellStyle.Format = "N2";
            grid.Columns["DailyLimit"].DefaultCellStyle.Format = "N2";
            Ui.Fit(grid);
            selected = grid.CurrentRow == null ? null : grid.CurrentRow.DataBoundItem as Account;
        }

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;
            selected = grid.CurrentRow.DataBoundItem as Account;
            if (selected == null) return;
            txtNumber.Text = selected.AccountNumber;
            txtOwner.Text = selected.OwnerName;
            txtBalance.Text = selected.Balance.ToString("0.00");
            txtLimit.Text = selected.DailyLimit.ToString("0.00");
            txtBalance.ReadOnly = true;
        }

        void ClearFields()
        {
            selected = null;
            txtNumber.Clear(); txtOwner.Clear();
            txtBalance.ReadOnly = false;
            txtBalance.Text = "0,00";
            txtLimit.Text = Config.DefaultDailyLimit.ToString("0.00");
            grid.ClearSelection();
        }

        Account FromFields()
        {
            string err = Validator.AccountNumber(txtNumber.Text.Trim());
            if (err == null) err = Validator.Owner(txtOwner.Text);
            decimal balance, limit;
            if (err == null && (!Validator.ParseMoney(txtBalance.Text, out balance) || balance < 0)) err = "Баланс должен быть числом не меньше нуля";
            if (err == null && (!Validator.ParseMoney(txtLimit.Text, out limit) || limit <= 0)) err = "Лимит должен быть числом больше нуля";
            if (err != null)
            {
                Ui.Error(err);
                return null;
            }
            Validator.ParseMoney(txtBalance.Text, out balance);
            Validator.ParseMoney(txtLimit.Text, out limit);
            return new Account
            {
                AccountNumber = txtNumber.Text.Trim(),
                OwnerName = txtOwner.Text.Trim(),
                Balance = balance,
                DailyLimit = limit
            };
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            Account a = FromFields();
            if (a == null) return;
            string err = AccountRepo.Add(a);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Добавлен счет " + a.AccountNumber);
            Reload();
            ClearFields();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите счет в таблице"); return; }
            Account a = FromFields();
            if (a == null) return;
            a.Id = selected.Id;
            string err = AccountRepo.Update(a);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Изменен счет " + a.AccountNumber);
            Reload();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите счет в таблице"); return; }
            if (!Ui.Ask("Удалить счет " + selected.AccountNumber + "?")) return;
            string err = AccountRepo.Delete(selected.Id);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Удален счет " + selected.AccountNumber);
            Reload();
            ClearFields();
        }
    }
}
