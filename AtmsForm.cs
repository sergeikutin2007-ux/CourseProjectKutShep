using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class AtmsForm : Form
    {
        Atm selected;

        public AtmsForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
            cbStatus.SelectedIndex = 0;

            if (!Session.IsAdmin)
            {
                Ui.Disable(btnAdd, btnSave, btnDelete, btnCash);
                lblViewOnly.Visible = true;
            }
            Reload();
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        void Reload()
        {
            grid.DataSource = AtmRepo.GetAll();
            Ui.Hide(grid, "Id");
            Ui.Hide(grid, "Status");
            Ui.Header(grid, "Address", "Адрес");
            Ui.Header(grid, "CashBalance", "Наличные");
            Ui.Header(grid, "StatusRu", "Состояние");
            grid.Columns["CashBalance"].DefaultCellStyle.Format = "N2";
            Ui.Fit(grid);
            selected = grid.CurrentRow == null ? null : grid.CurrentRow.DataBoundItem as Atm;
        }

        void ClearFields()
        {
            selected = null;
            txtAddress.Clear();
            txtCash.Text = "0,00";
            txtCash.ReadOnly = false;
            cbStatus.SelectedIndex = 0;
            grid.ClearSelection();
        }

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;
            selected = grid.CurrentRow.DataBoundItem as Atm;
            if (selected == null) return;
            txtAddress.Text = selected.Address;
            txtCash.Text = selected.CashBalance.ToString("0.00");
            txtCash.ReadOnly = true;
            cbStatus.SelectedIndex = selected.Status == "Working" ? 0 : 1;
        }

        Atm FromFields()
        {
            decimal cash;
            if (txtAddress.Text.Trim().Length < 3) { Ui.Error("Укажите адрес банкомата"); return null; }
            if (!Validator.ParseMoney(txtCash.Text, out cash) || cash < 0) { Ui.Error("Сумма наличных должна быть числом не меньше нуля"); return null; }
            return new Atm
            {
                Address = txtAddress.Text.Trim(),
                CashBalance = cash,
                Status = cbStatus.SelectedIndex == 0 ? "Working" : "Service"
            };
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            Atm a = FromFields();
            if (a == null) return;
            AtmRepo.Add(a);
            Log.Write("INFO", "Добавлен банкомат " + a.Address);
            Reload();
            ClearFields();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите банкомат в таблице"); return; }
            Atm a = FromFields();
            if (a == null) return;
            a.Id = selected.Id;
            AtmRepo.Update(a);
            Log.Write("INFO", "Изменен банкомат " + a.Address);
            Reload();
        }

        void btnCash_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите банкомат в таблице"); return; }
            string text = Ui.Prompt("Загрузка наличных", "Сколько рублей загрузить в банкомат?", "100000");
            if (text == null) return;
            decimal amount;
            if (!Validator.ParseMoney(text, out amount) || amount <= 0)
            {
                Ui.Error("Введите сумму числом больше нуля");
                return;
            }
            AtmRepo.AddCash(selected.Id, amount);
            Log.Write("INFO", "Загружено " + amount + " руб. в банкомат " + selected.Address);
            int id = selected.Id;
            Reload();
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                Atm a = grid.Rows[i].DataBoundItem as Atm;
                if (a != null && a.Id == id) { grid.CurrentCell = grid.Rows[i].Cells["Address"]; break; }
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null) { Ui.Error("Выберите банкомат в таблице"); return; }
            if (!Ui.Ask("Удалить банкомат " + selected.Address + "?")) return;
            string err = AtmRepo.Delete(selected.Id);
            if (err != null) { Ui.Error(err); return; }
            Log.Write("INFO", "Удален банкомат " + selected.Address);
            Reload();
            ClearFields();
        }
    }
}
