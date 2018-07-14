﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSReports
{
    public class POSReportMetaInfo
    {
        public string Label { get; set; }

        public string Value { get; set; }

        public int LabelColSpan { get; set; }

        public int ValueColSpan { get; set; }

        public int RowHeight { get; set; }
    }
}
