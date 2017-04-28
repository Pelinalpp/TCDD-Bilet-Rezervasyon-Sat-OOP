using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcddTren
{
    public class Sefer//hatlar arası fiyatların ve gidiş dönüş nokta-tarihlerinin tutulması için oluşturuldu.
    {
        public DateTime GidisTarih { get; set; }
        public DateTime DonusTarih { get; set; }
        public string Kalkis { get; set; }
        public string Varis { get; set; }

        public string[,] Hat = new string[12, 3] { { "İzmir", "Manisa", "7" }, { "İzmir", "Turgutlu", "12" }, { "İzmir", "Uşak", "18" }, { "Manisa", "İzmir", "7" }, { "Manisa", "Turgutlu", "5" }, { "Manisa", "Uşak", "11" }, { "Turgutlu", "İzmir", "12" }, { "Turgutlu", "Manisa", "5" }, { "Turgutlu", "Uşak", "6" }, { "Uşak", "İzmir", "18" }, { "Uşak", "Manisa", "11" }, { "Uşak", "Turgutlu", "6" } };
    }
}
