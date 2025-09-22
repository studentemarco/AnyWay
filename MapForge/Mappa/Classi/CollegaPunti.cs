using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa.Classi
{
    public class CollegaPunti
    {
        public int Floor1 { get; set; }
        public int Floor2 { get; set; }
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }
        public bool IsAccessible { get; set; }
        public int Peso { get; set; }
        public int Direzione { get; set; } // 0 = entrambi, 1 = da Floor1 a Floor2, 2 = da Floor2 a Floor1
    }
}
