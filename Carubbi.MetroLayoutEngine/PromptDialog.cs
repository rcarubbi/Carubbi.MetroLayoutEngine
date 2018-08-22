using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Carubbi.MetroLayoutEngine
{
    public partial class PromptDialog<T> : Form
    {
        private string _validationMessage;

        public PromptDialog()
        {
            InitializeComponent();
        }

        private bool AnswerIsValid => Converter.IsValid(txtAnswer.Text);

        private TypeConverter Converter => TypeDescriptor.GetConverter(typeof(T));

        public T Answer { get; private set; }

        public DialogResult Show(string title, string message, string validationMessage)
        {
            lblMessage.Text = message;
            _validationMessage = validationMessage;
            Text = title;
            return ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (AnswerIsValid)
            {
                Answer = (T) Converter.ConvertFromString(txtAnswer.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, _validationMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}