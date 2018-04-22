using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    public static class POSDbUtility
    {
        internal static PosDbContext mDbContext = new PosDbContext();

        #region Vendors

        public static List<VendorInfo> GetAllVendors()
        {
            List<VendorInfo> lstVendors = new List<VendorInfo>();            

            lstVendors = (from vendor in mDbContext.Vendors
                          where vendor != null
                          select vendor).ToList();

            return lstVendors;
        }               

        public static POSStatusCodes AddVendor(VendorInfo vendor, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Vendors.Add(vendor);

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);   
            }

            return status;
        }

        public static POSStatusCodes UpdateVendor(VendorInfo vendor, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(vendor).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeleteVendor(VendorInfo vendor, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(vendor).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }                

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);                
            }

            return status;
        }

        #endregion

        #region Representatives

        public static List<RepresentativeInfo> GetAllRepresentative(string vendorName = "")
        {
            List<RepresentativeInfo> lstRepresentatives = new List<RepresentativeInfo>();

            //lstRepresentatives = (from representative in mDbContext.Representatives
            //              where representative != null
            //              select representative).ToList();

            return lstRepresentatives;
        }

        public static POSStatusCodes AddRepresentative(RepresentativeInfo representative)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            //try
            //{
            //    mDbContext.Representatives.Add(representative);

            //    mDbContext.SaveChanges();

            //    status = POSStatusCodes.Success;
            //}
            //catch (Exception e)
            //{
            //    RollBack();

            //    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);

            //    MessageBox.Show(errorMsg);
            //}

            return status;
        }

        public static POSStatusCodes UpdateRepresentative(RepresentativeInfo representative)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            //try
            //{
            //    mDbContext.Entry(representative).State = EntityState.Modified;

            //    mDbContext.SaveChanges();

            //    status = POSStatusCodes.Success;
            //}
            //catch (Exception e)
            //{
            //    RollBack();

            //    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);

            //    MessageBox.Show(errorMsg);
            //}

            return status;
        }

        public static POSStatusCodes DeleteRepresentative(RepresentativeInfo representative)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            //try
            //{
            //    mDbContext.Entry(representative).State = EntityState.Deleted;

            //    mDbContext.SaveChanges();

            //    status = POSStatusCodes.Success;
            //}
            //catch (Exception e)
            //{
            //    RollBack();

            //    string errorMsg = POSComonUtility.GetInnerExceptionMessage(e);

            //    MessageBox.Show(errorMsg);
            //}

            return status;
        }

        #endregion

        #region POSItems

        public static List<POSItemInfo> GetAllPOSItems()
        {
            List<POSItemInfo> lstPOSItemInfos = new List<POSItemInfo>();

            lstPOSItemInfos = (from pOSItem in mDbContext.POSItems.Include("Category").Include("Vendor").Include("Type")
                               where pOSItem != null
                               select pOSItem).ToList();

            return lstPOSItemInfos;
        }

        public static POSStatusCodes AddPOSItem(POSItemInfo posItem, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSItems.Add(posItem);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }                

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSItem(POSItemInfo posItem, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posItem).State = EntityState.Modified;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }
                

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSItem(POSItemInfo posItem, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posItem).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region POSItemTypes

        public static List<POSItemType> GetAllPOSItemTypes()
        {
            List<POSItemType> lstPOSItemTypes = new List<POSItemType>();

            lstPOSItemTypes = (from pOSItemType in mDbContext.POSTypes
                               where pOSItemType != null
                               select pOSItemType).ToList();

            return lstPOSItemTypes;
        }

        public static POSStatusCodes AddPOSItemType(POSItemType posItemType, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSTypes.Add(posItemType);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSItemType(POSItemType posItemType, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posItemType).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSItemType(POSItemType posItemType, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posItemType).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region POSItemCategories

        public static List<POSItemCategory> GetAllPOSItemCategories()
        {
            List<POSItemCategory> lstPOSItemCategories = new List<POSItemCategory>();

            lstPOSItemCategories = (from pOSItemCategory in mDbContext.POSCategories
                                    where pOSItemCategory != null
                                    select pOSItemCategory).ToList();

            return lstPOSItemCategories;
        }

        public static POSStatusCodes AddPOSItemCategory(POSItemCategory posItemCategory, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSCategories.Add(posItemCategory);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSItemCategory(POSItemCategory posItemCategory, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posItemCategory).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSItemCategory(POSItemCategory posItemCategory, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;
            

            try
            {
                mDbContext.Entry(posItemCategory).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region POSPurchaseInfos

        public static List<POSItemTransactionInfo> GetAllPOSPurchases()
        {
            List<POSItemTransactionInfo> lstPOSPurchases = new List<POSItemTransactionInfo>();

            lstPOSPurchases = (from posPurchase in mDbContext.POSPurchases
                               where posPurchase != null
                               select posPurchase).ToList();

            return lstPOSPurchases;
        }

        public static POSStatusCodes AddPOSPurchase(POSItemTransactionInfo posPurchase, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSPurchases.Add(posPurchase);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSPurchase(POSItemTransactionInfo posPurchase, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posPurchase).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSPurchase(POSItemTransactionInfo posPurchase, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posPurchase).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);                
            }

            return status;
        }

        #endregion POSItems

        #region POSAppUser

        public static List<POSAppUser> GetAllPOSAppuser()
        {
            List<POSAppUser> lstPOSAppUsers = new List<POSAppUser>();

            lstPOSAppUsers = (from pOSAppUser in mDbContext.POSAppUsers
                               where pOSAppUser != null
                               select pOSAppUser).ToList();

            return lstPOSAppUsers;
        }

        public static POSStatusCodes AddPOSAppUser(POSAppUser posAppUser, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSAppUsers.Add(posAppUser);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSAppUser(POSAppUser posAppUser, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posAppUser).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSAppUser(POSAppUser posAppUser, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posAppUser).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region POSSalesMan

        public static List<POSSalesMan> GetAllPOSSalesMan(int salesManId)
        {
            List<POSSalesMan> lstPOSSalesMans = new List<POSSalesMan>();

            if (salesManId <= 0)
            {
                lstPOSSalesMans = (from posSalesMan in mDbContext.POSSalesMans
                                   where posSalesMan != null
                                   select posSalesMan).ToList();
            }
            else
            {
                lstPOSSalesMans = (from posSalesMan in mDbContext.POSSalesMans
                                   where posSalesMan != null && posSalesMan.Id == salesManId
                                   select posSalesMan).ToList();
            }

            

            return lstPOSSalesMans;
        }

        public static POSStatusCodes AddPOSSalesMan(POSSalesMan posSalesMan, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSSalesMans.Add(posSalesMan);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSSalesMan(POSSalesMan posSalesMan, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posSalesMan).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSSalesMan(POSSalesMan posSalesMan, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posSalesMan).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSSalesMan

        #region POSSalesMan

        public static List<POSAttendanceInfo> GetAllPOSAttendanceInfo(int salesManId, DateTime date)
        {
            List<POSAttendanceInfo> lstOSAttendanceInfos = new List<POSAttendanceInfo>();

            if (salesManId <= 0)
            {
                lstOSAttendanceInfos = (from pOSAttendanceInfo in mDbContext.POSAttendanceInfo
                                        where pOSAttendanceInfo != null
                                        select pOSAttendanceInfo).ToList();
            }
            else
            {
                lstOSAttendanceInfos = (from pOSAttendanceInfo in mDbContext.POSAttendanceInfo
                                        where pOSAttendanceInfo != null && pOSAttendanceInfo.SalesManId == salesManId && pOSAttendanceInfo.InTime.Date == date
                                        select pOSAttendanceInfo).ToList();
            }
            

            return lstOSAttendanceInfos;
        }

        public static POSStatusCodes AddPOSAttendanceInfo(POSAttendanceInfo posAttendanceInfo, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSAttendanceInfo.Add(posAttendanceInfo);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSAttendanceInfo(POSAttendanceInfo posAttendanceInfo, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posAttendanceInfo).State = EntityState.Modified;

                mDbContext.SaveChanges();

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSAttendanceInfo(POSAttendanceInfo posAttendanceInfo, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posAttendanceInfo).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSSalesMan

        #region POSBillInfo

        public static List<POSBillInfo> GetAllPOSBillInfo()
        {
            List<POSBillInfo> lstPOSSalesMans = new List<POSBillInfo>();

            lstPOSSalesMans = (from posBill in mDbContext.POSBills.Include("BillItems.PosItem1")
                               where posBill != null
                               select posBill).ToList();

            return lstPOSSalesMans;
        }

        public static List<POSBillInfo> GetAllPOSBillInfo(DateTime fromDate, DateTime toDate)
        {
            List<POSBillInfo> lstPOSSalesMans = new List<POSBillInfo>();

            lstPOSSalesMans = (from posBill in mDbContext.POSBills.Include("BillItems.PosItem1")
                               where posBill != null where posBill.BillCreatedDate >= fromDate && posBill.BillCreatedDate < toDate
                               select posBill).ToList();

            return lstPOSSalesMans;
        }

        public static POSStatusCodes AddPOSBillInfo(POSBillInfo posBill, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSBills.Add(posBill);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSBillInfo(POSBillInfo posBill, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posBill).State = EntityState.Modified;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }                

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSBillInfo(POSBillInfo posBill, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posBill).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region POSBillItemInfo

        public static List<POSBillItemInfo> GetAllPOSBillItemInfo()
        {
            List<POSBillItemInfo> lstPosBillItems = new List<POSBillItemInfo>();

            lstPosBillItems = (from posBillItem in mDbContext.POSBillItems
                               where posBillItem != null
                               select posBillItem).ToList();

            return lstPosBillItems;
        }

        public static POSStatusCodes AddPOSBillItemInfo(POSBillItemInfo posBillItem, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSBillItems.Add(posBillItem);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSBillItemInfo(POSBillItemInfo posBillItem, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posBillItem).State = EntityState.Modified;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSBillItemInfo(POSBillItemInfo posBillItem, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posBillItem).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region POSRefundInfo

        public static List<POSRefundInfo> GetAllPOSRefundInfo()
        {
            List<POSRefundInfo> lstPOSSalesMans = new List<POSRefundInfo>();

            lstPOSSalesMans = (from posRefund in mDbContext.POSRefunds
                               where posRefund != null
                               select posRefund).ToList();

            return lstPOSSalesMans;
        }

        public static POSStatusCodes AddPOSRefundInfo(POSRefundInfo posRefund, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSRefunds.Add(posRefund);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdatePOSRefundInfo(POSRefundInfo posRefund, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posRefund).State = EntityState.Modified;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }
                

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeletePOSRefundInfo(POSRefundInfo posRefund, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posRefund).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region SystemSettings

        public static List<SystemSettings> GetAllSystemSettings()
        {
            List<SystemSettings> lstSystemSettings = new List<SystemSettings>();

            lstSystemSettings = (from sysettings in mDbContext.SystemSettings
                               where sysettings != null
                               select sysettings).ToList();

            return lstSystemSettings;
        }

        public static POSStatusCodes AddSystemSettings(SystemSettings systemSettings, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.SystemSettings.Add(systemSettings);

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes UpdateSystemSettings(SystemSettings systemSettings, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(systemSettings).State = EntityState.Modified;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }


                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        public static POSStatusCodes DeleteSystemSettings(SystemSettings systemSettings, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(systemSettings).State = EntityState.Deleted;

                if (saveChanges)
                {
                    mDbContext.SaveChanges();
                }

                status = POSStatusCodes.Success;
            }
            catch (Exception e)
            {
                RollBack();

                errorMsg = POSComonUtility.GetInnerExceptionMessage(e);
            }

            return status;
        }

        #endregion POSItems

        #region Utility Methods

        private static void RollBack()
        {
            List<DbEntityEntry> changedEntries = mDbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public static void InitializeDatabases()
        {
            mDbContext = new PosDbContext();

            try
            {
                GetAllPOSAppuser();
            }
            catch (Exception e)
            {

            }
        }

        #endregion
    }
}
