using System;
using System.Drawing;
using System.Windows.Forms;
using XnaWinform.Extensions;
using XnaWinform.Services;
using XnaWinform.UserControls;

namespace XnaWinform
{
    public partial class frmMain : Form
    {
        private ucRenderer _mapRenderer;

        public frmMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);           
        }

        #region Form Events

        private void Form1_Load(object sender, EventArgs e)
        {
            InitRenderer();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var camera = _mapRenderer.Services.GetService<CameraService>();
            camera.Position.Y += e.NewValue - e.OldValue;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var camera = _mapRenderer.Services.GetService<CameraService>();
            camera.Position.X += e.NewValue - e.OldValue;
        }

        #endregion Form Events

        #region Private Methods

        private void InitRenderer()
        {
            _mapRenderer = new ucRenderer();
            _mapRenderer.Dock = DockStyle.Fill;
            _mapRenderer.Location = new Point(0, 0);
            _mapRenderer.TabIndex = 0;

            this.pnlMain.Controls.Add(_mapRenderer);
        }

        #endregion Private Methods

    }
}
