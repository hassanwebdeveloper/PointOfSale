using POSRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale
{
    public partial class SalesManAttendanceForm : Form
    {
        private POSSalesMan mSalesMan = null;
        private DateTime mDateTime;

        public SalesManAttendanceForm(POSSalesMan salesMan)
        {
            InitializeComponent();

            this.mSalesMan = salesMan;
            this.mDateTime = DateTime.Now;
            this.lblSalesMan.Text = this.mSalesMan.Name + " " + this.mSalesMan.LastName;
            this.lblDateTime.Text = this.mDateTime.ToString();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            POSAttendanceInfo attendanceInfo = POSFactory.CreateOrUpdatePOSAttendanceInfo(null, true, this.mDateTime, DateTime.MaxValue, this.mSalesMan);

            string errorMsg = "";

            POSStatusCodes status = POSDbUtility.AddPOSAttendanceInfo(attendanceInfo, ref errorMsg, true);
           
            if (status == POSStatusCodes.Failed)
            {
                MessageBox.Show(this, "Some error occured in marking attendance.\n\n" + errorMsg);
            }
            else if (status == POSStatusCodes.Aborted)
            {
                MessageBox.Show(this, errorMsg);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            POSAttendanceInfo attendanceInfo = (from attendance in this.mSalesMan.Attendance
                                                where attendance != null && attendance.OnDuty && attendance.InTime.Date == this.mDateTime.Date
                                                select attendance).LastOrDefault();

            if (attendanceInfo == null)
            {
                MessageBox.Show(this, "No check in information found for today.");
            }
            else
            {
                attendanceInfo = POSFactory.CreateOrUpdatePOSAttendanceInfo(attendanceInfo, false, attendanceInfo.InTime, this.mDateTime, this.mSalesMan);

                string errorMsg = "";

                POSStatusCodes status = POSDbUtility.UpdatePOSAttendanceInfo(attendanceInfo, ref errorMsg);

                if (status == POSStatusCodes.Failed)
                {
                    MessageBox.Show(this, "Some error occured in marking attendance.\n\n" + errorMsg);
                }
                else if (status == POSStatusCodes.Aborted)
                {
                    MessageBox.Show(this, errorMsg);
                }
            }
        }
    }
}
