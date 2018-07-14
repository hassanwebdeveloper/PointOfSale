using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSReports
{
    public class POSReportModel
    {
        public string Name { get; set; }

        public int PurchasedCount { get; set; }

        public int PurchasedAmount { get; set; }

        public int ReturnedCount { get; set; }

        public int ReturnedAmount { get; set; }

        public int SoldCount { get; set; }

        public int SoldAmount { get; set; }

        public int RefundCount { get; set; }

        public int RefundAmount { get; set; }

        public int ExchangeCount { get; set; }

        public int ExchangeAmount { get; set; }

        public int Profit { get; set; }

        public int Discount { get; set; }

        public int DiscountedPrice { get; set; }

        public bool DiscountInPercent { get; set; }
    }
}
