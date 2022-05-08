using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class DeleteGenre
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
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(250, 146);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(163, 47);
            this.btn_delete.TabIndex = 15;
            this.btn_delete.Text = "Oui, valider";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_annuler
            // 
            this.btn_annuler.Location = new System.Drawing.Point(12, 146);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(163, 47);
            this.btn_annuler.TabIndex = 14;
            this.btn_annuler.Text = "Non, annuler";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.SystemColors.Control;
            this.message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(12, 57);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(401, 40);
            this.message.TabIndex = 16;
            this.message.Text = "Voulez-vous \r\nvraiment supprimer ce genre ?";
            this.message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeleteGenre
            // 
            this.AcceptButton = this.btn_annuler;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 205);
            this.Controls.Add(this.message);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_annuler);
            this.MaximumSize = new System.Drawing.Size(443, 252);
            this.MinimumSize = new System.Drawing.Size(443, 252);
            this.Name = "DeleteGenre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Surpprimer l\'auteur";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_annuler;
        private System.Windows.Forms.TextBox message;

        #endregion
    }
}