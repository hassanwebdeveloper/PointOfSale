﻿using System;
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

        [ForeignKey("AppUser")]
        public virtual int? AppUserId { get; set; }

        public virtual POSAppUser AppUser { get; set; }

        [ForeignKey("SalesMan")]
        public virtual int SalesManId { get; set; }

        public virtual POSSalesMan SalesMan { get; set; }

        public virtual List<POSRefundInfo> Refunds { get; set; }

        [NotMapped]
        public string Barcode
        {
            get
            {
                return "Bill" + this.Id;
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

                foreach (POSBillItemInfo item in this.BillItems)
                {
                    totalQuantity += item.Quantity;
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

                foreach (POSBillItemInfo item in this.BillItems)
                {
                    totalDiscount += item.Discount;
                }

                return totalDiscount;
            }
        }

        [NotMapped]
        public int TotalAmount
        {
            get
            {
                int totalAmount = 0;

                foreach (POSBillItemInfo item in this.BillItems)
                {
                    totalAmount += item.Total;
                }

                foreach (POSRefundInfo refund in this.Refunds)
                {
                    totalAmount += refund.Rate;
                }

                return totalAmount;
            }
        }

        [NotMapped]
        public int TotalGross
        {
            get
            {
                int totalGross = 0;

                foreach (POSBillItemInfo item in this.BillItems)
                {
                    totalGross += item.TotalGross;
                }

                return totalGross;
            }
        }

        [NotMapped]
        public int AmountReturned
        {
            get
            {
                int totalreturn = this.AmountPaid - this.TotalAmount;                

                return totalreturn;
            }
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
