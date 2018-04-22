using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSSalesMan")]
    public class POSSalesMan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string CNICNumber { get; set; }

        public bool Salaried { get; set; }

        public int Salary { get; set; }

        public bool Commisioned { get; set; }

        public bool InPercent { get; set; }

        public int Commision { get; set; }

        public virtual List<POSBillInfo> Bills { get; set; }

        public virtual List<POSAttendanceInfo> Attendance { get; set; }

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

                barCode = "#SM-" + barCode;

                return barCode;
            }
        }

        public int GetSalesManCommision(List<POSBillItemInfo> billItems)
        {
            int commision = 0;

            if (this.Commisioned)
            {
                if (this.InPercent)
                {
                    foreach (POSBillItemInfo item in billItems)
                    {
                        commision += (item.Total * this.Commision) / 100;
                    }
                }
                else
                {
                    commision = this.Commision * billItems.Count;
                }
                
            }

            return commision;
        }
    }
}
