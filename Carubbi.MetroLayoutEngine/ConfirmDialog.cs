using System;
using System.Windows.Forms;

namespace Carubbi.MetroLayoutEngine
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog()
        {
            InitializeComponent();
        }

        public DialogResult Show(string title, string message)
        {
            lblQuestionText.Text = message;
            Text = title;
            return ShowDialog();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}