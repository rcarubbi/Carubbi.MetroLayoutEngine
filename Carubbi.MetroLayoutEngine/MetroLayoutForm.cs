using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.MetroLayoutEngine
{
    public partial class MetroLayoutForm : Form
    {
        private MetroLayoutUserControl _paginaInicial;

        private readonly Stack<MetroLayoutUserControl> callStack = new Stack<MetroLayoutUserControl>();

        public MetroLayoutForm()
        {
            InitializeComponent();
        }

        public string Titulo
        {
            set => lblTitulo.Text = value;
            get => lblTitulo.Text;
        }

        public Color BodyBackColor
        {
            get => pnlConteudo.BackColor;

            set => pnlConteudo.BackColor = value;
        }

        public Color TitleBackColor
        {
            get => pnlTitulo.BackColor;
            set => pnlTitulo.BackColor = value;
        }

        public Image BrandLogo
        {
            get => picLogo.Image;
            set => picLogo.Image = value;
        }

        public Color TitleForeColor
        {
            get => lblTitulo.ForeColor;
            set => lblTitulo.ForeColor = value;
        }

        public MetroLayoutUserControl PaginaInicial
        {
            get => _paginaInicial;
            set
            {
                _paginaInicial = value;
                if (_paginaInicial != null)
                {
                    _paginaInicial.IsMainPage = true;
                    LoadPage(_paginaInicial);
                }
                else
                {
                    pnlConteudo.Controls.Clear();
                }


                Refresh();
            }
        }

        public void LoadPage(MetroLayoutUserControl userControl)
        {
            userControl.Voltar += userControl_Voltar;
            callStack.Push(userControl);
            AtualizarConteudo(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void AtualizarConteudo(MetroLayoutUserControl userControl)
        {
            foreach (Control control in pnlConteudo.Controls) control.Visible = false;

            if (!pnlConteudo.Controls.Contains(userControl)) pnlConteudo.Controls.Add(userControl);

            userControl.Visible = true;
        }

        private void userControl_Voltar(object sender, EventArgs e)
        {
            Back();
        }

        protected void Back()
        {
            var control = callStack.Pop();
            Controls.Remove(control);
            control.Dispose();
            var userControl = callStack.Peek();
            AtualizarConteudo(userControl);
        }
    }
}