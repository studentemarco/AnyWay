using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa.Classi
{
    public class Segmento
    {
        public string Nome1 { get; set; }
        public string Nome2 { get; set; }
        public double Peso { get; set; }
        public Punto punto1 { get; set; }
        public Punto punto2 { get; set; }
        public bool IsAccessible { get; set; }
        public DifficoltaSegmento Difficolta { get; set; } = new DifficoltaSegmento();
        public Segmento() { }
        public Segmento(Punto P1, Punto P2)
        {
            punto1 = P1;
            punto2 = P2;
            Nome1 = P1.Name;
            Nome2 = P2.Name;
            Peso = Math.Sqrt(Math.Pow(P1.CordinatePunti.X - P2.CordinatePunti.X, 2) + Math.Pow(P1.CordinatePunti.Y - P2.CordinatePunti.Y, 2));
        }
        public Segmento(Punto P1, Punto P2, bool accessible)
        {
            punto1 = P1;
            punto2 = P2;
            Nome1 = P1.Name;
            Nome2 = P2.Name;
            Peso = Math.Sqrt(Math.Pow(P1.CordinatePunti.X - P2.CordinatePunti.X, 2) + Math.Pow(P1.CordinatePunti.Y - P2.CordinatePunti.Y, 2));
            IsAccessible = accessible;
        }
        public Segmento(Punto P1, Punto P2, bool accessible, DifficoltaSegmento difficolta)
        {
            punto1 = P1;
            punto2 = P2;
            Nome1 = P1.Name;
            Nome2 = P2.Name;
            Peso = Math.Sqrt(Math.Pow(P1.CordinatePunti.X - P2.CordinatePunti.X, 2) + Math.Pow(P1.CordinatePunti.Y - P2.CordinatePunti.Y, 2));
            IsAccessible = accessible;
            Difficolta = difficolta;
        }

        public Segmento Clone()
        {
            return new Segmento
            {
                Peso = this.Peso,
                IsAccessible = this.IsAccessible,
                punto1 = this.punto1,
                punto2 = this.punto2,
                Difficolta = new DifficoltaSegmento
                {
                    AtoB_open = this.Difficolta.AtoB_open,
                    BtoA_open = this.Difficolta.BtoA_open,
                    AtoB_fattore = this.Difficolta.AtoB_fattore,
                    BtoA_fattore = this.Difficolta.BtoA_fattore
                }
            };
        }


        public override string ToString()
        {
            return $"'{Nome1}'-'{Nome2}'";
        }

        public List<string> ToList()
        {
            List<string> ciao = new List<string>();
            ciao.Add(Nome1);
            ciao.Add(Nome2);
            ciao.Add(Peso.ToString());
            ciao.Add(IsAccessible.ToString());
            ciao.Add(Difficolta.AtoB_open.ToString());
            ciao.Add(Difficolta.BtoA_open.ToString());
            ciao.Add(Difficolta.AtoB_fattore.ToString());
            ciao.Add(Difficolta.BtoA_fattore.ToString());
            return ciao;
        }
    }
}
