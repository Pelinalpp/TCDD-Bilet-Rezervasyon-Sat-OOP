using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Kisi//Yolcu bilgileri tanımlamak için oluşturuldu.
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public ulong TcKimlikNo { get; set; }
        public decimal Puan { get; set; }
    }
}
