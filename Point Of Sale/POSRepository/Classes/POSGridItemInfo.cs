using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    public class POSGridItemInfo
    {
        private POSItemInfo mPOSItemInfo = null;

        private POSRefundInfo mRefundInfo = null;

        public POSGridItemInfo(POSItemInfo posItemInfo)
        {
            this.mPOSItemInfo = posItemInfo;
        }

        public POSGridItemInfo(POSRefundInfo posRefundInfo)
        {
            this.mRefundInfo = posRefundInfo;
        }

        public string Barcode
        {
            get
            {
                string barcode = string.Empty;

                if (this.mPOSItemInfo == null)
                {
                    barcode = this.mRefundInfo.Barcode;
                }
                else
                {
                    barcode = this.mPOSItemInfo.Barcode;
                }

                return barcode;
            }
        }

        public string ProductName
        {
            get
            {
                string name = string.Empty;

                if (this.mPOSItemInfo == null)
                {
                    name = this.mRefundInfo.Name;
                }
                else
                {
                    name = this.mPOSItemInfo.Name;
                }

                return name;
            }
        }

        public int Rate
        {
            get
            {
                int rate = 0;

                if (this.mPOSItemInfo == null)
                {
                    rate = this.mRefundInfo.Rate;
                }
                else
                {
                    rate = this.mPOSItemInfo.SellingPrice;
                }

                return rate;
            }
        }

        public int Quantity
        {
            get
            {
                int quantity = 0;

                if (this.mPOSItemInfo == null)
                {
                    quantity = this.mRefundInfo.Quantity;
                }
                else
                {
                    quantity = this.mPOSItemInfo.OrderQuantity;
                }

                return quantity;
            }

            set
            {
                if (this.mPOSItemInfo != null)
                {
                    this.mPOSItemInfo.OrderQuantity = value;
                }
            }
        }

        public int Discount
        {
            get
            {
                int discount = 0;

                if (this.mPOSItemInfo == null)
                {
                    discount = this.mRefundInfo.Discount;
                }
                else
                {
                    discount = this.mPOSItemInfo.DiscountPrice;
                }

                return discount;
            }

            set
            {
                if (this.mPOSItemInfo != null)
                {
                    this.mPOSItemInfo.DiscountPrice = value;
                }
            }
        }

        public int Total
        {
            get
            {
                int total = 0;

                if (this.mPOSItemInfo == null)
                {
                    total = this.mRefundInfo.Rate;
                }
                else
                {
                    total = this.mPOSItemInfo. OrderTotal;
                }

                return total;
            }
        }

        public int RemaningQuantity
        {
            get
            {
                int quantity = 0;

                if (this.mPOSItemInfo != null)
                {
                    quantity = this.mPOSItemInfo.RemaningQuantity;
                }               

                return quantity;
            }
        }
        
        public int DiscountedPrice
        {
            get
            {
                int price = 0;

                if (this.mPOSItemInfo != null)
                {
                    price = this.mPOSItemInfo.DiscountedPrice;
                }                

                return price;
            }
        }
        public Image Image
        {
            get
            {
                Image img = null;

                if (this.mPOSItemInfo != null)
                {
                    img = this.mPOSItemInfo.Image;
                }

                return img;
            }
        }

        public POSItemInfo POSItem
        {
            get
            {
                return this.mPOSItemInfo;
            }
        }

        public POSRefundInfo POSRefund
        {
            get
            {
                return this.mRefundInfo;
            }
        }

        
    }
}
