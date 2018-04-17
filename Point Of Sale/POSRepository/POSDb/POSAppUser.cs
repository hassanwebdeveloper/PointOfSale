using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSAppUser")]
    public class POSAppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string Roles { get; set; }

        public virtual List<POSRefundInfo> Refunds { get; set; }

        public virtual List<POSBillInfo> Bills { get; set; }

        public string Password { get; set; }

        public string CustomData { get; set; }

        [NotMapped]
        public bool IsAdmin { get; set; }

        [NotMapped]
        public bool ViewItems { get; set; }

        [NotMapped]
        public bool UpdateItems { get; set; }

        [NotMapped]
        public bool ViewVendors { get; set; }

        [NotMapped]
        public bool UpdateVendors { get; set; }

        [NotMapped]
        public bool PrintBarcode { get; set; }

        [NotMapped]
        public bool CreateBill { get; set; }

        [NotMapped]
        public bool RefundBill { get; set; }

        [NotMapped]
        public bool SearchItems { get; set; }

        public void PopulatesRolesBoolean()
        {
            if (string.IsNullOrEmpty(this.Roles))
            {
                return;
            }

            this.IsAdmin = this.Roles.Contains("Admin");
            this.ViewItems = this.Roles.Contains("ViewItems");
            this.UpdateItems = this.Roles.Contains("UpdateItems");
            this.ViewVendors = this.Roles.Contains("ViewVendors");
            this.UpdateVendors = this.Roles.Contains("UpdateVendors");
            this.PrintBarcode = this.Roles.Contains("PrintBarcode");
            this.CreateBill = this.Roles.Contains("CreateBill");
            this.RefundBill = this.Roles.Contains("RefundBill");
            this.SearchItems = this.Roles.Contains("SearchItem");
        }

        
    }
}
