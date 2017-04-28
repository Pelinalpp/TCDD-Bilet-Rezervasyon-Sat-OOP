using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Nakit:OdemeTipi//ödeme tipi abstract sınıfından kalıtılan nakit sınıfı ödeme yaptıktan sonra Odeme() metodu çağırarak ödemenin tamamlandığını onaylar.
    {
        public override string Odeme()
        {
            return "Ödeme işlemi tamamlandı.\n\nÖdeme nakit olarak yapılmıştır.";
        }
    }
}
