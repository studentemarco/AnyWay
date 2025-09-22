using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mappa.Classi
{
    public class Piano
    {
        public string Name { get; set; }
        public int Level { get;set; }
        public List<Segmento> Segmenti { get; set; }
        public List<Punto> Punti { get; set; }

        private byte[] _imgData;


        public Image Img
        {
            get
            {
                return DecodeImage();
            }
            set
            {
                _imgData = CompressImage(value);
            }
        }

        public Piano(string name, List<Segmento> segmenti, List<Punto> punti, Image img, int lv) {
            Name = name;
            Segmenti = segmenti;
            Punti = punti;
            Level = lv;
            Img = img;
        }
        public override string ToString()
        {
            return $"{Name}";
        }


        private byte[] CompressImage(Image img, long quality = 50L)
        {
            if (img == null)
                return null;

            using (var ms = new MemoryStream())
            {
                var encoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(e => e.FormatID == ImageFormat.Jpeg.Guid);
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                // Clona l'immagine per evitare problemi con GDI+
                using (var clone = new Bitmap(img))
                {
                    clone.Save(ms, encoder, encoderParams);
                }

                return ms.ToArray(); // Salva l'immagine compressa come array di byte
            }
        }
        private Image DecodeImage()
        {
            if (_imgData == null || _imgData.Length == 0)
                return null;

            var ms = new MemoryStream(_imgData);
            return Image.FromStream(ms);
        }

        public string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Salva l'immagine nel MemoryStream
                byte[] imageBytes = ms.ToArray(); // Converte l'immagine in byte[]
                return Convert.ToBase64String(imageBytes); // Codifica in Base64
            }
        }

        public List<List<string>> CreaSegmenti(List<Segmento> segmenti)
        {
            List<List<string>> arcs = new List<List<string>>();
            foreach (var segmento in segmenti)
            {
                arcs.Add(segmento.ToList());
            }
            return arcs;
        }
    }
}
