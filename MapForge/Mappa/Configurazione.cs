using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mappa.Classi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mappa
{
    public partial class Configurazione : Form
    {
        bool cancella = true;
        private Piano piano1;
        private Piano piano2;
        public CollegaPunti collegamento { get; set; }

        private List<CollegaPunti> _collegamenti = new List<CollegaPunti>();
        public Configurazione(Piano piano1, Piano piano2, List<CollegaPunti> collegamenti)
        {
            this.piano1 = piano1;
            this.piano2 = piano2;
            _collegamenti = collegamenti;
            InitializeComponent();
            ConfigureListView();
            AggiungiPunti();
            lblPiano1.Text = "Lista punit di: " + piano1.Name;
            lblPiano2.Text = "Lista punti di: " + piano2.Name;
            chkAB.Text = $"Percorribile da '{piano1.Name}' a '{piano2.Name}'";
            chkBA.Text = $"Percorribile da '{piano2.Name}' a '{piano1.Name}'";
        }

        private void ConfigureListView()
        {
            listvPianiCollegati.View = View.Details;
            listvPianiCollegati.FullRowSelect = true;
            listvPianiCollegati.GridLines = true;
            listvPianiCollegati.Columns.Add(piano1.Name, 85);
            listvPianiCollegati.Columns.Add(piano2.Name, 85);
        }

        private void AggiungiPunti()
        {
            foreach (var punto in piano1.Punti)
            {
                lstPuntiPiano1.Items.Add(punto);
            }
            foreach (var punto in piano2.Punti)
            {
                lstPuntiPiano2.Items.Add(punto);
            }

            foreach (var collegamento in _collegamenti)
            {
                ListViewItem item = new ListViewItem(collegamento.Punto1.Name);
                item.SubItems.Add(collegamento.Punto2.Name);
                listvPianiCollegati.Items.Add(item);
            }

        }

        private void Configura(object sender, EventArgs e)
        {
            try
            {
                if (lstPuntiPiano1.SelectedItems.Count > 0 && lstPuntiPiano2.SelectedItems.Count > 0)
                {
                    if (!string.IsNullOrEmpty(txtPeso.Text))
                    {
                        if (Convert.ToInt32(txtPeso.Text) < 0)
                        {
                            throw new Exception("Il peso deve essere maggiore di 0");
                        }

                        int peso = Convert.ToInt32(txtPeso.Text);

                        collegamento = new CollegaPunti()
                        {
                            Floor1 = piano1.Level,
                            Floor2 = piano2.Level,
                            Punto1 = (Punto)lstPuntiPiano1.SelectedItem!,
                            Punto2 = (Punto)lstPuntiPiano2.SelectedItem!,
                            IsAccessible = btnTipoCollegamentoAscensore.Checked,
                            Peso = peso,
                            Direzione = chkAB.Checked && chkBA.Checked ? 0 : (chkAB.Checked ? 1 : (chkBA.Checked ? 2 : 0))
                        };

                        this.DialogResult = DialogResult.OK;
                        cancella = false;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Inserire un peso");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella configurazione. {ex.Message}");
            }
        }

        private void Configurazione_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancella)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }


        private void btnTipoCollegamentoScala_CheckedChanged(object sender, EventArgs e)
        {
            AggiornaPeso();
        }

        private void btnTipoCollegamentoAscensore_CheckedChanged(object sender, EventArgs e)
        {
            AggiornaPeso();
        }

        private void AggiornaPeso()
        {
            if (btnTipoCollegamentoAscensore.Checked)
            {
                txtPeso.Text = "10";
            }
            else if (btnTipoCollegamentoScala.Checked)
            {
                txtPeso.Text = "40";
            }
        }
    }
}
