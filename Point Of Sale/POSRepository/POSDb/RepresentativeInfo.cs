using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("Representative")]
    public class RepresentativeInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepresentativeId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string Designation { get; set; }

        [ForeignKey("Vendor")]
        public virtual int VendorId { get; set; }

        public VendorInfo Vendor { get; set; }

        public virtual List<POSItemInfo> Items { get; set; }
    }
}
