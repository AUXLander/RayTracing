using OpenTK.Graphics.ES10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{
    public partial class MainForm : Form
    {
        private OpenTK.GLControl GLViewer;
        private float TrackBarStep = 1;
        private ShaderView SV;
        public MainForm()
        {
            InitializeComponent();

            GLViewer = new OpenTK.GLControl(new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8));

            GLViewer.Paint += GLPaint;

            Controls.Add(GLViewer);

            GLViewer.Top = 12;
            GLViewer.Left = 12;
            GLViewer.Width = 595;
            GLViewer.Height = 595;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GLViewer.MakeCurrent();

            SV = new ShaderView(GLViewer.Width, GLViewer.Height, GLViewer.Width, GLViewer.Height);
            TrackBarStep = (4.0f + 4.0f) / (tbLightPosX.Maximum - tbLightPosX.Minimum);
        }

        private void GLPaint(object sender, PaintEventArgs e)
        {
            GLViewer.MakeCurrent();
            SV.DrawQuads();
            GLViewer.SwapBuffers();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            GLViewer.Invalidate();
        }

        private void tbLightPosX_Scroll(object sender, EventArgs e)
        {
            TrackBar trackX = sender as TrackBar;
            SV.LightSourcePosition.X = TrackBarStep * trackX.Value;
            GLViewer.Invalidate();
        }
    }
}
