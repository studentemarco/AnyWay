using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa.Classi
{
    public class Punto
    {
        public string Name { get; set; }

        public Point CordinatePunti { get; set; }

        public bool IsJoint { get; set; }

        public Punto() { }

        public Punto(Point punto, string name)
        {
            CordinatePunti = punto;
            Name = name;
        }
        public Punto(Point punto, string name, bool joint)
        {
            CordinatePunti = punto;
            Name = name;
            IsJoint = joint;
        }
        public override string ToString()
        {
            return $"Punto: {Name}";
        }
    }
}
