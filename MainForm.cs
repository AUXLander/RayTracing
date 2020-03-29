using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{
    public partial class MainForm : Form
    {
        private ShaderView SV;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SV = new ShaderView(GLView.Width, GLView.Height, GLView.Width, GLView.Height);
        }

        private void GLView_Paint(object sender, PaintEventArgs e)
        {
            GLView.MakeCurrent();
            SV.DrawQuads();
            GLView.SwapBuffers();
        }
    }
}
