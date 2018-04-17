using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSReports
{
    public partial class SplashScreen : Form
    {
        Point mLastPoint;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mLastPoint != null && e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mLastPoint.X;
                this.Top += e.Y - mLastPoint.Y;
            }
        }

        private void SplashScreen_MouseDown(object sender, MouseEventArgs e)
        {
            this.mLastPoint = new Point(e.X, e.Y);
        }
    }
}
