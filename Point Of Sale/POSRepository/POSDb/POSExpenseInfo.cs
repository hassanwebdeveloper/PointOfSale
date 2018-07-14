using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSExpenseInfo")]
    public class POSExpenseInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime ExpenseTime { get; set; }

        public int Ammount { get; set; }

        [ForeignKey("AppUser")]
        public virtual int? AppUserId { get; set; }

        public virtual POSAppUser AppUser { get; set; }

        public string CustomData { get; set; }

        [NotMapped]
        public string AppUserName
        {
            get
            {
                string appUserName = null;

                if (this.AppUser != null)
                {
                    appUserName = this.AppUser.Name;

                }

                return appUserName;
            }
        }
    }
}
