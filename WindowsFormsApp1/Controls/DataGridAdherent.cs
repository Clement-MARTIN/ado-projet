using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1.Controls
{
    public class DataGridAdherent : DataGridView
    {
        public List<Adherent> LesAdherent { get; } = new List<Adherent>();

        public DataGridAdherent()
        {
            Location = new Point(0, 48);
            Dock = DockStyle.Fill;
            Name = "data_list_adherent";
            GridColor = Color.FromArgb(91, 192, 222);
            BorderStyle = BorderStyle.None;
            MultiSelect = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ScrollBars = ScrollBars.Both;
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 148, 6);
            ColumnCount = 8;
            BackgroundColor = Color.White;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            string[] name = {"num", "nom", "prenom", "adrRue", "adrCP", "adrVille", "tel", "mel"};
            string[] text = {"Numéro", "Nom", "Prénom", "Adresse", "Code postal", "Ville", "Télephone", "Email"};
            for (int i = 0; i < 8; i++)
            {
                Columns[i].Name = name[i];
                Columns[i].HeaderText = text[i];
                Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Columns[i].DataPropertyName = name[i];
            }
            Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);

            try
            {
                LesAdherent = ManagerAdherent.FindAll();
                DataSource = LesAdherent;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Erreur  (code E1) :" + e.Message);
            }
        }
        
        public int IntAdherent()
        {
            return Convert.ToInt16(SelectedRows[0].Cells[0].Value.ToString());
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            SuspendLayout();
            Dock = DockStyle.Fill;
            RowTemplate.Height = 24;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            ResumeLayout(false);
        }
    }
}