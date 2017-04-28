using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Rezervasyon//yolcu listesinin tutulduğu rezervasyon ekleme işleminin yapıldığı geçici sınıftır. onaylanınca bilete dönüşür.
    {
        public int BiletNo { get; set; }

        public Sefer sefer;

        public List<Yolcu> Yolcular;

        public OdemeTipi OdemeTipi;
        private decimal ToplamTutar { get; set; }

        public Rezervasyon()
        {
            this.Yolcular = new List<Yolcu>();
        }
        //Bilet numaralarına seçilen koltukların numaraları atandı.
        public Rezervasyon(int BiletNo)
        {
            this.BiletNo = BiletNo;
        }
        public void RezervasyonEkle(Yolcu y)
        {
            Yolcular.Add(y);
            
        }
    }
}
