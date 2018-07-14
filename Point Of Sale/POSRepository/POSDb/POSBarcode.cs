using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository.POSDb
{
    [Table("POSBarcode")]
    public class POSBarcode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Barcode
        {
            get
            {
                string barcode = Convert.ToString(this.Id);

                return barcode;
            }

            set { }
        }

        public string Pattern { get; set; }

        public string CustomData { get; set; }

    }
}
