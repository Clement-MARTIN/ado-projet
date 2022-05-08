using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class FicheAdherent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheAdherent));
            this.txt_num = new System.Windows.Forms.Label();
            this.txt_nationalite = new System.Windows.Forms.Label();
            this.txt_prenom = new System.Windows.Forms.Label();
            this.txt_nom = new System.Windows.Forms.Label();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.btn_valider = new System.Windows.Forms.Button();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.TextBoxAdr = new System.Windows.Forms.TextBox();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.TextBoxCP = new System.Windows.Forms.TextBox();
            this.TextBoxVille = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.TextBoxTel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_num
            // 
            this.txt_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_num.Location = new System.Drawing.Point(221, 55);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(100, 29);
            this.txt_num.TabIndex = 0;
            this.txt_num.Text = "Numéro";
            // 
            // txt_nationalite
            // 
            this.txt_nationalite.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nationalite.Location = new System.Drawing.Point(12, 209);
            this.txt_nationalite.Name = "txt_nationalite";
            this.txt_nationalite.Size = new System.Drawing.Size(146, 29);
            this.txt_nationalite.TabIndex = 1;
            this.txt_nationalite.Text = "Adresse";
            // 
            // txt_prenom
            // 
            this.txt_prenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_prenom.Location = new System.Drawing.Point(353, 123);
            this.txt_prenom.Name = "txt_prenom";
            this.txt_prenom.Size = new System.Drawing.Size(109, 29);
            this.txt_prenom.TabIndex = 2;
            this.txt_prenom.Text = "Prénom";
            // 
            // txt_nom
            // 
            this.txt_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom.Location = new System.Drawing.Point(12, 123);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(100, 29);
            this.txt_nom.TabIndex = 3;
            this.txt_nom.Text = "Nom";
            // 
            // btn_annuler
            // 
            this.btn_annuler.Location = new System.Drawing.Point(12, 507);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(163, 47);
            this.btn_annuler.TabIndex = 4;
            this.btn_annuler.Text = "Annuler";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(502, 507);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(163, 47);
            this.btn_valider.TabIndex = 5;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // textBoxNum
            // 
            this.textBoxNum.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNum.Enabled = false;
            this.textBoxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.textBoxNum.Location = new System.Drawing.Point(353, 52);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(147, 32);
            this.textBoxNum.TabIndex = 6;
            // 
            // TextBoxAdr
            // 
            this.TextBoxAdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.TextBoxAdr.Location = new System.Drawing.Point(149, 206);
            this.TextBoxAdr.Name = "TextBoxAdr";
            this.TextBoxAdr.Size = new System.Drawing.Size(516, 32);
            this.TextBoxAdr.TabIndex = 7;
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.textBoxPrenom.Location = new System.Drawing.Point(470, 123);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(195, 32);
            this.textBoxPrenom.TabIndex = 8;
            // 
            // textBoxNom
            // 
            this.textBoxNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.textBoxNom.Location = new System.Drawing.Point(149, 120);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(198, 32);
            this.textBoxNom.TabIndex = 9;
            // 
            // TextBoxCP
            // 
            this.TextBoxCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.TextBoxCP.Location = new System.Drawing.Point(149, 285);
            this.TextBoxCP.Name = "TextBoxCP";
            this.TextBoxCP.Size = new System.Drawing.Size(142, 32);
            this.TextBoxCP.TabIndex = 10;
            // 
            // TextBoxVille
            // 
            this.TextBoxVille.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.TextBoxVille.Location = new System.Drawing.Point(364, 285);
            this.TextBoxVille.Name = "TextBoxVille";
            this.TextBoxVille.Size = new System.Drawing.Size(301, 32);
            this.TextBoxVille.TabIndex = 11;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.textBoxEmail.Location = new System.Drawing.Point(149, 439);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(516, 32);
            this.textBoxEmail.TabIndex = 12;
            // 
            // TextBoxTel
            // 
            this.TextBoxTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTel.Location = new System.Drawing.Point(149, 363);
            this.TextBoxTel.Name = "TextBoxTel";
            this.TextBoxTel.Size = new System.Drawing.Size(516, 32);
            this.TextBoxTel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Code postal";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ville";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 29);
            this.label3.TabIndex = 16;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Téléphone";
            // 
            // FicheAdherent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 566);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxTel);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.TextBoxVille);
            this.Controls.Add(this.TextBoxCP);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.TextBoxAdr);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_annuler);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.txt_prenom);
            this.Controls.Add(this.txt_nationalite);
            this.Controls.Add(this.txt_num);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FicheAdherent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche ";
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox TextBoxCP;
        private System.Windows.Forms.TextBox TextBoxVille;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox TextBoxTel;

        private System.Windows.Forms.BindingSource bs;

        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.TextBox TextBoxAdr;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.TextBox textBoxNom;

        private System.Windows.Forms.Label txt_num;
        private System.Windows.Forms.Label txt_nationalite;
        private System.Windows.Forms.Label txt_prenom;
        private System.Windows.Forms.Label txt_nom;
        private System.Windows.Forms.Button btn_annuler;
        private System.Windows.Forms.Button btn_valider;

        #endregion
    }
}