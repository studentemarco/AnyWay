namespace Mappa
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            ImgPiani = new ImageList(components);
            menuStrip1 = new MenuStrip();
            aggiungiPianoToolStripMenuItem = new ToolStripMenuItem();
            eliminaPianoToolStripMenuItem = new ToolStripMenuItem();
            aPToolStripMenuItem = new ToolStripMenuItem();
            apriCollegaPianiToolStripMenuItem = new ToolStripMenuItem();
            salvaJsonToolStripMenuItem = new ToolStripMenuItem();
            localeToolStripMenuItem = new ToolStripMenuItem();
            apriJsonToolStripMenuItem = new ToolStripMenuItem();
            listViewPiani = new ListView();
            pnlCollegaPiani = new Panel();
            btnChiudiCollega = new Button();
            btnRimuoviCollega = new Button();
            label2 = new Label();
            label1 = new Label();
            btnAggiugiCollega = new Button();
            btnVaiCollega = new Button();
            listViewCollegaPiani = new ListView();
            label3 = new Label();
            menuStrip1.SuspendLayout();
            pnlCollegaPiani.SuspendLayout();
            SuspendLayout();
            // 
            // ImgPiani
            // 
            ImgPiani.ColorDepth = ColorDepth.Depth32Bit;
            ImgPiani.ImageStream = (ImageListStreamer)resources.GetObject("ImgPiani.ImageStream");
            ImgPiani.TransparentColor = Color.Transparent;
            ImgPiani.Images.SetKeyName(0, "reset.png");
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aggiungiPianoToolStripMenuItem, eliminaPianoToolStripMenuItem, aPToolStripMenuItem, apriCollegaPianiToolStripMenuItem, salvaJsonToolStripMenuItem, apriJsonToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 29);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // aggiungiPianoToolStripMenuItem
            // 
            aggiungiPianoToolStripMenuItem.Name = "aggiungiPianoToolStripMenuItem";
            aggiungiPianoToolStripMenuItem.Size = new Size(134, 25);
            aggiungiPianoToolStripMenuItem.Text = "Aggiungi Piano";
            aggiungiPianoToolStripMenuItem.Click += aggiungiPianoToolStripMenuItem_Click;
            // 
            // eliminaPianoToolStripMenuItem
            // 
            eliminaPianoToolStripMenuItem.Name = "eliminaPianoToolStripMenuItem";
            eliminaPianoToolStripMenuItem.Size = new Size(123, 25);
            eliminaPianoToolStripMenuItem.Text = "Elimina Piano";
            eliminaPianoToolStripMenuItem.Click += eliminaPianoToolStripMenuItem_Click;
            // 
            // aPToolStripMenuItem
            // 
            aPToolStripMenuItem.Name = "aPToolStripMenuItem";
            aPToolStripMenuItem.Size = new Size(99, 25);
            aPToolStripMenuItem.Text = "Apri Piano";
            aPToolStripMenuItem.Click += aPToolStripMenuItem_Click;
            // 
            // apriCollegaPianiToolStripMenuItem
            // 
            apriCollegaPianiToolStripMenuItem.Name = "apriCollegaPianiToolStripMenuItem";
            apriCollegaPianiToolStripMenuItem.Size = new Size(154, 25);
            apriCollegaPianiToolStripMenuItem.Text = "Apri Collega Piani";
            apriCollegaPianiToolStripMenuItem.Click += apriCollegaPianiToolStripMenuItem_Click;
            // 
            // salvaJsonToolStripMenuItem
            // 
            salvaJsonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localeToolStripMenuItem });
            salvaJsonToolStripMenuItem.Name = "salvaJsonToolStripMenuItem";
            salvaJsonToolStripMenuItem.Size = new Size(96, 25);
            salvaJsonToolStripMenuItem.Text = "Salva Json";
            // 
            // localeToolStripMenuItem
            // 
            localeToolStripMenuItem.Name = "localeToolStripMenuItem";
            localeToolStripMenuItem.Size = new Size(126, 26);
            localeToolStripMenuItem.Text = "Locale";
            localeToolStripMenuItem.Click += salvaJsonLocale;
            // 
            // apriJsonToolStripMenuItem
            // 
            apriJsonToolStripMenuItem.Name = "apriJsonToolStripMenuItem";
            apriJsonToolStripMenuItem.Size = new Size(88, 25);
            apriJsonToolStripMenuItem.Text = "Apri Json";
            apriJsonToolStripMenuItem.Click += apriJsonToolStripMenuItem_Click;
            // 
            // listViewPiani
            // 
            listViewPiani.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listViewPiani.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewPiani.Location = new Point(12, 63);
            listViewPiani.Name = "listViewPiani";
            listViewPiani.Size = new Size(300, 375);
            listViewPiani.TabIndex = 2;
            listViewPiani.UseCompatibleStateImageBehavior = false;
            listViewPiani.DoubleClick += listViewPiani_DoubleClick;
            // 
            // pnlCollegaPiani
            // 
            pnlCollegaPiani.Controls.Add(btnChiudiCollega);
            pnlCollegaPiani.Controls.Add(btnRimuoviCollega);
            pnlCollegaPiani.Controls.Add(label2);
            pnlCollegaPiani.Controls.Add(label1);
            pnlCollegaPiani.Controls.Add(btnAggiugiCollega);
            pnlCollegaPiani.Controls.Add(btnVaiCollega);
            pnlCollegaPiani.Controls.Add(listViewCollegaPiani);
            pnlCollegaPiani.Location = new Point(386, 32);
            pnlCollegaPiani.Name = "pnlCollegaPiani";
            pnlCollegaPiani.Size = new Size(402, 406);
            pnlCollegaPiani.TabIndex = 3;
            pnlCollegaPiani.Visible = false;
            // 
            // btnChiudiCollega
            // 
            btnChiudiCollega.BackColor = Color.Red;
            btnChiudiCollega.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChiudiCollega.Location = new Point(364, 0);
            btnChiudiCollega.Name = "btnChiudiCollega";
            btnChiudiCollega.Size = new Size(38, 32);
            btnChiudiCollega.TabIndex = 10;
            btnChiudiCollega.Text = "X";
            btnChiudiCollega.UseVisualStyleBackColor = false;
            btnChiudiCollega.Click += btnChiudiCollega_Click;
            // 
            // btnRimuoviCollega
            // 
            btnRimuoviCollega.BackColor = Color.FromArgb(255, 128, 128);
            btnRimuoviCollega.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRimuoviCollega.Location = new Point(84, 36);
            btnRimuoviCollega.Name = "btnRimuoviCollega";
            btnRimuoviCollega.Size = new Size(75, 32);
            btnRimuoviCollega.TabIndex = 9;
            btnRimuoviCollega.Text = "Rimuovi";
            btnRimuoviCollega.UseVisualStyleBackColor = false;
            btnRimuoviCollega.Click += btnRimuoviCollega_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 2);
            label2.Name = "label2";
            label2.Size = new Size(235, 25);
            label2.TabIndex = 8;
            label2.Text = "Collega i piani selezionati";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 226);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 7;
            label1.Text = "Collega";
            // 
            // btnAggiugiCollega
            // 
            btnAggiugiCollega.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAggiugiCollega.Location = new Point(3, 36);
            btnAggiugiCollega.Name = "btnAggiugiCollega";
            btnAggiugiCollega.Size = new Size(75, 32);
            btnAggiugiCollega.TabIndex = 6;
            btnAggiugiCollega.Text = "Aggiungi";
            btnAggiugiCollega.UseVisualStyleBackColor = true;
            btnAggiugiCollega.Click += AggiungiPianoConfigurazione;
            // 
            // btnVaiCollega
            // 
            btnVaiCollega.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVaiCollega.Location = new Point(84, 226);
            btnVaiCollega.Name = "btnVaiCollega";
            btnVaiCollega.Size = new Size(75, 27);
            btnVaiCollega.TabIndex = 5;
            btnVaiCollega.Text = "Vai";
            btnVaiCollega.UseVisualStyleBackColor = true;
            btnVaiCollega.Click += ApriCollega;
            // 
            // listViewCollegaPiani
            // 
            listViewCollegaPiani.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listViewCollegaPiani.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewCollegaPiani.Location = new Point(0, 74);
            listViewCollegaPiani.Name = "listViewCollegaPiani";
            listViewCollegaPiani.Size = new Size(225, 109);
            listViewCollegaPiani.TabIndex = 4;
            listViewCollegaPiani.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 27);
            label3.Name = "label3";
            label3.Size = new Size(62, 30);
            label3.TabIndex = 4;
            label3.Text = "Piani";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(pnlCollegaPiani);
            Controls.Add(listViewPiani);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "Mapforge home";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlCollegaPiani.ResumeLayout(false);
            pnlCollegaPiani.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList ImgPiani;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aggiungiPianoToolStripMenuItem;
        private ToolStripMenuItem eliminaPianoToolStripMenuItem;
        private ToolStripMenuItem aPToolStripMenuItem;
        private ToolStripMenuItem salvaJsonToolStripMenuItem;
        private ToolStripMenuItem apriJsonToolStripMenuItem;
        private ToolStripMenuItem localeToolStripMenuItem;
        private ListView listViewPiani;
        private ToolStripMenuItem apriCollegaPianiToolStripMenuItem;
        private Panel pnlCollegaPiani;
        private ListView listViewCollegaPiani;
        private Button btnVaiCollega;
        private Button btnAggiugiCollega;
        private Button btnRimuoviCollega;
        private Label label2;
        private Label label1;
        private Button btnChiudiCollega;
        private Label label3;
    }
}