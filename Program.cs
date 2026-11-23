using System;
using System.Windows.Forms;

namespace AtmSystem
{
    static class Program
    {
        static void ReportFatal(Exception ex)
        {
            Log.Write("ERROR", "Необработанная ошибка: " + (ex == null ? "неизвестно" : ex.ToString().Replace(Environment.NewLine, " | ")));
            MessageBox.Show("Произошла непредвиденная ошибка. Подробности записаны в журнал logs/atm.log.\n\n" + (ex == null ? "" : ex.Message),
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // необработанные ошибки не должны ронять программу без следа: пишем в журнал и сообщаем пользователю
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => ReportFatal(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ReportFatal(e.ExceptionObject as Exception);

            try
            {
                Db.Init();
            }
            catch (Exception ex)
            {
                Log.Write("ERROR", "Не удалось подготовить базу: " + ex.Message);
                MessageBox.Show("Не удалось открыть базу данных:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }
                var main = new MainForm();
                Application.Run(main);
                if (!main.LogoutRequested) return;
            }
        }
    }
}
