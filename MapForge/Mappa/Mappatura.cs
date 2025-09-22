using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Net.Mime;
using System.Drawing.Configuration;
using Mappa.Classi;
using System.Windows.Input;
using System.Security.Policy;


namespace Mappa
{
    public partial class Mappatura : Form
    {
        public Piano piano { get; private set; }
        PictureBox pictureBox;
        Image img;
        Image immagineOriginale;
        List<Punto> listaPunti;
        List<Segmento> listaSegmenti;
        string URL;
        List<int> livelliUtilizzati;
        private List<CollegaPunti> collegamentiPiani;
        int pointSize = 20; // Dimensione del punto da disegnare
        private bool _suppressClosePrompt = false; // Variabile per sopprimere il prompt di chiusura

        public Mappatura(List<int> livelliUtilizzati, List<CollegaPunti> collegamentiPiani = null)
        {
            InitializeComponent();
            inizializzazioneInComune();
            piano = new Piano("", new List<Segmento>(), new List<Punto>(), null, int.MinValue);
            this.livelliUtilizzati = new List<int>(livelliUtilizzati);
            this.collegamentiPiani = collegamentiPiani ?? new List<CollegaPunti>();
            abilitazioneControlli(false);
        }

        public Mappatura(Piano pianoOriginale, List<int> livelliUtilizzati, List<CollegaPunti> collegamentiPiani = null)
        {
            InitializeComponent();
            inizializzazioneInComune();
            piano = new Piano(pianoOriginale.Name,
                     new List<Segmento>(pianoOriginale.Segmenti),
                     new List<Punto>(pianoOriginale.Punti),
                     pianoOriginale.Img, pianoOriginale.Level);
            CaricaPiano();
            this.collegamentiPiani = collegamentiPiani ?? new List<CollegaPunti>();
            txtLevel.Text = piano.Level.ToString();
        }

        private void inizializzazioneInComune()
        {
            this.KeyPreview = true; // Abilita la cattura degli eventi da tastiera da parte del form
            pictureBox = new PictureBox();
            listaPunti = new List<Punto>();
            listaSegmenti = new List<Segmento>();
            //cmbModalita.SelectedIndex = 0;
            DoubleBuffered = true;
            this.livelliUtilizzati = new List<int>();
            this.livelliUtilizzati = livelliUtilizzati;
        }

        private void CaricaPiano()
        {
            immagineOriginale = piano.Img;
            img = new Bitmap(immagineOriginale);

            int altezza = (int)(ClientSize.Height * 0.9);
            int larghezza = (img.Width * altezza) / img.Height;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = img;
            pictureBox.Size = new Size(ClientSize.Width - 220 - 160, (int)(ClientSize.Height * 0.9));
            pictureBox.Location = new Point(220, 44); // margine sinistro
            pictureBox.MouseClick += pctClick;
            pictureBox.MouseWheel += gestioneMouse;
            pictureBox.Visible = true;
            Controls.Add(pictureBox);
            abilitazioneControlli(true);

            txtNomePiano.Text = piano.Name;
            listaPunti = piano.Punti;
            foreach (var punto in piano.Punti)
            {
                listBoxPunti.Items.Add(punto);
            }
            listaSegmenti = piano.Segmenti;
            foreach (var segmento in listaSegmenti)
            {
                listBoxSegmenti.Items.Add(segmento);
            }

            DisegnaPunti();
            DisegnaSegmenti();
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)  //carica immagine della mappa
        {
            if (img != null)
            {
                img.Dispose();
                if (immagineOriginale != null) immagineOriginale.Dispose();
                listaPunti = new List<Punto>();
                listaSegmenti = new List<Segmento>();
                piano = new Piano("", new List<Segmento>(), new List<Punto>(), null, int.MinValue);

                listBoxPunti.Items.Clear();
                listBoxPuntiSeg.Items.Clear();
                listBoxSegmenti.Items.Clear();
                listBoxPunti.ClearSelected();
                listBoxSegmenti.ClearSelected();
                listBoxPuntiSeg.ClearSelected();

                txtNomePiano.Clear();
                txtLevel.Clear();

                btnPuntoMode.Checked = true;
            }

            // Apre la finestra di dialogo per selezionare l'immagine

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Immagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            fileDialog.Title = "Seleziona immagine";

            // Se l'utente seleziona un'immagine, viene renderizzata nel PictureBox

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = fileDialog.FileName;
                URL = imgPath;
                immagineOriginale = Image.FromFile(imgPath);
                img = new Bitmap(immagineOriginale);

                int altezza = (int)(ClientSize.Height * 0.9);
                int larghezza = (img.Width * altezza) / img.Height;
                pictureBox.Size = new Size(ClientSize.Width - 220 - 160, (int)(ClientSize.Height * 0.9));
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = img;
                pictureBox.Location = new Point(220, 44); // margine sinistro
                pictureBox.Visible = true;

                // evita registrazioni multiple dell'evento
                pictureBox.MouseClick -= pctClick;
                pictureBox.MouseClick += pctClick;
                pictureBox.MouseWheel -= gestioneMouse;
                pictureBox.MouseWheel += gestioneMouse;

                // aggiungi il controllo solo se non è già presente
                if (!Controls.Contains(pictureBox))
                    Controls.Add(pictureBox);


                abilitazioneControlli(true);

            }
        }

        private void abilitazioneControlli(bool ablitazione)
        {
            //salvaJSONToolStripMenuItem.Enabled = ablitazione;
            //apriJSONToolStripMenuItem.Enabled = ablitazione;
            rimuoviToolStripMenuItem.Enabled = ablitazione;
            modalitaToolStripMenuItem.Enabled = ablitazione;
            saveConfigToolStripMenuItem.Enabled = ablitazione;
            pnlSegmenti.Visible = ablitazione;
            pnlPunti.Visible = ablitazione;
            MaximizeBox = ablitazione;
            MinimizeBox = ablitazione;
            if (ablitazione) WindowState = FormWindowState.Maximized;
        }

        private void pctClick(object sender, MouseEventArgs e)
        {
            if (immagineOriginale == null) return;

            // Calcola il rapporto di scaling per mantenere le proporzioni
            float ratioX = (float)pictureBox.Width / immagineOriginale.Width;
            float ratioY = (float)pictureBox.Height / immagineOriginale.Height;
            float ratio = Math.Min(ratioX, ratioY);

            // Calcola le dimensioni dell'immagine visualizzata
            int displayWidth = (int)(immagineOriginale.Width * ratio);
            int displayHeight = (int)(immagineOriginale.Height * ratio);

            // Calcola i margini per centrare l'immagine
            int offsetX = (pictureBox.Width - displayWidth) / 2;
            int offsetY = (pictureBox.Height - displayHeight) / 2;

            // Verifica se il click è dentro l'area dell'immagine
            if (e.X < offsetX || e.X >= offsetX + displayWidth ||
                e.Y < offsetY || e.Y >= offsetY + displayHeight)
            {
                return; // Click fuori dall'immagine
            }

            // Converti le coordinate del click in coordinate dell'immagine originale
            int originalX = (int)((e.X - offsetX) / ratio);
            int originalY = (int)((e.Y - offsetY) / ratio);

            // Assicurati che le coordinate siano dentro i limiti dell'immagine
            originalX = Math.Max(0, Math.Min(originalX, immagineOriginale.Width - 1));
            originalY = Math.Max(0, Math.Min(originalY, immagineOriginale.Height - 1));

            Punto PuntoClick = new Punto(new Point(originalX, originalY), TrovaNome(), IsJointSelected());

            if (btnPuntoMode.Checked)
            {
                listaPunti.Add(PuntoClick);
                listBoxPunti.Items.Add(PuntoClick);

                DisegnaPunto(PuntoClick, Brushes.Red);
                pictureBox.Refresh();
            }
            else if (btnSegmentoMode.Checked)
            {
                var listaPuntiOrdinati = listaPunti.OrderBy(p => Distanza(p, PuntoClick)).ToList();
                Punto puntoPiuVicino = listaPuntiOrdinati.First();
                listBoxPuntiSeg.Items.Add(puntoPiuVicino);

                if (listBoxPuntiSeg.Items.Count == 2)
                {
                    if (listBoxPuntiSeg.Items[0] == listBoxPuntiSeg.Items[1])
                    {
                        MessageBox.Show("I punti selezionati sono uguali");
                        listBoxPuntiSeg.Items.Clear();
                        DisegnaPunti();
                        return;
                    }
                    Punto punto1 = listBoxPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listBoxPuntiSeg.Items[1] as Punto;
                    bool esiste = listaSegmenti.Any(segmento =>
                        (segmento.Nome1 + segmento.Nome2 == punto1.Name + punto2.Name) ||
                        (segmento.Nome1 + segmento.Nome2 == punto2.Name + punto1.Name));

                    if (esiste)
                    {
                        MessageBox.Show("Esiste già un segmento con questi punti");
                        listBoxPuntiSeg.Items.Clear();
                        DisegnaPunti();
                        return;
                    }
                    Segmento segTemp = new Segmento(listBoxPuntiSeg.Items[0] as Punto, listBoxPuntiSeg.Items[1] as Punto, IsAccessibleSelected());

                    drawSegment();

                    listBoxSegmenti.Items.Add(segTemp);
                    listaSegmenti.Add(segTemp);
                    listBoxPuntiSeg.Items.Clear();

                    if (chSegmentiContinui.Checked)
                    {
                        listBoxPuntiSeg.Items.Add(punto2);
                        DisegnaPunto(punto2, Brushes.Green);
                        pictureBox.Refresh();
                    }
                }
                else
                {
                    DisegnaPunto(puntoPiuVicino, Brushes.Green);
                    pictureBox.Refresh();
                }
            }
        }

        public bool IsJointSelected()
        {
            if (JointYes.Checked) return true;
            else return false;
        }

        public bool IsAccessibleSelected()
        {
            if (AccessibleYes.Checked) return true;
            else return false;
        }

        public string TrovaNome()
        {
            string nome;
            int indice = 1;
            do
            {
                nome = string.Empty;
                int tempIndice = indice;

                // Converte l'indice in un nome alfabetico
                while (tempIndice > 0)
                {
                    tempIndice--;
                    nome = (char)('A' + (tempIndice % 26)) + nome;
                    tempIndice /= 26;
                }

                indice++;
            }
            while (listaPunti.Any(x => x.Name == nome));

            return nome;
        }

        private void DisegnaPunto(Punto punto, Brush colore)
        {
            using (Graphics gpr = Graphics.FromImage(img))
            {
                //int pointSize = 70; // Dimensione del punto da disegnare
                if (punto.IsJoint)
                {
                    // Disegna un cerchio
                    gpr.FillEllipse(colore, punto.CordinatePunti.X - pointSize / 2, punto.CordinatePunti.Y - pointSize / 2, pointSize, pointSize);
                }
                else
                {
                    // Disegna un quadrato
                    gpr.FillRectangle(colore, punto.CordinatePunti.X - pointSize / 2, punto.CordinatePunti.Y - pointSize / 2, pointSize, pointSize);
                }

                // Calcolo proporzionale del font rispetto al punto
                float fontSize = (60f / 70f) * pointSize;
                float offsetY = (10f / 70f) * pointSize;


                using (Font font = new Font("Arial", fontSize, FontStyle.Bold))
                {
                    gpr.DrawString(punto.Name, font, Brushes.Black, new PointF(punto.CordinatePunti.X, punto.CordinatePunti.Y - offsetY));
                }
            }
        }

        private void drawSegment()
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                if (listBoxPuntiSeg.Items.Count == 2)
                {
                    Punto punto1 = listBoxPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listBoxPuntiSeg.Items[1] as Punto;

                    // Trova il segmento corrispondente nella lista, se già esiste
                    Segmento segmento = listaSegmenti.FirstOrDefault(s =>
                        (s.punto1 == punto1 && s.punto2 == punto2) ||
                        (s.punto1 == punto2 && s.punto2 == punto1));

                    // Se non esiste ancora, usa il valore di accessibilità selezionato
                    bool isAccessible = segmento != null ? segmento.IsAccessible : IsAccessibleSelected();

                    Color colore = isAccessible ? Color.Green : Color.Orange;

                    // Spessore proporzionale alla dimensione dei punti
                    int penWidth = Math.Max(2, pointSize / 4);

                    using (Pen pen = new Pen(colore, penWidth))
                    {
                        g.DrawLine(pen, punto1.CordinatePunti, punto2.CordinatePunti);
                    }
                }
            }

            DisegnaPunti();
        }


        private float Distanza(Punto p1, Punto p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.CordinatePunti.X - p2.CordinatePunti.X, 2) + Math.Pow(p1.CordinatePunti.Y - p2.CordinatePunti.Y, 2));
        }

        private void DisegnaPunti()
        {
            using (Graphics gpr = Graphics.FromImage(img))
            {
                // Disegna ogni punto dalla lista
                foreach (Punto p in listaPunti)
                {
                    //DisegnaPunto(p.CordinatePunti.X, p.CordinatePunti.Y, p.Name, Brushes.Red);
                    DisegnaPunto(p, Brushes.Red);
                }
            }

            pictureBox.Image = img;
            DisegnaCollegamentiPiani();
            pictureBox.Refresh();
        }

        public void DisegnaSegmenti()
        {
            using (Graphics gpr = Graphics.FromImage(img))
            {
                foreach (Segmento segmento in listaSegmenti)
                {
                    // Verde se accessibile, arancione se non accessibile
                    Color colore = segmento.IsAccessible ? Color.Green : Color.Orange;

                    // Spessore proporzionale alla dimensione dei punti
                    int penWidth = Math.Max(2, pointSize / 4);

                    using (Pen pen = new Pen(colore, penWidth))
                    {
                        gpr.DrawLine(pen, segmento.punto1.CordinatePunti, segmento.punto2.CordinatePunti);
                    }
                }
            }

            pictureBox.Image = img;
            pictureBox.Refresh();
        }


        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void apriJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON|*.json";
                openFileDialog.Title = "Apri file JSON";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    string destinazioneCartella = "C:\\Users\\gamba.21149\\source\\repos\\Mappa1\\Mappa\\bin\\Debug\\net8.0-windows";
                    if (File.Exists(fileName) && Directory.Exists(destinazioneCartella))
                    {
                        string nomeFile = Path.GetFileName(fileName);
                        string destinazioneCompleta = Path.Combine(destinazioneCartella, nomeFile);
                        File.Move(fileName, destinazioneCompleta);
                        if (File.Exists(destinazioneCompleta))
                        {
                            MessageBox.Show("File spostato correttamente in:\n" + destinazioneCartella);
                        }
                        else
                        {
                            throw new Exception("Impossibile spostare il file.");
                        }
                    }
                    else
                    {
                        throw new Exception("Percorso non valido.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            try
            {
                int altezza = (int)(ClientSize.Height * 0.9);
                int larghezza = (img.Width * altezza) / img.Height;
                pictureBox.Size = new Size(ClientSize.Width - 220 - 160, (int)(ClientSize.Height * 0.9));
                pictureBox.Location = new Point(220, 44); // margine sinistro
                pnlSegmenti.Location = new Point(ClientSize.Width - 160, 37);

                DisegnaPunti(); // Ridisegna i punti quando la finestra viene ridimensionata

                pictureBox.Image = img;
            }
            catch { }
        }

        private void rimuoviPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxPunti.SelectedItems.Count >= 1)
                {
                    int index = listBoxPunti.SelectedIndex;
                    Punto puntoRimuovere = listBoxPunti.Items[index] as Punto;

                    listBoxPunti.Items.RemoveAt(index);
                    listaPunti.Remove(puntoRimuovere);
                    listaSegmenti.RemoveAll(seg => seg.Nome1 == puntoRimuovere.Name || seg.Nome2 == puntoRimuovere.Name);
                    listBoxSegmenti.Items.Clear();
                    foreach (Segmento segmento in listaSegmenti)
                    {
                        listBoxSegmenti.Items.Add(segmento);
                    }
                    Bitmap immagineOrg = new Bitmap(immagineOriginale);
                    img = immagineOrg;

                    DisegnaSegmenti();
                    DisegnaPunti();

                    pictureBox.Image = img;
                }
                else
                {
                    throw new Exception("Seleziona almeno un punto da rimuovere");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella rimozione dalla punto. Errore: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void rimuoviSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxSegmenti.SelectedItems.Count > 0)
                {
                    Segmento segmentoSelezionato = (Segmento)listBoxSegmenti.SelectedItem;
                    listaSegmenti.Remove(segmentoSelezionato);
                    listBoxSegmenti.Items.RemoveAt(listBoxSegmenti.SelectedIndex);

                    Bitmap immagineOrg = new Bitmap(immagineOriginale);
                    img = immagineOrg;

                    DisegnaPunti();
                    DisegnaSegmenti();

                    pictureBox.Image = img;
                }
                else
                {
                    throw new Exception("Seleziona almeno un segmento da rimuovere");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void salvaConfigurazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomePiano.Text.Length > 0)
                {
                    if (!string.IsNullOrEmpty(txtLevel.Text))
                    {
                        int livelloPiano = Convert.ToInt32(txtLevel.Text);

                        if (!livelliUtilizzati.Contains(livelloPiano))
                        {
                            piano.Name = txtNomePiano.Text;
                            piano.Punti = new List<Punto>(listaPunti);
                            piano.Segmenti = new List<Segmento>(listaSegmenti);
                            piano.Img = immagineOriginale;
                            piano.Level = Convert.ToInt32(txtLevel.Text);
                            _suppressClosePrompt = true;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else throw new Exception("Piano già utlizzato cambiare il valore.");
                    }
                    else throw new Exception("INserisci il livello del piano");
                }
                else
                    throw new Exception("Inserisci il nome del piano");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella salvataggio della configurazione. Errore: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void listPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            Punto puntoSelezionato = listBoxPunti.SelectedItem as Punto;

            if (puntoSelezionato != null)
            {
                DisegnaPunti();
                DisegnaPunto(puntoSelezionato, Brushes.Blue);
                pictureBox.Refresh();

                txtNomePunto.Enabled = true;
                btnModificaNomePunto.Enabled = true;
                chkJoint.Enabled = true;
                txtNomePunto.Text = puntoSelezionato.Name;
                if (puntoSelezionato.IsJoint) chkJoint.Checked = true;
                else chkJoint.Checked = false;
            }
        }

        private void cancellaConfiguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Mappatura_FormClosed(object sender, FormClosedEventArgs e)
        {
            listaPunti.Clear();
            listaSegmenti.Clear();
            listBoxPunti.Items.Clear();
            listBoxPuntiSeg.Items.Clear();
            listBoxSegmenti.Items.Clear();
            if (img != null)
            {
                img.Dispose();
                immagineOriginale.Dispose();
            }
        }

        private void chSegmentiContinui_CheckedChanged(object sender, EventArgs e)
        {
            if (!chSegmentiContinui.Checked)
            {
                listBoxPuntiSeg.Items.Clear();
                DisegnaPunti();
                pictureBox.Refresh();
            }
        }

        private void Mappatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                listBoxPuntiSeg.Items.Clear();
                refresh();
            }
        }

        private void btnModificaNomePunto_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxPunti.SelectedItems.Count > 0)
                {
                    string nomePunto = txtNomePunto.Text.Trim();

                    if (string.IsNullOrWhiteSpace(nomePunto))
                        return;

                    bool giaEsistente = false;
                    if (nomePunto == (listBoxPunti.SelectedItem as Punto).Name)
                    {
                        giaEsistente = false;
                    }
                    else
                    {
                        giaEsistente = listaPunti.Any(x => x.Name == nomePunto);
                    }

                    if (!giaEsistente)
                    {
                        Punto vecchioPunto = listBoxPunti.SelectedItem as Punto;
                        Punto nuovoPunto = new Punto(vecchioPunto.CordinatePunti, nomePunto, chkJoint.Checked);

                        listaPunti.Remove(vecchioPunto);
                        listaPunti.Add(nuovoPunto);

                        for (int i = 0; i < listaSegmenti.Count; i++)
                        {
                            Segmento seg = listaSegmenti[i];
                            if (seg.punto1 == vecchioPunto || seg.punto2 == vecchioPunto)
                            {
                                Punto punto1 = (seg.punto1 == vecchioPunto) ? nuovoPunto : seg.punto1;
                                Punto punto2 = (seg.punto2 == vecchioPunto) ? nuovoPunto : seg.punto2;
                                Segmento nuovoSegmento = new Segmento(punto1, punto2, seg.IsAccessible);

                                listaSegmenti[i] = nuovoSegmento;
                            }
                        }

                        listBoxPunti.Items.Clear();
                        listBoxSegmenti.Items.Clear();

                        foreach (var punto in listaPunti)
                        {
                            listBoxPunti.Items.Add(punto);
                        }

                        foreach (var segmento in listaSegmenti)
                        {
                            listBoxSegmenti.Items.Add(segmento);
                        }

                        Bitmap immagineOrg = new Bitmap(immagineOriginale);
                        img = immagineOrg;

                        DisegnaSegmenti();
                        DisegnaPunti();
                        pictureBox.Image = img;

                        txtNomePunto.Text = "";
                        chkJoint.Checked = false;
                        chkJoint.Enabled = false;
                        txtNomePunto.Enabled = false;
                        btnModificaNomePunto.Enabled = false;
                        listBoxPunti.ClearSelected();
                    }
                    else throw new Exception("Nome del punto gia usato");
                }
                else
                    throw new Exception("Nessun punto selezionato");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella modifica del nome del punto.{ex.Message}");
            }
        }


        /*private double _zoomLevel = 1.0;
        private int _originalWidth;
        private int _originalHeight;*/

        private void gestioneMouse(object sender, MouseEventArgs e)
        {
            /*if (e.Delta > 0) // Rotellina verso l'alto
            {
                _zoomLevel += 0.1;
            }
            else if (e.Delta < 0) // Rotellina verso il basso
            {
                _zoomLevel -= 0.1;
            }
            if (_zoomLevel < 0.1) _zoomLevel = 0.1;
            if (_zoomLevel > 3.0) _zoomLevel = 3.0;

            int newWidth = (int)(_originalWidth * _zoomLevel);
            int newHeight = (int)(_originalHeight * _zoomLevel);

            pictureBox.Width = newWidth;
            pictureBox.Height = newHeight;
            pictureBox.Image = ResizeImage((Bitmap)pictureBox.Image, newWidth, newHeight);*/
        }

        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(image);
            Graphics graphics = Graphics.FromImage(resizedImage);
            graphics.DrawImage(image, 0, 0, width, height);
            graphics.Dispose();
            return resizedImage;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DisegnaCollegamentiPiani()
        {
            if (collegamentiPiani == null) return;

            using (Graphics g = Graphics.FromImage(img))
            {
                foreach (var collegamento in collegamentiPiani)
                {
                    // Se il collegamento riguarda questo piano
                    if (collegamento.Floor1 == piano.Level || collegamento.Floor2 == piano.Level)
                    {
                        // Prendi il punto del piano corrente
                        Punto punto = collegamento.Floor1 == piano.Level ? collegamento.Punto1 : collegamento.Punto2;


                        int size = pointSize;
                        int x = punto.CordinatePunti.X - size / 2;
                        int y = punto.CordinatePunti.Y - size / 2;

                        if (collegamento.IsAccessible)
                        {
                            // Rettangolo per ascensore
                            g.FillRectangle(Brushes.BlueViolet, x, y, size, size);
                        }
                        else
                        {
                            // Triangolo per scala
                            Point[] triangle = new Point[]
                            {
                        new Point(x + size / 2, y),           // top
                        new Point(x, y + size),               // bottom left
                        new Point(x + size, y + size)         // bottom right
                            };
                            g.FillPolygon(Brushes.BlueViolet, triangle);
                        }
                    }
                }
            }
        }

        private void listBoxSegmenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            Segmento segmentoSelezionato = listBoxSegmenti.SelectedItem as Segmento;
            if (segmentoSelezionato != null)
            {
                //colora il segmento selezionato di blu
                DisegnaSegmenti();
                using (Graphics g = Graphics.FromImage(img))
                {
                    Color colore = Color.Blue;
                    int penWidth = Math.Max(2, pointSize / 4);
                    using (Pen pen = new Pen(colore, penWidth))
                    {
                        g.DrawLine(pen, segmentoSelezionato.punto1.CordinatePunti, segmentoSelezionato.punto2.CordinatePunti);
                    }
                }
                DisegnaPunti();
                pictureBox.Refresh();
            }
        }

        private void ModificaSegmento_Click(object sender, EventArgs e)
        {
            if (listBoxSegmenti.SelectedItem is Segmento segmento)
            {
                Segmento temp = segmento.Clone();
                using (var form = new ModificaSegmento(temp))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        segmento.IsAccessible = form.IsAccessible;
                        segmento.Difficolta.AtoB_open = form.AtoB_Open;
                        segmento.Difficolta.BtoA_open = form.BtoA_Open;
                        segmento.Difficolta.AtoB_fattore = form.AtoB_Fattore;
                        segmento.Difficolta.BtoA_fattore = form.BtoA_Fattore;

                        //MessageBox con tutte le variabili cambiate
                        //MessageBox.Show($"IsAccessible: {segmento.IsAccessible}\nAtoB_open: {segmento.Difficolta.AtoB_open}\nBtoA_open: {segmento.Difficolta.BtoA_open}\nAtoB_fattore: {segmento.Difficolta.AtoB_fattore}\nBtoA_fattore: {segmento.Difficolta.BtoA_fattore}");
                        
                        img = new Bitmap(immagineOriginale);
                        DisegnaSegmenti();
                        DisegnaPunti();
                        pictureBox.Image = img;

                    }
                }
            }
            listBoxSegmenti.SelectedItem = null;
        }

        private void trackDimensioniPunti_Scroll(object sender, EventArgs e)
        {
            // Aggiorna la dimensione del punto in base allo slider
            int dimensione = trackDimensioniPunti.Value;
            if (dimensione < 10) dimensione = 10;
            else if (dimensione > 200) dimensione = 200;
            pointSize = dimensione;

            // Riparti sempre dall'immagine originale
            img = new Bitmap(immagineOriginale);

            // Ridisegna i segmenti prima dei punti
            DisegnaSegmenti();

            // Ridisegna i punti con la nuova dimensione
            foreach (Punto p in listaPunti)
            {
                DisegnaPunto(p, Brushes.Red);
            }

            DisegnaCollegamentiPiani();

            pictureBox.Image = img;
            pictureBox.Refresh();
        }


        private void btnrimuoviPunto_Click(object sender, EventArgs e)
        {
            rimuoviPuntoToolStripMenuItem_Click(sender, e);

        }

        private void btnRimuoviSegmento_Click(object sender, EventArgs e)
        {
            rimuoviSegmentoToolStripMenuItem_Click(sender, e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Se il flag è impostato, salto il prompt (chiusura dovuta a salvataggio)
            if (!_suppressClosePrompt && e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Eventuali modifiche non salvate saranno perse.\nVuoi davvero uscire?",
                    "Attenzione",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }
    }
}

