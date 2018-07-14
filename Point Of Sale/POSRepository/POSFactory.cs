using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    public static class POSFactory
    {
        public static VendorInfo CreateVendor(string name,
                                                string address, 
                                                string contactNumber, 
                                                string cellPhoneNumber)
        {
            VendorInfo vendor = new VendorInfo()
            {
                Name = name,
                Address = address,
                ContactNumber = contactNumber,
                CellPhoneNumber = cellPhoneNumber
            };

            return vendor;
        }

        public static POSItemInfo CreateOrUpdatePOSItemInfo(POSItemInfo itemInfo,
                                                            string name, 
                                                            string shortName,
                                                            int buyingPrice,
                                                            int sellingPrice, 
                                                            string description,
                                                            int discount,
                                                            bool discountInPercent,
                                                            byte[] imageContent,
                                                            int itemsCount,
                                                            POSItemCategory category,
                                                            POSItemType type,
                                                            VendorInfo vendor)
        {
            POSItemInfo item = null;
            if (itemInfo == null)
            {
                item = new POSItemInfo();
                item.TotalItemsSold = 0;
            }
            else
            {
                item = itemInfo;
            }
             

            item.Name = name;
            item.ShortName = shortName;
            item.BuyingPrice = buyingPrice;
            item.SellingPrice = sellingPrice;
            item.Description = description;
            item.Discount = discount;
            item.DiscountInPercent = discountInPercent;
            item.ImageContent = imageContent;
            item.TotalItemsPurchased = itemsCount;
            item.Category = category;
            item.Type = type;
            item.Vendor = vendor;

            return item;
        }

        public static POSItemTransactionItem CreatePOSItemTransactionItem(POSItemInfo item,
                                                                          bool isPurchased, 
                                                                          int itemsCount,
                                                                          int itemRate)
        {
            POSItemTransactionItem transactionItem = new POSItemTransactionItem();

            transactionItem.Item = item;
            transactionItem.IsPurchased = isPurchased;
            transactionItem.ItemCount = itemsCount;
            transactionItem.TransactionTime = DateTime.Now;
            transactionItem.ItemRate = itemRate;

            return transactionItem;
        }

        public static POSItemTransactionInfo CreatePOSItemTransactionInfo(List<POSItemTransactionItem> items)
        {
            POSItemTransactionInfo transactionInfo = new POSItemTransactionInfo();

            transactionInfo.Items = items;
            transactionInfo.TransactionTime = DateTime.Now;

            return transactionInfo;
        }

        public static POSItemCategory CreateOrUpdatePOSItemCategory(POSItemCategory category,
                                                                    string name,
                                                                    string shortName)
        {
            POSItemCategory itemCategory = null;

            if (category == null)
            {
                itemCategory = new POSItemCategory();
            }
            else
            {
                itemCategory = category;
            }
                

            itemCategory.Name = name;
            itemCategory.ShortName = shortName ?? string.Empty;

            return itemCategory;
        }

        public static POSItemType CreateOrUpdatePOSItemType(POSItemType itemType, 
                                                            string name,
                                                            string shortName)
        {
            POSItemType type = null;

            if (itemType == null)
            {
                type = new POSItemType();
            }
            else
            {
                type = itemType;
            }


            type.Name = name;
            type.ShortName = shortName ?? string.Empty;

            return type;
        }

        public static POSAppUser CreateOrUpdatePOSAppUser(POSAppUser posAppUser, 
                                                            string name, 
                                                            string lastName,
                                                            string contactNumber, 
                                                            string address,
                                                            string role,
                                                            string password, 
                                                            string customData)
        {
            POSAppUser appUser = null;            

            if (posAppUser == null)
            {
                appUser = new POSAppUser();
            }
            else
            {
                appUser = posAppUser;
            }

            appUser.Name = name;
            appUser.LastName = lastName;
            appUser.ContactNumber = contactNumber;
            appUser.Address = address;
            appUser.Roles = role;
            appUser.Password = password;
            appUser.CustomData = customData;

            return appUser;
        }

        public static POSSalesMan CreateOrUpdatePOSSalesMan(POSSalesMan posSalesMan, 
                                                            string name, 
                                                            string lastName,
                                                            string contactNumber,
                                                            string address, 
                                                            string cnicNumber,
                                                            bool salaried,
                                                            int salary,
                                                            bool commisioned,
                                                            bool inPercent,
                                                            int commision)
        {
            POSSalesMan salesMan = null;

            if (posSalesMan == null)
            {
                salesMan = new POSSalesMan();
            }
            else
            {
                salesMan = posSalesMan;
            }

            salesMan.Name = name;
            salesMan.LastName = lastName;
            salesMan.ContactNumber = contactNumber;
            salesMan.Address = address;
            salesMan.CNICNumber = cnicNumber;
            salesMan.Salaried = salaried;
            salesMan.Salary = salary;
            salesMan.Commisioned = commisioned;
            salesMan.InPercent = inPercent;
            salesMan.Commision = commision;

            return salesMan;
        }

        public static POSBillInfo CreateOrUpdatePOSBillInfo(POSBillInfo posBillInfo,
                                                            List<POSBillItemInfo> billItems, 
                                                            List<POSRefundInfo> refunds,
                                                            int amountPaid,
                                                            bool billCanceled,
                                                            bool billPayed,
                                                            POSAppUser appUser,
                                                            POSSalesMan salesMan)
        {
            POSBillInfo billInfo = null;

            if (posBillInfo == null)
            {
                billInfo = new POSBillInfo();
            }
            else
            {
                billInfo = posBillInfo;
            }

            billInfo.BillItems = billItems;
            billInfo.AmountPaid = amountPaid;
            billInfo.BillCanceled = billCanceled;
            billInfo.BillPayed = billPayed;
            billInfo.AppUser = appUser;
            billInfo.SalesMan = salesMan;
            billInfo.Refunds = refunds;
            billInfo.BillCreatedDate = DateTime.Now;
            billInfo.PaymentMethod = POSBillPaymentMethod.Cash;

            return billInfo;
        }

        public static POSBillItemInfo CreateOrUpdatePOSBillItemInfo(POSBillItemInfo posBillItemInfo, 
                                                                    POSItemInfo posItems,
                                                                    int rate, 
                                                                    int quantity,
                                                                    int discount)
        {
            POSBillItemInfo billItemInfo = null;

            if (posBillItemInfo == null)
            {
                billItemInfo = new POSBillItemInfo();
            }
            else
            {
                billItemInfo = posBillItemInfo;
            }

            billItemInfo.PosItem1 = posItems;
            billItemInfo.Quantity = quantity;
            billItemInfo.Discount = discount;
            billItemInfo.Rate = rate;

            return billItemInfo;
        }

        public static POSRefundInfo CreateOrUpdatePOSRefundInfo(POSRefundInfo posRefundInfo,
                                                                List<POSRefundItemInfo> refundItems,
                                                                POSBillInfo billInfo,
                                                                bool refunded,
                                                                bool exchange,
                                                                DateTime refundDate,
                                                                POSAppUser appUser)
        {
            POSRefundInfo refundInfo = null;

            if (posRefundInfo == null)
            {
                refundInfo = new POSRefundInfo();
            }
            else
            {
                refundInfo = posRefundInfo;
            }

            refundInfo.RefundItems = refundItems;
            refundInfo.Refunded = refunded;
            refundInfo.Exchange = exchange;
            refundInfo.AppUser = appUser;
            refundInfo.BillInfo = billInfo;
            refundInfo.RefundDate = refundDate;

            return refundInfo;
        }

        public static POSRefundItemInfo CreateOrUpdatePOSRefundItemInfo(POSRefundItemInfo posRefundItemInfo,
                                                                        POSBillItemInfo billItemInfo, 
                                                                        int quantity)
        {
            POSRefundItemInfo refundItemInfo = null;

            if (posRefundItemInfo == null)
            {
                refundItemInfo = new POSRefundItemInfo();
            }
            else
            {
                refundItemInfo = posRefundItemInfo;
            }

            refundItemInfo.BillItemInfo = billItemInfo;
            refundItemInfo.Quantity = quantity;

            return refundItemInfo;
        }

        public static SystemSettings CreateOrUpdateSystemSettings(SystemSettings systemSettings,
                                                                    string shopName,
                                                                    string shopAddress,
                                                                    string shopContact, 
                                                                    string thanksNote,
                                                                    string termsAndConditions,
                                                                    string refundTermsAndConditions)
        {
            SystemSettings sysSettings = null;

            if (systemSettings == null)
            {
                sysSettings = new SystemSettings();
            }
            else
            {
                sysSettings = systemSettings;
            }

            sysSettings.ShopName = shopName;
            sysSettings.ShopAddress = shopAddress;
            sysSettings.ShopContact = shopContact;
            sysSettings.ThanksNote = thanksNote;
            sysSettings.BillTermsAndConditions = termsAndConditions;
            sysSettings.RefundTermsAndConditions = refundTermsAndConditions;

            return sysSettings;
        }

        public static RepresentativeInfo CreateRepresentative(string name, 
                                                                string address, 
                                                                string contactNumber, 
                                                                string designation, 
                                                                VendorInfo vendor)
        {
            RepresentativeInfo representative = new RepresentativeInfo()
            {
                Name = name,
                Address = address,
                ContactNumber = contactNumber,
                Designation = designation,
                Vendor = vendor
            };

            return representative;
        }

        public static POSAttendanceInfo CreateOrUpdatePOSAttendanceInfo(POSAttendanceInfo posAttendanceInfo,
                                                                        bool onDuty,
                                                                        DateTime inTime,
                                                                        DateTime outTime,
                                                                        POSSalesMan salesMan)
        {
            POSAttendanceInfo attendanceInfo = null;

            if (salesMan != null)
            {
                if (posAttendanceInfo == null)
                {
                    attendanceInfo = new POSAttendanceInfo();
                }
                else
                {
                    attendanceInfo = posAttendanceInfo;
                }

                attendanceInfo.OnDuty = onDuty;
                attendanceInfo.InTime = inTime;
                attendanceInfo.OutTime = outTime;
                attendanceInfo.SalesMan = salesMan;
            }
            

            return attendanceInfo;
        }

        public static POSExpenseInfo CreateOrUpdatePOSExpenseInfo(POSExpenseInfo posExpenseInfo,
                                                                string name,
                                                                string location,
                                                                int ammount,
                                                                DateTime expenseTime,
                                                                POSAppUser appUser)
        {
            POSExpenseInfo expenseInfo = null;

            if (posExpenseInfo == null)
            {
                expenseInfo = new POSExpenseInfo();
            }
            else
            {
                expenseInfo = posExpenseInfo;
            }

            expenseInfo.Name = name;
            expenseInfo.Ammount = ammount;
            expenseInfo.AppUser = appUser;
            expenseInfo.Location = location;
            expenseInfo.ExpenseTime = expenseTime;

            return expenseInfo;
        }
    }
}
