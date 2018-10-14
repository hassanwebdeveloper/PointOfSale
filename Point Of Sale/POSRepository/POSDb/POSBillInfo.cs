using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSBillInfo")]
    public class POSBillInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime BillCreatedDate { get; set; }

        public virtual List<POSBillItemInfo> BillItems { get; set; }

        public int AmountPaid { get; set; }

        public bool BillCanceled { get; set; }

        public bool BillPayed { get; set; }

        public POSBillPaymentMethod PaymentMethod { get; set; }

        public string CardId { get; set; }

        [ForeignKey("AppUser")]
        public virtual int? AppUserId { get; set; }

        public virtual POSAppUser AppUser { get; set; }

        [ForeignKey("SalesMan")]
        public virtual int SalesManId { get; set; }

        public virtual POSSalesMan SalesMan { get; set; }

        public virtual List<POSRefundInfo> Refunds { get; set; }        

        public string CustomData { get; set; }

        [NotMapped]
        public string Barcode
        {
            get
            {
                string barCode = Convert.ToString(this.Id);

                if (barCode.Length < 8)
                {
                    for (int i = barCode.Length; i < 8; i++)
                    {
                        barCode = "0" + barCode;
                    }
                }

                return "Bill" + barCode;
            }
        }

        [NotMapped]
        public int TotalItems
        {
            get
            {
                return this.BillItems == null ? 0 : this.BillItems.Count;
            }
        }

        [NotMapped]
        public int TotalQuantity
        {
            get
            {
                int totalQuantity = 0;

                if (this.BillItems != null)
                {
                    foreach (POSBillItemInfo item in this.BillItems)
                    {
                        totalQuantity += item.Quantity;
                    }
                }                

                return totalQuantity;
            }
        }

        [NotMapped]
        public int TotalDiscount
        {
            get
            {
                int totalDiscount = 0;

                if (this.BillItems != null)
                {
                    foreach (POSBillItemInfo item in this.BillItems)
                    {
                        totalDiscount += (item.Discount * item.Quantity);
                    }
                }                

                return totalDiscount;
            }
        }

        public static string ExtractIdFromBarcode(string barcode)
        {
            string id = barcode;

            if (barcode.StartsWith("Bill"))
            {
                id = barcode.Replace("Bill", string.Empty);

                for (int i = 0; i < id.Length; i++)
                {
                    if (id[i] != '0')
                    {
                        id = id.Substring(i);
                        break;
                    }
                }
            }

            return id;
        }

        public int GetTotalAmount(List<POSRefundInfo> refunds)
        {
            int totalAmount = 0;

            if (this.BillItems != null)
            {
                foreach (POSBillItemInfo item in this.BillItems)
                {
                    totalAmount += item.Total;
                }
            }

            if (refunds != null)
            {
                foreach (POSRefundInfo refund in refunds)
                {
                    totalAmount += refund.Rate;
                }
            }


            return totalAmount;
        }

        public int GetTotalGross(List<POSRefundInfo> refunds)
        {
            int totalGross = 0;

            if (this.BillItems != null)
            {
                foreach (POSBillItemInfo item in this.BillItems)
                {
                    totalGross += item.TotalGross;
                }
            }

            if (refunds != null)
            {
                foreach (POSRefundInfo item in refunds)
                {
                    totalGross += item.Rate;
                }
            }

            return totalGross;
        }
        

        public int GetAmountReturned(List<POSRefundInfo> refunds)
        {
            int totalreturn = this.AmountPaid - this.GetTotalAmount(refunds);

            return totalreturn;
        }

        [NotMapped]
        public int TotalSalesManCommision
        {
            get
            {
                int totalCommision = this.SalesMan.GetSalesManCommision(this.BillItems);

                return totalCommision;
            }
        }


    }
}
