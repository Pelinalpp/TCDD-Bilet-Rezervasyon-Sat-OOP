using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public abstract class OdemeTipi//abstract yapıldı çünkü ödeme tipinden nesne oluşturmaya gerek yoktur. nesne oluşturulması gereken kredi kartı-nakit vb.
    {
        public abstract string Odeme();
    }
}
