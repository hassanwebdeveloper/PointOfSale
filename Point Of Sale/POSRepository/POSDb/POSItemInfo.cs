using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSItem")]
    public class POSItemInfo
    {
        private int mDiscount = -1;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        [ForeignKey("Type")]
        public virtual int TypeId { get; set; }

        public POSItemType Type { get; set; }

        [ForeignKey("Category")]
        public virtual int CategoryId { get; set; }

        public POSItemCategory Category { get; set; }

        public int BuyingPrice { get; set; }

        public int SellingPrice { get; set; }

        public int Discount { get; set; }

        public bool DiscountInPercent { get; set; }

        public byte[] ImageContent { get; set; }

        [ForeignKey("Vendor")]
        public virtual int VendorId { get; set; }

        public VendorInfo Vendor { get; set; }
        
        public int TotalItemsPurchased { get; set; }

        public int TotalItemsSold { get; set; }

        public virtual List<POSItemTransactionItem> Transactions { get; set; }

        public virtual List<POSBillItemInfo> BillItems { get; set; }

        public string CustomData { get; set; }
        
        public int GetRemaningQuantity(int orderQuantity = 0)
        {
            int quantity = 0;

            quantity = this.TotalItemsPurchased - this.TotalItemsSold - orderQuantity;

            return quantity;
        }

        [NotMapped]
        public int RemainingQuantity
        {
            get
            {
                return this.GetRemaningQuantity();
            }
        }

        [NotMapped]
        public int RemainingStockAmmount
        {
            get
            {
                return this.GetRemaningQuantity() * this.BuyingPrice;
            }
        }

        [NotMapped]
        public int TotalStockAmmount
        {
            get
            {
                return this.TotalItemsPurchased * this.BuyingPrice;
            }
        }

        [NotMapped]
        public int DiscountedPrice
        {
            get
            {
                int price = 0;

                price = this.SellingPrice - this.ActualDiscountPrice;

                return price;
            }
        }

        [NotMapped]
        public string CategoryName
        {
            get
            {
                string categoryName = null;

                if (this.Category != null)
                {
                    categoryName = this.Category.Name;

                }

                return categoryName;
            }
        }

        [NotMapped]
        public string TypeName
        {
            get
            {
                string typeName = null;

                if (this.Type != null)
                {
                    typeName = this.Type.Name;

                }

                return typeName;
            }
        }

        [NotMapped]
        public string VendorName
        {
            get
            {
                string vendorName = null;

                if (this.Vendor != null)
                {
                    vendorName = this.Vendor.Name;

                }

                return vendorName;
            }
        }


        [NotMapped]
        public Image Image
        {
            get
            {
                Image img = null;

                if (this.ImageContent != null)
                {
                    using (MemoryStream stream = new MemoryStream(this.ImageContent))
                    {
                        img = new Bitmap(stream);
                    }

                }

                return img;
            }
        }
        
        [NotMapped]
        public int DiscountPrice
        {
            get
            {

                int discount = 0;

                if (this.mDiscount >= 0)
                {
                    discount = this.mDiscount;
                }
                else
                {
                    discount = this.ActualDiscountPrice;
                }

                return discount;
            }

            set
            {
                this.mDiscount = value;
            }
        }

        [NotMapped]
        public int ActualDiscountPrice
        {
            get
            {

                int discount = this.Discount;

                if (this.DiscountInPercent)
                {
                    discount = (discount / 100) * this.SellingPrice;
                }

                return discount;
            }
            
        }


        public int GetOrderTotal(int orderQuantity)
        {
            int total = 0;

            int discount = this.Discount;

            if (this.DiscountInPercent)
            {
                discount = (discount / 100) * this.SellingPrice;
            }

            int sellingPrice = this.SellingPrice - discount;

            total = sellingPrice * orderQuantity;

            return total;
        }

        [NotMapped]
        public int Profit
        {
            get
            {
                int profit = 0;
                int discount = this.Discount;

                if (this.DiscountInPercent)
                {
                    discount = (discount / 100) * this.SellingPrice;
                }

                profit = (this.SellingPrice - discount) - this.BuyingPrice;

                return profit;
            }
        }

        [NotMapped]
        public bool DiscountExceeds
        {
            get
            {
                bool discountExceed = false;

                if (this.DiscountInPercent)
                {
                    discountExceed = this.Discount > 100;
                }
                else
                {
                    discountExceed = this.Discount > this.BuyingPrice;
                }

                return discountExceed;
            }
        }

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

                barCode = (string.IsNullOrEmpty(this.ShortName) ? (this.Category == null ? (this.Type == null ? string.Empty : this.Type.ShortName) : this.Category.ShortName) : this.ShortName) + barCode;

                return barCode;
            }
        }

        public int GetTotalProfit(int total, int quantity)
        {
            int profit = 0;

            int actualTotal = this.BuyingPrice * quantity;

            profit = total - actualTotal;

            return profit;
        }
    }
}
