using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("SystemSettings")]
    public class SystemSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ShopName { get; set; }

        public string ShopAddress { get; set; }

        public string ShopContact { get; set; }

        public string BillTermsAndConditions { get; set; }

        public string RefundTermsAndConditions { get; set; }

        public string ThanksNote { get; set; }
    }
}
