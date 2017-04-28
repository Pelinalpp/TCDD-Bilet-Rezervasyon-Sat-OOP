using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Tam: Yolcu//yolcudan kalıtıldı çünkü tamda bir yolcudur ve ücreti tam olmasına göre hesaplanır.
    {
        public override void UcretHesapla(string kalkis, string varis)
        {
            base.UcretHesapla(kalkis, varis);
        }
    }
}
