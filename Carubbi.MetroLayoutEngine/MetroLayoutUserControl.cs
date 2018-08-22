using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Carubbi.MetroLayoutEngine
{
    [ToolboxItem(true)]
    public partial class MetroLayoutUserControl : UserControl
    {
        private bool _isMainPage;

        public MetroLayoutUserControl()
        {
            InitializeComponent();
        }

        public bool IsMainPage
        {
            get => _isMainPage;
            set
            {
                _isMainPage = value;
                picVoltar.Visible = !_isMainPage;
            }
        }

        public void LoadPage(MetroLayoutUserControl control)
        {
            (ParentForm as MetroLayoutForm).LoadPage(control);
        }

        public event EventHandler Voltar;

        protected void PerformVoltar(object sender, EventArgs e)
        {
            if (Voltar != null)
                Voltar(sender, e);
        }
    }
}