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
using BarcodeLib;

namespace Point_Of_Sale
{
    public partial class Form1 : Form
    {
        int msgint_raw;
        int msgint_iscp;
        bool mScannerConnected = false;
        Byte[] InputBuffer = new Byte[100];
        UInt32 nBytesInInputBuffer;
        Byte[] OutputBuffer = new Byte[250];
        uint nBytesReturned;
        IntermecIsdc.IsdcWrapper m_Isdc = new IntermecIsdc.IsdcWrapper();
        IntermecIsdc.DllErrorCode m_Error = new IntermecIsdc.DllErrorCode();

        public Form1()
        {
            InitializeComponent();

            if (!LoginForm.mLoggedInUser.IsAdmin)
            {
                if (!LoginForm.mLoggedInUser.CreateBill)
                {
                    this.btnCreateBill.Enabled = false;
                }

                if (!LoginForm.mLoggedInUser.RefundBill)
                {
                    this.btnRefund.Enabled = false;
                }

                if (!LoginForm.mLoggedInUser.SearchItems)
                {
                    this.btnSearch.Enabled = false;
                }

                if (!LoginForm.mLoggedInUser.ViewPosExpense)
                {
                    this.btnManageExpenses.Enabled = false;
                }
            }

            if (LoginForm.mLoggedInUser.SearchItems || LoginForm.mLoggedInUser.RefundBill || LoginForm.mLoggedInUser.CreateBill || LoginForm.mLoggedInUser.IsAdmin)
            {
                msgint_raw = m_Isdc.RegisterWindowMessage("WM_RAW_DATA");
                msgint_iscp = m_Isdc.RegisterWindowMessage("WM_ISCP_FRAME");

                ConnectScanner();
            }
            
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            PointOfSaleForm form = new PointOfSaleForm();

            form.Show(this);
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            POSRefundForm form = new POSRefundForm();

            form.Show(this);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == msgint_raw)
            {

                Byte[] BarcodeBuffer = new Byte[500];
                m_Isdc.GetRawData(BarcodeBuffer, out nBytesReturned);

                Encoding ascii = Encoding.ASCII;

                string barcodeString = ascii.GetString(BarcodeBuffer);

                if (barcodeString.Replace("\0", string.Empty).StartsWith("#SM-"))
                {
                    string strSalesManId = barcodeString.Replace("\0", string.Empty).Replace("#SM-", string.Empty);

                    int salesManId;

                    bool parsed = int.TryParse(strSalesManId, out salesManId);

                    if (parsed)
                    {
                        Cursor currentCursor = Cursor.Current;
                        Cursor.Current = Cursors.WaitCursor;

                        try
                        {
                            List<POSSalesMan> salesMans = POSDbUtility.GetAllPOSSalesMan(salesManId);

                            if (salesMans.Count > 0 && salesMans[0] != null)
                            {
                                POSSalesMan salesMan = salesMans[0];

                                SalesManAttendanceForm attendanceForm = new SalesManAttendanceForm(salesMan);

                                Cursor.Current = currentCursor;
                                attendanceForm.ShowDialog();
                            }
                            else
                            {
                                Cursor.Current = currentCursor;
                                MessageBox.Show("Unable to find salesman for attendance.");
                            }
                        }
                        catch (Exception e)
                        {
                            string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
                            Cursor.Current = currentCursor;
                            MessageBox.Show(this, "Some error occured in fetching Sales man for attendance.\n\n" + errorMsg);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Unable to find salesman.");
                    }                    
                }
                else
                {
                    if (Form.ActiveForm != null)
                    {
                        if (Form.ActiveForm is IScanable)
                        {
                            (Form.ActiveForm as IScanable).OnBarcodeScannerRead(barcodeString);
                        }
                        else
                        {
                            MessageBox.Show(this, "Please open/select any POS or Refund Form.");
                        }
                    }
                }

                

            }
            else if (m.Msg == msgint_iscp)
            {

            }
            base.WndProc(ref m);
        }

        private void ScannerCfg()
        {
            nBytesInInputBuffer = 0;
            InputBuffer[nBytesInInputBuffer++] = 0x73; //Packeted Data format = enable
            InputBuffer[nBytesInInputBuffer++] = 0x40;
            InputBuffer[nBytesInInputBuffer++] = 0x01;

            /******************************************/
            /*     Snapshot - Image conditioning      */
            /******************************************/
            InputBuffer[nBytesInInputBuffer++] = 0x6A;
            InputBuffer[nBytesInInputBuffer++] = 0xC1;
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x20;
            InputBuffer[nBytesInInputBuffer++] = 0x00;

            InputBuffer[nBytesInInputBuffer++] = 0x01; //Auto Contrast
            InputBuffer[nBytesInInputBuffer++] = 0x01; //00=None / 01=Photo / 02=Black on white / 03=white on black

            InputBuffer[nBytesInInputBuffer++] = 0x02; //Edge Enhancement
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=Low / 02=Medium / 03=High

            InputBuffer[nBytesInInputBuffer++] = 0x03; //Image Rotation
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=90° / 02=180° / 03=270°

            InputBuffer[nBytesInInputBuffer++] = 0x04; //Subsampling
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=1 pixel out of 2

            InputBuffer[nBytesInInputBuffer++] = 0x05; //Noise Reduction
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00 to 09 Level of noise reduction (00=none)

            InputBuffer[nBytesInInputBuffer++] = 0x07; //Image Lighting Correction
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=Low / 02=Medium / 03=High

            InputBuffer[nBytesInInputBuffer++] = 0x09; //Reverse Video
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=Disable / 01=Enable

            InputBuffer[nBytesInInputBuffer++] = 0x41; //Color Conversion + Threshold
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=Monochrome / 02=Enhanced
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=Very Dark / 01=Dark / 02=Normal / 03=Bright / 04=Very Bright

            InputBuffer[nBytesInInputBuffer++] = 0x42; //Output Compression + Output Compression Quality

            InputBuffer[nBytesInInputBuffer++] = 0x01; //00=Raw / 01=JPEG / 02=TIFFG4
            InputBuffer[nBytesInInputBuffer++] = 60;   //00 to 64 (0 to 100 decimal)

            InputBuffer[nBytesInInputBuffer++] = 0x80; //Cropping
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x08; //8 bytes
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 1 and 2 (UINT16): Left column (x)
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 3 and 4 (UINT16): Top row (y)
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 5 and 6 (UINT16): Width
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 7 and 8 (UINT16): Height

            /******************************************/
            /*       Video - Image conditioning       */
            /******************************************/
            InputBuffer[nBytesInInputBuffer++] = 0x6A;
            InputBuffer[nBytesInInputBuffer++] = 0xC0;
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x20;
            InputBuffer[nBytesInInputBuffer++] = 0x00;

            InputBuffer[nBytesInInputBuffer++] = 0x01; //Auto Contrast
            InputBuffer[nBytesInInputBuffer++] = 0x01; //00=None / 01=Photo / 02=Black on white / 03=white on black

            InputBuffer[nBytesInInputBuffer++] = 0x02; //Edge Enhancement
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=Low / 02=Medium / 03=High

            InputBuffer[nBytesInInputBuffer++] = 0x03; //Image Rotation
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=90° / 02=180° / 03=270°

            InputBuffer[nBytesInInputBuffer++] = 0x04; //Subsampling

            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x05; //Noise Reduction
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00 to 09 Level of noise reduction (00=none)

            InputBuffer[nBytesInInputBuffer++] = 0x07; //Image Lighting Correction
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=Low / 02=Medium / 03=High

            InputBuffer[nBytesInInputBuffer++] = 0x09; //Reverse Video
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=Disable / 01=Enable

            InputBuffer[nBytesInInputBuffer++] = 0x41; //Color Conversion / Threshold
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=None / 01=Monochrome / 02=Enhanced Monochrome
            InputBuffer[nBytesInInputBuffer++] = 0x00; //00=Very Dark / 01=Dark / 02=Normal / 03=Bright / 04=Very Bright

            InputBuffer[nBytesInInputBuffer++] = 0x42; //Compression/Compression Quality
            InputBuffer[nBytesInInputBuffer++] = 0x01; //00=Raw / 01=JPEG / 02=TIFFG4

            InputBuffer[nBytesInInputBuffer++] = 60; //00 to 64 (0 to 100 decimal)

            InputBuffer[nBytesInInputBuffer++] = 0x80; //Cropping
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x08; //8 bytes
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 1 and 2 (UINT16): Left column (x)
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 3 and 4 (UINT16): Top row (y)
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 5 and 6 (UINT16): Width
            InputBuffer[nBytesInInputBuffer++] = 0x00;
            InputBuffer[nBytesInInputBuffer++] = 0x00; //Bytes 7 and 8 (UINT16): Height

            m_Error = m_Isdc.SetupWrite(InputBuffer, nBytesInInputBuffer, OutputBuffer, out nBytesReturned);
        }


        private void ConnectScanner()
        {
            ScannerInit();

            if (mScannerConnected == false)
            {
                m_Error = m_Isdc.ConfigurationDialog();
                if (m_Error != 0)
                {
                    //MessageError(m_Error);
                }
                else
                {
                    m_Error = m_Isdc.Connect();
                    if (m_Error != 0)
                    {
                        //MessageError(m_Error);
                    }
                    else
                    {
                        mScannerConnected = true;
                        //this.btnConnect.Text = "Disconnect";

                        nBytesInInputBuffer = 0;
                        InputBuffer[nBytesInInputBuffer++] = 0x50;
                        InputBuffer[nBytesInInputBuffer++] = 0x40;
                        InputBuffer[nBytesInInputBuffer++] = 0x00;
                        m_Isdc.ControlCommand(InputBuffer, nBytesInInputBuffer, OutputBuffer, out nBytesReturned);

                        ScannerCfg();

                        nBytesInInputBuffer = 0;
                        InputBuffer[nBytesInInputBuffer++] = 0x30;
                        InputBuffer[nBytesInInputBuffer++] = 0xC0;
                        m_Isdc.StatusRead(InputBuffer, nBytesInInputBuffer, OutputBuffer, out nBytesReturned);
                    }
                }
            }
            else
            {
                m_Isdc.Disconnect();
                mScannerConnected = false;
                //this.btnConnect.Text = "Connect";
            }
        }

        private IntermecIsdc.DllErrorCode ScannerInit()
        {
            string key = "HKCU\\SOFTWARE\\Intermec\\IsdcNetApp";
            byte status;
            m_Error = m_Isdc.Initialise(key, out status);
            return m_Error;
        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mScannerConnected)
            {
                ConnectScanner();
            }

            LoginForm.mMainForm.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPOSItemInfoForm search = new SearchPOSItemInfoForm(string.Empty);

            search.Show(this);
        }

        private void btnManageExpenses_Click(object sender, EventArgs e)
        {
            ManageExpenseForm manageExpenseForm = new ManageExpenseForm();

            manageExpenseForm.Show(this);
        }
    }
}
