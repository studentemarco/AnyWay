using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa.Classi
{
    public class LoaderPiani
    {
        public LoadJson LoadFromJson(string jsonContent)
        {
            // Deserializza il JSON nella struttura SaveJson
            SalvaJson savedData = JsonConvert.DeserializeObject<SalvaJson>(jsonContent)!;

            LoadJson loadJson = new LoadJson();

            foreach (var savePiano in savedData.piani)
            {
                // Converti l'immagine da Base64 a Image
                Image img = null;
                if (!string.IsNullOrEmpty(savePiano.image))
                {
                    byte[] imageBytes = Convert.FromBase64String(savePiano.image);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        img = Image.FromStream(ms);
                    }
                }

                List<Segmento> segmenti  = savePiano.CreaSegmenti(savePiano.arcs);

                // Crea un nuovo Piano con i dati convertiti
                Piano piano = new Piano(
                    name: savePiano.Name,
                    segmenti: segmenti,  // Nota: arcs nel SavePiano corrisponde a Segmenti in Piano
                    punti: savePiano.points,    // points nel SavePiano corrisponde a Punti in Piano
                    img: img,
                    lv: savePiano.Level
                );

                loadJson.piani.Add(piano);
            }

            loadJson.collegamenti = savedData.floorConnection;

            return loadJson;
        }
    }
}
