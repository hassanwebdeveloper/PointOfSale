using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSRefundInfo")]
    public class POSRefundInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RefundDate { get; set; }

        public virtual List<POSRefundItemInfo> RefundItems { get; set; }

        public bool Refunded { get; set; }

        [ForeignKey("BillInfo")]
        public int? BillId { get; set; }

        public virtual POSBillInfo BillInfo { get; set; }

        [ForeignKey("AppUser")]
        public virtual int? AppUserId { get; set; }

        public virtual POSAppUser AppUser { get; set; }

        [NotMapped]
        public string Barcode
        {
            get
            {
                return "Ref" + this.Id;
            }
        }

        [NotMapped]
        public string Name
        {
            get
            {
                return "Refund Slip # " + this.Id;
            }
        }

        [NotMapped]
        public int Rate
        {
            get
            {
                int rate = 0;

                foreach (POSRefundItemInfo refundItem in this.RefundItems)
                {
                    if (refundItem != null)
                    {
                        rate += refundItem.Total;
                    }
                }

                return rate * -1;
            }
        }

        [NotMapped]
        public int Discount
        {
            get
            {
                return 0;
            }
        }

        [NotMapped]
        public int Quantity
        {
            get
            {
                return 1;
            }
        }

        [NotMapped]
        public int TotalItems
        {
            get
            {
                return this.RefundItems.Count;
            }
        }
        
        [NotMapped]
        public int TotalQuantity
        {
            get
            {
                int totalQuantity = 0;

                foreach (POSRefundItemInfo item in this.RefundItems)
                {
                    totalQuantity += item.Quantity;
                }

                return totalQuantity;
            }
        }

        [NotMapped]
        public int Total
        {
            get
            {
                int total = 0;

                foreach (POSRefundItemInfo item in this.RefundItems)
                {
                    total += item.Total;
                }

                return total;
            }
        }
    }
}
