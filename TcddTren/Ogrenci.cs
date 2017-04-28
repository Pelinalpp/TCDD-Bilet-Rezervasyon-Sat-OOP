using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Ogrenci : Yolcu//yolcudan kalıtıldı çünkü öğrencide bir yolcudur ve ücreti öğrenci olmasına göre hesaplanır.(ek olarak ücret 0.5 ile çarpılır)
    {
        public override void UcretHesapla(string kalkis, string varis)
        {
            base.UcretHesapla(kalkis, varis);
            ucret = Ucret * 0.5M;
        }
    }
}
