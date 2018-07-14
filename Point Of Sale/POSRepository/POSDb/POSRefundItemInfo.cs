using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSRefundItemInfo")]
    public class POSRefundItemInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("RefundInfo")]
        public virtual int RefundInfoId { get; set; }

        public POSRefundInfo RefundInfo { get; set; }

        [ForeignKey("BillItemInfo")]
        public virtual int BillItemInfoId { get; set; }

        public POSBillItemInfo BillItemInfo { get; set; }

        public int Quantity { get; set; }

        public string CustomData { get; set; }

        [NotMapped]
        public int Total
        {
            get
            {
                int total = 0;

                if (this.BillItemInfo != null)
                {
                    total = (this.BillItemInfo.Rate - this.BillItemInfo.Discount) * Quantity;
                }

                return total;
            }
        }

        [NotMapped]
        public string Name
        {
            get
            {
                return this.BillItemInfo.Name;
            }
        }

        [NotMapped]
        public string Barcode
        {
            get
            {
                return this.BillItemInfo.Name;
            }
        }

        [NotMapped]
        public int Rate
        {
            get
            {
                return this.BillItemInfo.Rate - this.BillItemInfo.Discount;
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
    }
}
