using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Yolcu : Kisi//Kişi sınıfından kalıtıldı çünkü isim-soyad-tc kimlik no bilgileri çekildi.
    {
        public Sefer sefer = new Sefer();//yolcunun sefer bilgisi vardır

        public Rezervasyon rez;

        protected decimal ucret;
        public decimal Ucret { 
            get { return ucret; }
            set { value = ucret; }
        }
        //Bu metotla hatlar arası ücreti atama işlemi yapıldı.
        public virtual void UcretHesapla(string kalkis, string varis)
        {
            int sayac = 0;
            while (true)
            {
                if(kalkis == sefer.Hat[sayac,0])
                {
                    if(varis == sefer.Hat[sayac,1])
                    {
                        ucret = Convert.ToDecimal(sefer.Hat[sayac, 2]);
                        break;
                    }
                }
                sayac++;
            }
        }
        //Bilet gidiş dönüş şeklinde alınıyorsa ücret 2 ile çarpılır.
        //ör: izmir-manisa arası 7tl ise gidiş 7 + dönüş 7 = 14 tl
        public void UcretCarp()
        {
            ucret *= 2.0M;
        }

        //Bu metotla puan hesaplandı.
        public void PuanHesapla()
        {
            Puan += Ucret * 0.001M;
        }
        //Bu metotla puana göre ücreti-puanı hesaplama işlemi yapıldı.
        //ör: 10 puan var ucret:7tl
        //puan:10-7=3tl - ucret:0
        //ör:5 puan var ücret : 8tl
        //ücret:8-5=3tl - puan:0
        public void PuanCikar(decimal ucr)
        {
            if (ucr <= Puan)
            {
                Puan -= ucr;
                ucret = 0;
            }
            else if (ucr > Puan)
            {
                ucret -= Puan;
                Puan = 0;
            }
        }

    }
}
