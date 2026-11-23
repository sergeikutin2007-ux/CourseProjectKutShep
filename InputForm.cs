using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
        }

        public InputForm(string title, string label, string initial) : this()
        {
            Text = title;
            lblPrompt.Text = label;
            txtValue.Text = initial;
        }

        public string Value { get { return txtValue.Text; } }
    }
}
