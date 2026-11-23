using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class TerminalForm : Form
    {
        Card card;

        public TerminalForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
            pnlMenu.Visible = false;

            foreach (Atm a in AtmRepo.GetAll()) cbAtm.Items.Add(a);
            if (cbAtm.Items.Count > 0) cbAtm.SelectedIndex = 0;
        }

        Atm CurrentAtm()
        {
            return cbAtm.SelectedItem as Atm;
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void btnEnter_Click(object sender, EventArgs e)
        {
            Atm atm = CurrentAtm();
            if (atm == null) { Ui.Error("Нет ни одного банкомата"); return; }
            if (atm.Status != "Working") { Ui.Error("Этот банкомат сейчас не работает"); return; }
            string err;
            card = AtmService.Authorize(txtCard.Text.Trim(), txtPin.Text, out err);
            if (card == null)
            {
                Ui.Error(err);
                txtPin.Clear();
                return;
            }
            lblOwner.Text = card.OwnerName;
            lblCardMask.Text = "Карта " + AtmService.Mask(card.CardNumber);
            txtReceipt.Text = "";
            txtAmount.Clear();
            pnlLogin.Visible = false;
            pnlMenu.Visible = true;
            AcceptButton = null;
        }

        void ShowReceipt(OpResult r, string opName, decimal amount)
        {
            string line = new string('-', 38);
            string text;
            if (r.Ok)
            {
                text = "ЧЕК" + Environment.NewLine + line + Environment.NewLine +
                       "Дата:      " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + Environment.NewLine +
                       "Банкомат:  " + CurrentAtm().Address + Environment.NewLine +
                       "Карта:     " + AtmService.Mask(card.CardNumber) + Environment.NewLine +
                       "Операция:  " + opName + Environment.NewLine;
                if (amount > 0) text += "Сумма:     " + amount.ToString("N2") + " руб." + Environment.NewLine;
                text += "Остаток:   " + r.Balance.ToString("N2") + " руб." + Environment.NewLine + line;
            }
            else
            {
                text = "ОТКАЗ" + Environment.NewLine + line + Environment.NewLine + r.Message;
            }
            txtReceipt.Text = text;
        }

        void btnBalance_Click(object sender, EventArgs e)
        {
            ShowReceipt(AtmService.GetBalance(CurrentAtm().Id, card), "Запрос баланса", 0);
        }

        void btnStatement_Click(object sender, EventArgs e)
        {
            txtReceipt.Text = "ПОСЛЕДНИЕ ОПЕРАЦИИ" + Environment.NewLine + new string('-', 38) + Environment.NewLine +
                              AtmService.Statement(card.Id, 7);
        }

        bool ReadAmount(out decimal amount)
        {
            if (!Validator.ParseMoney(txtAmount.Text, out amount))
            {
                Ui.Error("Введите сумму числом");
                return false;
            }
            return true;
        }

        void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!ReadAmount(out amount)) return;
            ShowReceipt(AtmService.Withdraw(CurrentAtm().Id, card, amount), "Снятие наличных", amount);
        }

        void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!ReadAmount(out amount)) return;
            ShowReceipt(AtmService.Deposit(CurrentAtm().Id, card, amount), "Внесение наличных", amount);
        }

        void btnChangePin_Click(object sender, EventArgs e)
        {
            using (var f = new PinChangeForm())
            {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                if (f.NewPin != f.RepeatPin) { Ui.Error("Новые пин-коды не совпадают"); return; }
                string err = AtmService.ChangePin(card, f.OldPin, f.NewPin);
                if (err != null) { Ui.Error(err); return; }
                txtReceipt.Text = "Пин-код изменен";
            }
        }

        void btnEject_Click(object sender, EventArgs e)
        {
            card = null;
            txtCard.Clear();
            txtPin.Clear();
            pnlMenu.Visible = false;
            pnlLogin.Visible = true;
            AcceptButton = btnEnter;
        }
    }
}
