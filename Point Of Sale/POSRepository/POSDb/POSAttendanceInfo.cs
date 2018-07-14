using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSAttendanceInfo")]
    public class POSAttendanceInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool OnDuty { get; set; }

        public DateTime InTime { get; set; }

        public DateTime OutTime { get; set; }

        [ForeignKey("SalesMan")]
        public virtual int SalesManId { get; set; }

        public POSSalesMan SalesMan { get; set; }

        public string CustomData { get; set; }
    }
}
