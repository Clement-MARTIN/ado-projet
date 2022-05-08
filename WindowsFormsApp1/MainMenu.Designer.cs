﻿namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_list_auteurs = new System.Windows.Forms.Button();
            this.btn_list_livre = new System.Windows.Forms.Button();
            this.btn_genre = new System.Windows.Forms.Button();
            this.btn_adherents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_list_auteurs
            // 
            this.btn_list_auteurs.AutoSize = true;
            this.btn_list_auteurs.BackColor = System.Drawing.Color.Transparent;
            this.btn_list_auteurs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_list_auteurs.FlatAppearance.BorderSize = 0;
            this.btn_list_auteurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list_auteurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_list_auteurs.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_list_auteurs.Location = new System.Drawing.Point(194, 329);
            this.btn_list_auteurs.Name = "btn_list_auteurs";
            this.btn_list_auteurs.Size = new System.Drawing.Size(168, 34);
            this.btn_list_auteurs.TabIndex = 5;
            this.btn_list_auteurs.Text = "Liste des Auteurs";
            this.btn_list_auteurs.UseVisualStyleBackColor = false;
            this.btn_list_auteurs.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_list_livre
            // 
            this.btn_list_livre.AutoSize = true;
            this.btn_list_livre.BackColor = System.Drawing.Color.Transparent;
            this.btn_list_livre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_list_livre.FlatAppearance.BorderSize = 0;
            this.btn_list_livre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list_livre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_list_livre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_list_livre.Location = new System.Drawing.Point(1137, 329);
            this.btn_list_livre.Name = "btn_list_livre";
            this.btn_list_livre.Size = new System.Drawing.Size(168, 34);
            this.btn_list_livre.TabIndex = 6;
            this.btn_list_livre.Text = "Liste des Livres";
            this.btn_list_livre.UseVisualStyleBackColor = false;
            this.btn_list_livre.Click += new System.EventHandler(this.btn_list_livre_Click);
            // 
            // btn_genre
            // 
            this.btn_genre.AutoSize = true;
            this.btn_genre.BackColor = System.Drawing.Color.Transparent;
            this.btn_genre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_genre.FlatAppearance.BorderSize = 0;
            this.btn_genre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_genre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_genre.Location = new System.Drawing.Point(268, 687);
            this.btn_genre.Name = "btn_genre";
            this.btn_genre.Size = new System.Drawing.Size(168, 34);
            this.btn_genre.TabIndex = 7;
            this.btn_genre.Text = "Liste des Genres\r\n";
            this.btn_genre.UseVisualStyleBackColor = false;
            this.btn_genre.Click += new System.EventHandler(this.btn_genre_Click);
            // 
            // btn_adherents
            // 
            this.btn_adherents.AutoSize = true;
            this.btn_adherents.BackColor = System.Drawing.Color.Transparent;
            this.btn_adherents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_adherents.FlatAppearance.BorderSize = 0;
            this.btn_adherents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adherents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adherents.ForeColor = System.Drawing.Color.Orange;
            this.btn_adherents.Location = new System.Drawing.Point(1228, 586);
            this.btn_adherents.Name = "btn_adherents";
            this.btn_adherents.Size = new System.Drawing.Size(188, 34);
            this.btn_adherents.TabIndex = 8;
            this.btn_adherents.Text = "Liste des Adhérents\r\n";
            this.btn_adherents.UseVisualStyleBackColor = false;
            this.btn_adherents.Click += new System.EventHandler(this.btn_adherents_Click);
            // 
            // Form1
            // 
            this.AccessibleName = "Liste Auteurs";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1354, 795);
            this.Controls.Add(this.btn_adherents);
            this.Controls.Add(this.btn_genre);
            this.Controls.Add(this.btn_list_livre);
            this.Controls.Add(this.btn_list_auteurs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btn_adherents;

        private System.Windows.Forms.Button btn_genre;

        private System.Windows.Forms.Button btn_list_livre;

        private System.Windows.Forms.Button btn_list_auteurs;

        #endregion
    }
}