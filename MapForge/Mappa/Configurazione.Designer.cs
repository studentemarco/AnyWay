namespace Mappa
{
    partial class Configurazione
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
            lstPuntiPiano1 = new ListBox();
            lstPuntiPiano2 = new ListBox();
            lblPiano1 = new Label();
            lblPiano2 = new Label();
            listvPianiCollegati = new ListView();
            label3 = new Label();
            btn_collega = new Button();
            txtPeso = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            chkBA = new CheckBox();
            chkAB = new CheckBox();
            label4 = new Label();
            label2 = new Label();
            btnTipoCollegamentoAscensore = new RadioButton();
            btnTipoCollegamentoScala = new RadioButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstPuntiPiano1
            // 
            lstPuntiPiano1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstPuntiPiano1.FormattingEnabled = true;
            lstPuntiPiano1.ItemHeight = 21;
            lstPuntiPiano1.Location = new Point(12, 47);
            lstPuntiPiano1.Name = "lstPuntiPiano1";
            lstPuntiPiano1.Size = new Size(250, 403);
            lstPuntiPiano1.TabIndex = 0;
            // 
            // lstPuntiPiano2
            // 
            lstPuntiPiano2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstPuntiPiano2.FormattingEnabled = true;
            lstPuntiPiano2.ItemHeight = 21;
            lstPuntiPiano2.Location = new Point(321, 47);
            lstPuntiPiano2.Name = "lstPuntiPiano2";
            lstPuntiPiano2.Size = new Size(250, 403);
            lstPuntiPiano2.TabIndex = 1;
            // 
            // lblPiano1
            // 
            lblPiano1.AutoSize = true;
            lblPiano1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPiano1.Location = new Point(12, 9);
            lblPiano1.Name = "lblPiano1";
            lblPiano1.Size = new Size(78, 32);
            lblPiano1.TabIndex = 2;
            lblPiano1.Text = "label1";
            // 
            // lblPiano2
            // 
            lblPiano2.AutoSize = true;
            lblPiano2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPiano2.Location = new Point(321, 9);
            lblPiano2.Name = "lblPiano2";
            lblPiano2.Size = new Size(78, 32);
            lblPiano2.TabIndex = 3;
            lblPiano2.Text = "label2";
            // 
            // listvPianiCollegati
            // 
            listvPianiCollegati.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listvPianiCollegati.Location = new Point(613, 47);
            listvPianiCollegati.Name = "listvPianiCollegati";
            listvPianiCollegati.Size = new Size(374, 193);
            listvPianiCollegati.TabIndex = 4;
            listvPianiCollegati.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(613, 9);
            label3.Name = "label3";
            label3.Size = new Size(172, 25);
            label3.TabIndex = 5;
            label3.Text = "Punti già collegati";
            // 
            // btn_collega
            // 
            btn_collega.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_collega.Location = new Point(613, 424);
            btn_collega.Name = "btn_collega";
            btn_collega.Size = new Size(172, 38);
            btn_collega.TabIndex = 6;
            btn_collega.Text = "Collega";
            btn_collega.UseVisualStyleBackColor = true;
            btn_collega.Click += Configura;
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPeso.Location = new Point(59, 48);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(113, 29);
            txtPeso.TabIndex = 7;
            txtPeso.Text = "40";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 52);
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 8;
            label1.Text = "Peso";
            // 
            // panel1
            // 
            panel1.Controls.Add(chkBA);
            panel1.Controls.Add(chkAB);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnTipoCollegamentoAscensore);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPeso);
            panel1.Controls.Add(btnTipoCollegamentoScala);
            panel1.Location = new Point(613, 246);
            panel1.Name = "panel1";
            panel1.Size = new Size(374, 172);
            panel1.TabIndex = 9;
            // 
            // chkBA
            // 
            chkBA.AutoSize = true;
            chkBA.Checked = true;
            chkBA.CheckState = CheckState.Checked;
            chkBA.Location = new Point(5, 147);
            chkBA.Name = "chkBA";
            chkBA.Size = new Size(132, 19);
            chkBA.TabIndex = 12;
            chkBA.Text = "Percorribile da A a B";
            chkBA.UseVisualStyleBackColor = true;
            // 
            // chkAB
            // 
            chkAB.AutoSize = true;
            chkAB.Checked = true;
            chkAB.CheckState = CheckState.Checked;
            chkAB.Location = new Point(5, 122);
            chkAB.Name = "chkAB";
            chkAB.Size = new Size(132, 19);
            chkAB.TabIndex = 11;
            chkAB.Text = "Percorribile da A a B";
            chkAB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 98);
            label4.Name = "label4";
            label4.Size = new Size(162, 15);
            label4.TabIndex = 10;
            label4.Text = "Il collegamento è accessibile?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(162, 15);
            label2.TabIndex = 9;
            label2.Text = "Il collegamento è accessibile?";
            // 
            // btnTipoCollegamentoAscensore
            // 
            btnTipoCollegamentoAscensore.AutoSize = true;
            btnTipoCollegamentoAscensore.Location = new Point(90, 24);
            btnTipoCollegamentoAscensore.Name = "btnTipoCollegamentoAscensore";
            btnTipoCollegamentoAscensore.Size = new Size(34, 19);
            btnTipoCollegamentoAscensore.TabIndex = 1;
            btnTipoCollegamentoAscensore.TabStop = true;
            btnTipoCollegamentoAscensore.Text = "Si";
            btnTipoCollegamentoAscensore.UseVisualStyleBackColor = true;
            btnTipoCollegamentoAscensore.CheckedChanged += btnTipoCollegamentoAscensore_CheckedChanged;
            // 
            // btnTipoCollegamentoScala
            // 
            btnTipoCollegamentoScala.AutoSize = true;
            btnTipoCollegamentoScala.Checked = true;
            btnTipoCollegamentoScala.Location = new Point(3, 24);
            btnTipoCollegamentoScala.Name = "btnTipoCollegamentoScala";
            btnTipoCollegamentoScala.Size = new Size(41, 19);
            btnTipoCollegamentoScala.TabIndex = 0;
            btnTipoCollegamentoScala.TabStop = true;
            btnTipoCollegamentoScala.Text = "No";
            btnTipoCollegamentoScala.UseVisualStyleBackColor = true;
            btnTipoCollegamentoScala.CheckedChanged += btnTipoCollegamentoScala_CheckedChanged;
            // 
            // Configurazione
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 513);
            Controls.Add(panel1);
            Controls.Add(btn_collega);
            Controls.Add(label3);
            Controls.Add(listvPianiCollegati);
            Controls.Add(lblPiano2);
            Controls.Add(lblPiano1);
            Controls.Add(lstPuntiPiano2);
            Controls.Add(lstPuntiPiano1);
            Name = "Configurazione";
            Text = "Configurazione";
            FormClosing += Configurazione_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPuntiPiano1;
        private ListBox lstPuntiPiano2;
        private Label lblPiano1;
        private Label lblPiano2;
        private ListView listvPianiCollegati;
        private Label label3;
        private Button btn_collega;
        private TextBox txtPeso;
        private Label label1;
        private Panel panel1;
        private RadioButton btnTipoCollegamentoAscensore;
        private RadioButton btnTipoCollegamentoScala;
        private Label label2;
        private CheckBox chkBA;
        private CheckBox chkAB;
        private Label label4;
    }
}