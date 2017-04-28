using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Bilet//Bilet sınıfın yolcudan en son onay alındu-ıktan sonra yolcunun tüm bilgilerinin tutulduğu sınıftır. bilet ekleme ve listeleme işlemleri gerçekleştirilir.
    {
        public int BiletNo { get; set; }

        public Rezervasyon rezervasyon;

        public List<Yolcu> Biletler = new List<Yolcu>();
        //Rezervasyondaki bilgiler bilete dönüştürüldü.
        public void BiletEkle(Rezervasyon r)
        {
            Biletler=r.Yolcular;
        }
        //Bilet listelendi
        public string BiletListele()
        {
            string temp = "";
            foreach (Yolcu i in Biletler)
            {
                temp += "Ad : " + i.Ad + Environment.NewLine + "Soyad : " + i.Soyad + Environment.NewLine + "Tc Kimlik No : " + i.TcKimlikNo.ToString() + Environment.NewLine + "Kalkış Yeri : " + i.sefer.Kalkis + Environment.NewLine + "Varış Yeri : " + i.sefer.Varis + Environment.NewLine + "Ucret : " + i.Ucret.ToString() + Environment.NewLine + "Puan : " + i.Puan.ToString() + Environment.NewLine + Environment.NewLine;
            }
            return temp;
        }
    }
}
