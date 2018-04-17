using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("VendorInfo")]
    public class VendorInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        //public virtual List<RepresentativeInfo> Representatives { get; set; }

        public virtual List<POSItemInfo> Items { get; set; }

        public virtual List<POSItemTransactionInfo> Purchases { get; set; }
    }
}
