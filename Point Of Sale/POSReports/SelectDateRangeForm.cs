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
    public partial class SelectDateRangeForm : Form
    {
        private DateTime mFromDate, mToDate;
        public SelectDateRangeForm(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            this.mFromDate = dtpFrom.Value;
            this.mToDate = dtpTo.Value;

            this.Close();
        }

        public DateTime FromDate
        {
            get
            {
                return this.mFromDate;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return this.mToDate;
            }
        }
    }
}
