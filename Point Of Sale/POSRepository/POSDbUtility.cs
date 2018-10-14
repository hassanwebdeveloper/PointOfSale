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
                
                mDbContext.Vendors.Remove(vendor);//.Entry(vendor).State = EntityState.Deleted;
                mDbContext.POSItems.RemoveRange(vendor.Items);

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

            // Get ObjectContext from DBContext
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from pOSItem in objectContext.CreateObjectSet<POSItemInfo>().Include("Category").Include("Vendor").Include("Type").Include("BillItems.PosBill")
                        where pOSItem != null
                        select pOSItem);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSItemInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSItemInfos = data.ToList();

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
                mDbContext.POSItems.Remove(posItem);// Entry(posItem).State = EntityState.Deleted;

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
            
            // Get ObjectContext from DBContext
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from pOSItemType in objectContext.CreateObjectSet<POSItemType>()
                        where pOSItemType != null
                        select pOSItemType);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSItemType>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSItemTypes = data.ToList();

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
                mDbContext.POSTypes.Remove(posItemType);// Entry(posItemType).State = EntityState.Deleted;

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
            
            // Get ObjectContext from DBContext
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from pOSItemCategory in objectContext.CreateObjectSet<POSItemCategory>()
                        where pOSItemCategory != null
                        select pOSItemCategory);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSItemCategory>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSItemCategories = data.ToList();

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
                mDbContext.POSCategories.Remove(posItemCategory);//.Entry(posItemCategory).State = EntityState.Deleted;

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

        #endregion POSItemCategories

        #region POSPurchaseInfos

        public static List<POSItemTransactionInfo> GetAllPOSPurchases()
        {
            List<POSItemTransactionInfo> lstPOSPurchases = new List<POSItemTransactionInfo>();
            
            // Get ObjectContext from DBContext
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posPurchase in objectContext.CreateObjectSet<POSItemTransactionInfo>()
                        where posPurchase != null
                        select posPurchase);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSItemTransactionInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSPurchases = data.ToList();

            return lstPOSPurchases;
        }

        public static List<POSItemTransactionInfo> GetAllPOSPurchases(DateTime fromDate, DateTime toDate)
        {
            List<POSItemTransactionInfo> lstPOSPurchases = new List<POSItemTransactionInfo>();
            
            // Get ObjectContext from DBContext
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posPurchase in objectContext.CreateObjectSet<POSItemTransactionInfo>()
                        where posPurchase != null && posPurchase.TransactionTime >= fromDate && posPurchase.TransactionTime < toDate
                        select posPurchase);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSItemTransactionInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSPurchases = data.ToList();

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
                mDbContext.POSPurchases.Remove(posPurchase);//.Entry(posPurchase).State = EntityState.Deleted;

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
            
            // Get ObjectContext from DBContext
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from pOSAppUser in objectContext.CreateObjectSet<POSAppUser>()
                        where pOSAppUser != null
                        select pOSAppUser);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSAppUser>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSAppUsers = data.ToList();

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
                mDbContext.POSAppUsers.Remove(posAppUser);//.Entry(posAppUser).State = EntityState.Deleted;

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
                // Get ObjectContext from DBContext
                var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

                // Construct an ObjectQuery                 

                var data = (from posSalesMan in objectContext.CreateObjectSet<POSSalesMan>()
                            where posSalesMan != null
                            select posSalesMan);

                // Set the MergeOption property
                (data as System.Data.Entity.Core.Objects.ObjectQuery<POSSalesMan>).MergeOption =
                                 System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

                lstPOSSalesMans = data.ToList();
            }
            else
            {
                var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

                // Construct an ObjectQuery                 

                var data = (from posSalesMan in objectContext.CreateObjectSet<POSSalesMan>()
                            where posSalesMan != null && posSalesMan.Id == salesManId
                            select posSalesMan);

                // Set the MergeOption property
                (data as System.Data.Entity.Core.Objects.ObjectQuery<POSSalesMan>).MergeOption =
                                 System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

                lstPOSSalesMans = data.ToList();
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
                mDbContext.POSSalesMans.Remove(posSalesMan);//.Entry(posSalesMan).State = EntityState.Deleted;

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
                var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

                // Construct an ObjectQuery                 

                var data = (from pOSAttendanceInfo in objectContext.CreateObjectSet<POSAttendanceInfo>()
                            where pOSAttendanceInfo != null
                            select pOSAttendanceInfo);

                // Set the MergeOption property
                (data as System.Data.Entity.Core.Objects.ObjectQuery<POSAttendanceInfo>).MergeOption =
                                 System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

                lstOSAttendanceInfos = data.ToList();
            }
            else
            {
                //lstOSAttendanceInfos = (from pOSAttendanceInfo in mDbContext.POSAttendanceInfo
                //                        where pOSAttendanceInfo != null
                //                        select pOSAttendanceInfo).ToList();
                var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

                // Construct an ObjectQuery                 

                var data = (from pOSAttendanceInfo in objectContext.CreateObjectSet<POSAttendanceInfo>()
                            where pOSAttendanceInfo != null && pOSAttendanceInfo.SalesManId == salesManId && pOSAttendanceInfo.InTime.Date == date
                            select pOSAttendanceInfo);

                // Set the MergeOption property
                (data as System.Data.Entity.Core.Objects.ObjectQuery<POSAttendanceInfo>).MergeOption =
                                 System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

                lstOSAttendanceInfos = data.ToList();
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
                mDbContext.POSAttendanceInfo.Remove(posAttendanceInfo);//.Entry(posAttendanceInfo).State = EntityState.Deleted;

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

            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posBill in objectContext.CreateObjectSet<POSBillInfo>()
                        where posBill != null
                        select posBill);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSBillInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSSalesMans = data.ToList();

            return lstPOSSalesMans;
        }

        public static List<POSBillInfo> GetAllPOSBillInfo(string itemName)
        {
            List<POSBillInfo> lstPOSBills = new List<POSBillInfo>();

            string id = POSBillInfo.ExtractIdFromBarcode(itemName);
            
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posBill in objectContext.CreateObjectSet<POSBillInfo>()
                        where posBill != null && posBill.Id.ToString() == id
                        select posBill);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSBillInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSBills = data.ToList();

            return lstPOSBills;
        }

        public static List<POSBillInfo> GetAllPOSBillInfo(DateTime fromDate, DateTime toDate)
        {
            List<POSBillInfo> lstPOSBills = new List<POSBillInfo>();
            
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posBill in objectContext.CreateObjectSet<POSBillInfo>().Include("BillItems.PosItem1")
                        where posBill != null && posBill.BillCreatedDate >= fromDate && posBill.BillCreatedDate < toDate
                        select posBill);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSBillInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSBills = data.ToList();

            return lstPOSBills;
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
                mDbContext.POSBills.Remove(posBill);//.Entry(posBill).State = EntityState.Deleted;

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
            
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posBillItem in objectContext.CreateObjectSet<POSBillItemInfo>()
                        where posBillItem != null
                        select posBillItem);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSBillItemInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPosBillItems = data.ToList();

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
                mDbContext.POSBillItems.Remove(posBillItem);//.Entry(posBillItem).State = EntityState.Deleted;

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

        public static List<POSRefundInfo> GetAllPOSRefundInfo(DateTime fromDate, DateTime toDate, bool refunded)
        {
            List<POSRefundInfo> lstPOSSalesMans = new List<POSRefundInfo>();
            
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posRefund in objectContext.CreateObjectSet<POSRefundInfo>()
                        where posRefund != null && posRefund.RefundDate >= fromDate && posRefund.RefundDate < toDate && posRefund.Refunded == refunded
                        select posRefund);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSRefundInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSSalesMans = data.ToList();

            return lstPOSSalesMans;
        }

        public static List<POSRefundInfo> GetAllPOSRefundInfo()
        {
            List<POSRefundInfo> lstPOSSalesMans = new List<POSRefundInfo>();

            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posRefund in objectContext.CreateObjectSet<POSRefundInfo>()
                        where posRefund != null
                        select posRefund);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSRefundInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSSalesMans = data.ToList();

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
                mDbContext.POSRefunds.Remove(posRefund);//.Entry(posRefund).State = EntityState.Deleted;

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
            
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from sysettings in objectContext.CreateObjectSet<SystemSettings>()
                        where sysettings != null
                        select sysettings);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<SystemSettings>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstSystemSettings = data.ToList();
            
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
                mDbContext.SystemSettings.Remove(systemSettings);//.Entry(systemSettings).State = EntityState.Deleted;

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

        #region POSExpenseInfo

        public static List<POSExpenseInfo> GetAllPOSExpenses()
        {
            List<POSExpenseInfo> lstPOSExpenses = new List<POSExpenseInfo>();

            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posExpense in objectContext.CreateObjectSet<POSExpenseInfo>()
                        where posExpense != null
                        select posExpense);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSExpenseInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSExpenses = data.ToList();

            return lstPOSExpenses;
        }

        public static List<POSExpenseInfo> GetAllPOSExpenses(DateTime fromDate, DateTime toDate)
        {
            List<POSExpenseInfo> lstPOSExpenses = new List<POSExpenseInfo>();
            
            var objectContext = ((IObjectContextAdapter)mDbContext).ObjectContext;

            // Construct an ObjectQuery                 

            var data = (from posExpense in objectContext.CreateObjectSet<POSExpenseInfo>()
                        where posExpense != null && posExpense.ExpenseTime >= fromDate && posExpense.ExpenseTime < toDate
                        select posExpense);

            // Set the MergeOption property
            (data as System.Data.Entity.Core.Objects.ObjectQuery<POSExpenseInfo>).MergeOption =
                             System.Data.Entity.Core.Objects.MergeOption.OverwriteChanges;

            lstPOSExpenses = data.ToList();
            
            return lstPOSExpenses;
        }

        public static POSStatusCodes AddPOSExpenseInfo(POSExpenseInfo posExpenseInfo, ref string errorMsg, bool saveChanges)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.POSExpenses.Add(posExpenseInfo);

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

        public static POSStatusCodes UpdatePOSExpenseInfo(POSExpenseInfo posExpenseInfo, ref string errorMsg)
        {
            POSStatusCodes status = POSStatusCodes.Failed;

            try
            {
                mDbContext.Entry(posExpenseInfo).State = EntityState.Modified;

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

        public static POSStatusCodes DeletePOSExpenseInfo(POSExpenseInfo posExpenseInfo, ref string errorMsg, bool saveChanges = true)
        {
            POSStatusCodes status = POSStatusCodes.Failed;


            try
            {
                mDbContext.POSExpenses.Remove(posExpenseInfo);//.Entry(posItemCategory).State = EntityState.Deleted;

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

        #endregion POSExpenseInfo

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
