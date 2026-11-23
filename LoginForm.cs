using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
        }

        void btnGuest_Click(object sender, EventArgs e)
        {
            // гость не хранится в базе и видит только курсы валют
            Session.Current = new User { Id = 0, Login = "гость", Role = "guest" };
            Log.Write("INFO", "Вход выполнен: гость");
            DialogResult = DialogResult.OK;
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            if (login.Length == 0 || txtPassword.Text.Length == 0)
            {
                Ui.Error("Введите логин и пароль");
                return;
            }
            User u = UserRepo.Login(login, txtPassword.Text);
            if (u == null)
            {
                Log.Write("WARN", "Неудачный вход, логин " + login);
                Ui.Error("Неверный логин или пароль");
                txtPassword.Clear();
                return;
            }
            Session.Current = u;
            Log.Write("INFO", "Вход выполнен: " + u.Login + " (" + u.Role + ")");
            DialogResult = DialogResult.OK;
        }
    }
}
