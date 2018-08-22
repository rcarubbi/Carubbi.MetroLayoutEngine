using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Carubbi.MetroLayoutEngine
{
    [DefaultEvent("TileClick")]
    public partial class Tile : UserControl
    {
        private const int SMALL_WIDTH = 176;

        private const int SMALL_HEIGHT = 176;

        private const int MEDIUM_WIDTH = 176 * 2;

        private const int MEDIUM_HEIGHT = 176;

        private const int BIG_WIDTH = 176 * 2;

        private const int BIG_HEIGHT = 176 * 2;

        private ModoTile _modo;

        private bool _showBorder;

        public Tile()
        {
            InitializeComponent();
        }

        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

        public Image Icone
        {
            get => picIcone.Image;
            set => picIcone.Image = value;
        }

        public ModoTile Modo
        {
            get => _modo;
            set
            {
                _modo = value;
                AlterarModo(_modo);
                if (DesignMode) Refresh();
            }
        }

        private void RaiseTileClick(object sender, EventArgs e)
        {
            if (TileClick != null)
                TileClick(sender, e);
        }

        public event EventHandler TileClick;

        private void AlterarModo(ModoTile value)
        {
            switch (value)
            {
                case ModoTile.Pequeno:
                    Width = SMALL_WIDTH;
                    Height = SMALL_HEIGHT;
                    break;
                case ModoTile.Medio:
                    Width = MEDIUM_WIDTH;
                    Height = MEDIUM_HEIGHT;
                    break;
                case ModoTile.Grande:
                    Width = BIG_WIDTH;
                    Height = BIG_HEIGHT;
                    break;
                default:
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_showBorder)
            {
                var bounds = e.ClipRectangle;
                bounds.Inflate(-1, -1);
                var whitePen = new Pen(Color.White, 1);
                e.Graphics.DrawRectangle(whitePen, bounds);
            }
        }

        private void Tile_MouseEnter(object sender, EventArgs e)
        {
            _showBorder = true;
            Refresh();
            _showBorder = false;
        }

        private void Tile_MouseLeave(object sender, EventArgs e)
        {
            if (ClientRectangle.Contains(PointToClient(MousePosition)))
                return;
            Refresh();
        }
    }
}