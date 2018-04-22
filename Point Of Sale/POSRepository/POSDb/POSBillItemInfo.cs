using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSBillItemInfo")]
    public class POSBillItemInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("PosItem1")]
        public virtual int PosItemId { get; set; }

        public POSItemInfo PosItem1 { get; set; }

        public int Rate { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

        [ForeignKey("PosBill")]
        public virtual int PosBillId { get; set; }

        public POSBillInfo PosBill { get; set; }
        
        public List<POSRefundItemInfo> RefundItemInfos { get; set; }

        [NotMapped]
        public int Total
        {
            get
            {
                int total = (this.Rate - this.Discount) * this.Quantity;

                return total;
            }
        }

        [NotMapped]
        public int TotalGross
        {
            get
            {
                int total = this.Rate * this.Quantity;

                return total;
            }
        }

        [NotMapped]
        public string Name
        {
            get
            {
                return this.PosItem1.Name;
            }
        }

        [NotMapped]
        public string Barcode
        {
            get
            {
                return this.PosItem1.Barcode;
            }
        }
        
        public int Profit
        {
            get
            {
                int profit = 0;

                profit = this.PosItem1.GetTotalProfit(this.Total, this.Quantity);

                return profit;
            }
        }

        public DateTime BillDate
        {
            get
            {
                return this.PosBill.BillCreatedDate;
            }
        }
    }
}
