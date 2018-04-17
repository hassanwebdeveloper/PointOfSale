using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    [Table("POSItemTransactionItem")]
    public class POSItemTransactionItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsPurchased { get; set; }
        
        [ForeignKey("Item")]
        public virtual int PosItemId { get; set; }

        public POSItemInfo Item { get; set; }

        public int ItemCount { get; set; }

        public DateTime TransactionTime { get; set; }
    }
}
