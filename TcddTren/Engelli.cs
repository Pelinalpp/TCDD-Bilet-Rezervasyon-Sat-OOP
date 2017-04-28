using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Engelli : Yolcu//yolcudan kalıtıldı çünkü engellide bir yolcudur ve ücreti engelli olmasına göre hesaplanır.
    {
        public override void UcretHesapla(string kalkis, string varis)
        {
            base.UcretHesapla(kalkis, varis);
            ucret = Ucret * 0.25M;
        }
    }
}
