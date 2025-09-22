using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing; // Aggiunto per gestire le immagini
using System.IO;
using System.Linq;

namespace Mappa.Classi
{
    public class SalvaJson
    {
        public List<SavePiano> piani { get; set; } = new List<SavePiano>();
        public List<CollegaPunti> floorConnection { get; set; } = new List<CollegaPunti>();
    }

    public class SavePiano()
    {

        public string Name { get; set; }
        public int Level { get; set; } 
        public string image { get; set; }
        public List<List<string>> arcs { get; set; } = new List<List<string>>();
        public List<Punto> points { get; set; } = new List<Punto>();
        public string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Salva l'immagine nel MemoryStream
                byte[] imageBytes = ms.ToArray(); // Converte l'immagine in byte[]
                return Convert.ToBase64String(imageBytes); // Codifica in Base64
            }
        }

        public List<Segmento> CreaSegmenti(List<List<string>> lista)
        {
            var segmenti = new List<Segmento>();

            foreach (var item in lista)
            {
                if (item.Count != 8 && item.Count != 4)
                    continue;

                string nome1 = item[0];
                string nome2 = item[1];
                if (!double.TryParse(item[2], out double peso))
                    peso = 0; // oppure gestisci errore


                Punto punto1 = points.FirstOrDefault(p => p.Name == nome1);
                Punto punto2 = points.FirstOrDefault(p => p.Name == nome2);

                bool accessible = item[3].ToLower() == "true";
                DifficoltaSegmento difficolta = new DifficoltaSegmento();

                if (item.Count == 4)
                {
                }
                else if (item.Count == 8)
                {
                    bool AtoB_open = item[4].ToLower() == "true";
                    bool BtoA_open = item[5].ToLower() == "true";
                    if (!double.TryParse(item[6], out double AtoB_fattore))
                        AtoB_fattore = 1; // oppure gestisci errore
                    if (!double.TryParse(item[7], out double BtoA_fattore))
                        BtoA_fattore = 1; // oppure gestisci errore

                    difficolta.AtoB_open = AtoB_open;
                    difficolta.BtoA_open = BtoA_open;
                    difficolta.AtoB_fattore = AtoB_fattore;
                    difficolta.BtoA_fattore = BtoA_fattore;
                }
                else
                    continue; // oppure throw exception


                segmenti.Add(new Segmento(punto1, punto2, accessible, difficolta));
            }
            return segmenti;
        }
    }

    public class LoadJson()
    {
        public List<Piano> piani { get; set; } = new List<Piano>();
        public List<CollegaPunti> collegamenti { get; set; } = new List<CollegaPunti> { };
    }
}
