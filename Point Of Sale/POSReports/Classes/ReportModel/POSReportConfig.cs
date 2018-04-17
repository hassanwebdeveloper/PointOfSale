using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSReports
{
    public class POSReportConfig
    {
        public string SheetName { get; set; }

        public string Heading { get; set; }

        public string FontName { get; set; }

        public Color FontColor { get; set; }

        public int HeadingFontSize { get; set; }

        public Color HeadingBackColor { get; set; }

        public Color HeaderColor { get; set; }

        public Color HeaderBorderColor { get; set; }

        public int HeaderRowHeight { get; set; }

        public int DataRowHeight { get; set; }

        public Color AltColor { get; set; }

        public Color BorderColor { get; set; }

        public List<POSReportMetaInfo> MetaInfo { get; set; }

        public List<POSReportColumn> Columns { get; set; }

        public List<POSReportData> Data { get; set; }
    }
}
