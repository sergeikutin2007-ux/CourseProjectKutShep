using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class MainForm : Form
    {
        public bool LogoutRequested;

        public MainForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);

            string role = Session.Current.Role;
            string roleRu = role == "admin" ? "администратор" : (role == "manager" ? "менеджер" : (role == "guest" ? "гость" : "клиент"));
            lblUser.Text = "Пользователь: " + Session.Current.Login + " (" + roleRu + ")";

            // клиенту доступны терминал и курсы валют, гостю только курсы валют
            bool staff = role == "admin" || role == "manager";
            if (!staff) Ui.Disable(btnAccounts, btnCards, btnAtms, btnReport, btnQueue, btnStats);
            if (Session.IsGuest) Ui.Disable(btnTerminal);
            // резервное копирование доступно только администратору
            if (role != "admin") Ui.Disable(btnBackup);
        }

        void Open(Form f)
        {
            using (f) f.ShowDialog(this);
        }

        void btnAccounts_Click(object sender, EventArgs e)
        {
            Open(new AccountsForm());
        }

        void btnCards_Click(object sender, EventArgs e)
        {
            Open(new CardsForm());
        }

        void btnAtms_Click(object sender, EventArgs e)
        {
            Open(new AtmsForm());
        }

        void btnTerminal_Click(object sender, EventArgs e)
        {
            Open(new TerminalForm());
        }

        void btnReport_Click(object sender, EventArgs e)
        {
            Open(new ReportForm());
        }

        void btnQueue_Click(object sender, EventArgs e)
        {
            Open(new QueueForm());
        }

        void btnStats_Click(object sender, EventArgs e)
        {
            Open(new StatsForm());
        }

        void btnCurrency_Click(object sender, EventArgs e)
        {
            Open(new CurrencyForm());
        }

        void btnBackup_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "База данных SQLite (*.db)|*.db";
                dlg.FileName = "atm_backup_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".db";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    Db.Backup(dlg.FileName);
                    Log.Write("INFO", "Резервная копия базы: " + dlg.FileName);
                    MessageBox.Show("Резервная копия сохранена:\n" + dlg.FileName, "Резервная копия", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Log.Write("ERROR", "Не удалось создать резервную копию: " + ex.Message);
                    MessageBox.Show("Не удалось создать копию:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutRequested = true;
            Close();
        }
    }
}
