using System;
using System.Windows.Forms;

namespace AtmSystem
{
    public partial class PinChangeForm : Form
    {
        public PinChangeForm()
        {
            InitializeComponent();
            Ui.SetIcon(this);
        }

        public string OldPin { get { return txtOld.Text; } }
        public string NewPin { get { return txtNew.Text; } }
        public string RepeatPin { get { return txtRepeat.Text; } }
    }
}
