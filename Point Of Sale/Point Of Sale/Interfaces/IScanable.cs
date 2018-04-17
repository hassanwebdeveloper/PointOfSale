using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Of_Sale
{
    interface IScanable
    {
        void OnBarcodeScannerRead(string barcode);
    }
}
