namespace Mappa
{
    partial class Mappatura
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            caricaToolStripMenuItem = new ToolStripMenuItem();
            rimuoviToolStripMenuItem = new ToolStripMenuItem();
            rimuoviPuntoToolStripMenuItem = new ToolStripMenuItem();
            rimuoviSegmentoToolStripMenuItem = new ToolStripMenuItem();
            modalitaToolStripMenuItem = new ToolStripMenuItem();
            segmentoToolStripMenuItem = new ToolStripMenuItem();
            puntoToolStripMenuItem = new ToolStripMenuItem();
            saveConfigToolStripMenuItem = new ToolStripMenuItem();
            cancellaConfiguToolStripMenuItem = new ToolStripMenuItem();
            listBoxPunti = new ListBox();
            listBoxPuntiSeg = new ListBox();
            pnlSegmenti = new Panel();
            label7 = new Label();
            btnRimuoviSegmento = new Button();
            ModificaSegmento = new Button();
            txtLevel = new TextBox();
            panel1 = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            AccessibleNo = new RadioButton();
            chSegmentiContinui = new CheckBox();
            AccessibleYes = new RadioButton();
            panel2 = new Panel();
            label4 = new Label();
            JointNo = new RadioButton();
            JointYes = new RadioButton();
            label1 = new Label();
            btnPuntoMode = new RadioButton();
            btnSegmentoMode = new RadioButton();
            txtNomePiano = new TextBox();
            listBoxSegmenti = new ListBox();
            label2 = new Label();
            btnModificaNomePunto = new Button();
            label3 = new Label();
            txtNomePunto = new TextBox();
            trackDimensioniPunti = new TrackBar();
            pnlPunti = new Panel();
            chkJoint = new CheckBox();
            label6 = new Label();
            btnrimuoviPunto = new Button();
            menuStrip1.SuspendLayout();
            pnlSegmenti.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackDimensioniPunti).BeginInit();
            pnlPunti.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { caricaToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem, saveConfigToolStripMenuItem, cancellaConfiguToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 29);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // caricaToolStripMenuItem
            // 
            caricaToolStripMenuItem.Name = "caricaToolStripMenuItem";
            caricaToolStripMenuItem.Size = new Size(143, 25);
            caricaToolStripMenuItem.Text = "Carica Immagine";
            caricaToolStripMenuItem.Click += caricaToolStripMenuItem_Click;
            // 
            // rimuoviToolStripMenuItem
            // 
            rimuoviToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rimuoviPuntoToolStripMenuItem, rimuoviSegmentoToolStripMenuItem });
            rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            rimuoviToolStripMenuItem.Size = new Size(168, 25);
            rimuoviToolStripMenuItem.Text = "Rimuovi selezionato";
            // 
            // rimuoviPuntoToolStripMenuItem
            // 
            rimuoviPuntoToolStripMenuItem.Name = "rimuoviPuntoToolStripMenuItem";
            rimuoviPuntoToolStripMenuItem.Size = new Size(219, 26);
            rimuoviPuntoToolStripMenuItem.Text = "Rimuovi Punto";
            rimuoviPuntoToolStripMenuItem.Click += rimuoviPuntoToolStripMenuItem_Click;
            // 
            // rimuoviSegmentoToolStripMenuItem
            // 
            rimuoviSegmentoToolStripMenuItem.Name = "rimuoviSegmentoToolStripMenuItem";
            rimuoviSegmentoToolStripMenuItem.Size = new Size(219, 26);
            rimuoviSegmentoToolStripMenuItem.Text = "Rimuovi Segmento";
            rimuoviSegmentoToolStripMenuItem.Click += rimuoviSegmentoToolStripMenuItem_Click;
            // 
            // modalitaToolStripMenuItem
            // 
            modalitaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { segmentoToolStripMenuItem, puntoToolStripMenuItem });
            modalitaToolStripMenuItem.Name = "modalitaToolStripMenuItem";
            modalitaToolStripMenuItem.Size = new Size(87, 25);
            modalitaToolStripMenuItem.Text = "Modalita";
            // 
            // segmentoToolStripMenuItem
            // 
            segmentoToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            segmentoToolStripMenuItem.Name = "segmentoToolStripMenuItem";
            segmentoToolStripMenuItem.Size = new Size(154, 26);
            segmentoToolStripMenuItem.Text = "segmento";
            // 
            // puntoToolStripMenuItem
            // 
            puntoToolStripMenuItem.Name = "puntoToolStripMenuItem";
            puntoToolStripMenuItem.Size = new Size(154, 26);
            puntoToolStripMenuItem.Text = "punto";
            // 
            // saveConfigToolStripMenuItem
            // 
            saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            saveConfigToolStripMenuItem.Size = new Size(174, 25);
            saveConfigToolStripMenuItem.Text = "Salva Configurazione";
            saveConfigToolStripMenuItem.Click += salvaConfigurazioneToolStripMenuItem_Click;
            // 
            // cancellaConfiguToolStripMenuItem
            // 
            cancellaConfiguToolStripMenuItem.Name = "cancellaConfiguToolStripMenuItem";
            cancellaConfiguToolStripMenuItem.Size = new Size(195, 25);
            cancellaConfiguToolStripMenuItem.Text = "Cancella configurazione";
            cancellaConfiguToolStripMenuItem.Click += cancellaConfiguToolStripMenuItem_Click;
            // 
            // listBoxPunti
            // 
            listBoxPunti.FormattingEnabled = true;
            listBoxPunti.ItemHeight = 15;
            listBoxPunti.Location = new Point(0, 28);
            listBoxPunti.Name = "listBoxPunti";
            listBoxPunti.Size = new Size(197, 349);
            listBoxPunti.TabIndex = 3;
            listBoxPunti.SelectedIndexChanged += listPoints_SelectedIndexChanged;
            // 
            // listBoxPuntiSeg
            // 
            listBoxPuntiSeg.FormattingEnabled = true;
            listBoxPuntiSeg.ItemHeight = 15;
            listBoxPuntiSeg.Location = new Point(4, 327);
            listBoxPuntiSeg.Name = "listBoxPuntiSeg";
            listBoxPuntiSeg.Size = new Size(124, 34);
            listBoxPuntiSeg.TabIndex = 5;
            // 
            // pnlSegmenti
            // 
            pnlSegmenti.Controls.Add(label7);
            pnlSegmenti.Controls.Add(btnRimuoviSegmento);
            pnlSegmenti.Controls.Add(ModificaSegmento);
            pnlSegmenti.Controls.Add(txtLevel);
            pnlSegmenti.Controls.Add(panel1);
            pnlSegmenti.Controls.Add(txtNomePiano);
            pnlSegmenti.Controls.Add(listBoxSegmenti);
            pnlSegmenti.Controls.Add(listBoxPuntiSeg);
            pnlSegmenti.Location = new Point(841, 35);
            pnlSegmenti.Name = "pnlSegmenti";
            pnlSegmenti.Size = new Size(131, 746);
            pnlSegmenti.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.25F, FontStyle.Bold);
            label7.Location = new Point(0, 385);
            label7.Name = "label7";
            label7.Size = new Size(136, 25);
            label7.TabIndex = 15;
            label7.Text = "Lista Segmenti";
            // 
            // btnRimuoviSegmento
            // 
            btnRimuoviSegmento.BackColor = Color.Red;
            btnRimuoviSegmento.ForeColor = Color.White;
            btnRimuoviSegmento.Location = new Point(0, 693);
            btnRimuoviSegmento.Name = "btnRimuoviSegmento";
            btnRimuoviSegmento.Size = new Size(64, 38);
            btnRimuoviSegmento.TabIndex = 14;
            btnRimuoviSegmento.Text = "Rimuovi";
            btnRimuoviSegmento.UseVisualStyleBackColor = false;
            btnRimuoviSegmento.Click += btnRimuoviSegmento_Click;
            // 
            // ModificaSegmento
            // 
            ModificaSegmento.BackColor = Color.Blue;
            ModificaSegmento.ForeColor = Color.White;
            ModificaSegmento.Location = new Point(67, 693);
            ModificaSegmento.Name = "ModificaSegmento";
            ModificaSegmento.Size = new Size(64, 38);
            ModificaSegmento.TabIndex = 13;
            ModificaSegmento.Text = "Modifica";
            ModificaSegmento.UseVisualStyleBackColor = false;
            ModificaSegmento.Click += ModificaSegmento_Click;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(4, 32);
            txtLevel.Name = "txtLevel";
            txtLevel.PlaceholderText = "Livello n.";
            txtLevel.Size = new Size(124, 23);
            txtLevel.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnPuntoMode);
            panel1.Controls.Add(btnSegmentoMode);
            panel1.Location = new Point(4, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(124, 260);
            panel1.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(AccessibleNo);
            panel3.Controls.Add(chSegmentiContinui);
            panel3.Controls.Add(AccessibleYes);
            panel3.Location = new Point(0, 177);
            panel3.Name = "panel3";
            panel3.Size = new Size(124, 80);
            panel3.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 37);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 19;
            label5.Text = "È accessibile?";
            // 
            // AccessibleNo
            // 
            AccessibleNo.AutoSize = true;
            AccessibleNo.Location = new Point(72, 54);
            AccessibleNo.Name = "AccessibleNo";
            AccessibleNo.Size = new Size(41, 19);
            AccessibleNo.TabIndex = 18;
            AccessibleNo.Text = "No";
            AccessibleNo.UseVisualStyleBackColor = true;
            // 
            // chSegmentiContinui
            // 
            chSegmentiContinui.AutoSize = true;
            chSegmentiContinui.Font = new Font("Segoe UI", 9F);
            chSegmentiContinui.Location = new Point(30, 0);
            chSegmentiContinui.Name = "chSegmentiContinui";
            chSegmentiContinui.Size = new Size(73, 34);
            chSegmentiContinui.TabIndex = 12;
            chSegmentiContinui.Text = "Modalità\r\ncontinua";
            chSegmentiContinui.UseVisualStyleBackColor = true;
            chSegmentiContinui.CheckedChanged += chSegmentiContinui_CheckedChanged;
            // 
            // AccessibleYes
            // 
            AccessibleYes.AutoSize = true;
            AccessibleYes.Checked = true;
            AccessibleYes.Location = new Point(25, 54);
            AccessibleYes.Name = "AccessibleYes";
            AccessibleYes.Size = new Size(34, 19);
            AccessibleYes.TabIndex = 17;
            AccessibleYes.TabStop = true;
            AccessibleYes.Text = "Si";
            AccessibleYes.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(JointNo);
            panel2.Controls.Add(JointYes);
            panel2.Location = new Point(0, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(124, 80);
            panel2.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 16;
            label4.Text = "Tipologia";
            // 
            // JointNo
            // 
            JointNo.AutoSize = true;
            JointNo.Location = new Point(20, 42);
            JointNo.Name = "JointNo";
            JointNo.Size = new Size(92, 19);
            JointNo.TabIndex = 15;
            JointNo.Text = "Destinazione";
            JointNo.UseVisualStyleBackColor = true;
            // 
            // JointYes
            // 
            JointYes.AutoSize = true;
            JointYes.Checked = true;
            JointYes.Location = new Point(20, 17);
            JointYes.Name = "JointYes";
            JointYes.Size = new Size(59, 19);
            JointYes.TabIndex = 14;
            JointYes.TabStop = true;
            JointYes.Text = "Snodo";
            JointYes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(123, 30);
            label1.TabIndex = 11;
            label1.Text = "Seleziona la modalità\r\ndi inserimento";
            // 
            // btnPuntoMode
            // 
            btnPuntoMode.AutoSize = true;
            btnPuntoMode.Checked = true;
            btnPuntoMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPuntoMode.ForeColor = Color.Black;
            btnPuntoMode.Location = new Point(3, 33);
            btnPuntoMode.Name = "btnPuntoMode";
            btnPuntoMode.Size = new Size(58, 19);
            btnPuntoMode.TabIndex = 7;
            btnPuntoMode.TabStop = true;
            btnPuntoMode.Text = "Punto";
            btnPuntoMode.UseVisualStyleBackColor = true;
            // 
            // btnSegmentoMode
            // 
            btnSegmentoMode.AutoSize = true;
            btnSegmentoMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSegmentoMode.ForeColor = Color.Black;
            btnSegmentoMode.Location = new Point(3, 153);
            btnSegmentoMode.Name = "btnSegmentoMode";
            btnSegmentoMode.Size = new Size(83, 19);
            btnSegmentoMode.TabIndex = 10;
            btnSegmentoMode.Text = "Segmento";
            btnSegmentoMode.UseVisualStyleBackColor = true;
            // 
            // txtNomePiano
            // 
            txtNomePiano.Location = new Point(4, 3);
            txtNomePiano.Name = "txtNomePiano";
            txtNomePiano.PlaceholderText = "Nome piano";
            txtNomePiano.Size = new Size(124, 23);
            txtNomePiano.TabIndex = 7;
            // 
            // listBoxSegmenti
            // 
            listBoxSegmenti.FormattingEnabled = true;
            listBoxSegmenti.ItemHeight = 15;
            listBoxSegmenti.Location = new Point(4, 413);
            listBoxSegmenti.Name = "listBoxSegmenti";
            listBoxSegmenti.Size = new Size(124, 274);
            listBoxSegmenti.TabIndex = 6;
            listBoxSegmenti.SelectedIndexChanged += listBoxSegmenti_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.25F, FontStyle.Bold);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 7;
            label2.Text = "Lista punti";
            // 
            // btnModificaNomePunto
            // 
            btnModificaNomePunto.BackColor = Color.Blue;
            btnModificaNomePunto.Font = new Font("Segoe UI", 9.75F);
            btnModificaNomePunto.ForeColor = Color.White;
            btnModificaNomePunto.Location = new Point(111, 481);
            btnModificaNomePunto.Name = "btnModificaNomePunto";
            btnModificaNomePunto.Size = new Size(77, 29);
            btnModificaNomePunto.TabIndex = 8;
            btnModificaNomePunto.Text = "Modifica";
            btnModificaNomePunto.UseVisualStyleBackColor = false;
            btnModificaNomePunto.Click += btnModificaNomePunto_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.25F, FontStyle.Bold);
            label3.Location = new Point(17, 437);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 9;
            label3.Text = "Modifica punto";
            // 
            // txtNomePunto
            // 
            txtNomePunto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomePunto.Location = new Point(0, 496);
            txtNomePunto.Name = "txtNomePunto";
            txtNomePunto.PlaceholderText = "Nome Punto";
            txtNomePunto.Size = new Size(105, 29);
            txtNomePunto.TabIndex = 10;
            // 
            // trackDimensioniPunti
            // 
            trackDimensioniPunti.Location = new Point(42, 609);
            trackDimensioniPunti.Maximum = 100;
            trackDimensioniPunti.Name = "trackDimensioniPunti";
            trackDimensioniPunti.Size = new Size(104, 45);
            trackDimensioniPunti.TabIndex = 11;
            trackDimensioniPunti.Value = 20;
            trackDimensioniPunti.Scroll += trackDimensioniPunti_Scroll;
            // 
            // pnlPunti
            // 
            pnlPunti.Controls.Add(chkJoint);
            pnlPunti.Controls.Add(label6);
            pnlPunti.Controls.Add(btnrimuoviPunto);
            pnlPunti.Controls.Add(label2);
            pnlPunti.Controls.Add(trackDimensioniPunti);
            pnlPunti.Controls.Add(listBoxPunti);
            pnlPunti.Controls.Add(txtNomePunto);
            pnlPunti.Controls.Add(btnModificaNomePunto);
            pnlPunti.Controls.Add(label3);
            pnlPunti.Location = new Point(12, 38);
            pnlPunti.Name = "pnlPunti";
            pnlPunti.Size = new Size(200, 743);
            pnlPunti.TabIndex = 12;
            // 
            // chkJoint
            // 
            chkJoint.AutoSize = true;
            chkJoint.Font = new Font("Segoe UI", 9F);
            chkJoint.Location = new Point(17, 471);
            chkJoint.Name = "chkJoint";
            chkJoint.Size = new Size(60, 19);
            chkJoint.TabIndex = 16;
            chkJoint.Text = "Snodo";
            chkJoint.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 564);
            label6.Name = "label6";
            label6.Size = new Size(172, 42);
            label6.TabIndex = 15;
            label6.Text = "Modifica dimensione\r\ndi visualizzazione";
            // 
            // btnrimuoviPunto
            // 
            btnrimuoviPunto.BackColor = Color.Red;
            btnrimuoviPunto.ForeColor = Color.White;
            btnrimuoviPunto.Location = new Point(17, 383);
            btnrimuoviPunto.Name = "btnrimuoviPunto";
            btnrimuoviPunto.Size = new Size(164, 28);
            btnrimuoviPunto.TabIndex = 14;
            btnrimuoviPunto.Text = "Rimuovi punto selezionato";
            btnrimuoviPunto.UseVisualStyleBackColor = false;
            btnrimuoviPunto.Click += btnrimuoviPunto_Click;
            // 
            // Mappatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 819);
            Controls.Add(pnlPunti);
            Controls.Add(pnlSegmenti);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            Name = "Mappatura";
            Text = "Modifica del piano";
            FormClosed += Mappatura_FormClosed;
            ClientSizeChanged += Form1_ClientSizeChanged;
            KeyPress += Mappatura_KeyPress;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlSegmenti.ResumeLayout(false);
            pnlSegmenti.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackDimensioniPunti).EndInit();
            pnlPunti.ResumeLayout(false);
            pnlPunti.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem caricaToolStripMenuItem;
        private ListBox listBoxPunti;
        private ToolStripMenuItem rimuoviToolStripMenuItem;
        private ToolStripMenuItem modalitaToolStripMenuItem;
        private ToolStripMenuItem segmentoToolStripMenuItem;
        private ToolStripMenuItem puntoToolStripMenuItem;
        private ListBox listBoxPuntiSeg;
        private Panel pnlSegmenti;
        private ListBox listBoxSegmenti;
        private ToolStripMenuItem rimuoviPuntoToolStripMenuItem;
        private ToolStripMenuItem rimuoviSegmentoToolStripMenuItem;
        private ToolStripMenuItem saveConfigToolStripMenuItem;
        private TextBox txtNomePiano;
        private ToolStripMenuItem cancellaConfiguToolStripMenuItem;
        private TextBox txtLevel;
        private RadioButton btnPuntoMode;
        private RadioButton btnSegmentoMode;
        private Panel panel1;
        private Label label1;
        private CheckBox chSegmentiContinui;
        private Label label2;
        private Button btnModificaNomePunto;
        private Label label3;
        private TextBox txtNomePunto;
        private Label label4;
        private RadioButton JointNo;
        private RadioButton JointYes;
        private TrackBar trackDimensioniPunti;
        private Panel panel3;
        private Panel panel2;
        private Label label5;
        private RadioButton AccessibleNo;
        private RadioButton AccessibleYes;
        private Panel pnlPunti;
        private Button ModificaSegmento;
        private Label label6;
        private Button btnrimuoviPunto;
        private Button btnRimuoviSegmento;
        private CheckBox chkJoint;
        private Label label7;
    }
}
