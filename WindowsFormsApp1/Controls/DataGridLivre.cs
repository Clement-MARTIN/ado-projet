using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Controls
{
    public sealed class DataGridLivre : DataGridView
    {
        private MySqlDataReader myReader;
        public List<Livre> LesLivres { get; } = new List<Livre>();

        public DataGridLivre()
        {
            Location = new Point(0, 48);
            Dock = DockStyle.Fill;
            Name = "data_list_livre";
            GridColor = Color.FromArgb(91, 192, 222);
            BorderStyle = BorderStyle.None;
            MultiSelect = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ScrollBars = ScrollBars.Both;
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 148, 6);
            ColumnCount = 10;
            BackgroundColor = Color.White;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            string[] name = {"num", "ISBN", "titre", "prix", "editeur", "annee", "langue", "nom", "prenom",  "libelle"};
            string[] text = {"Numéro", "ISBN", "Titre", "Prix" , "Editeur" , "Anneé", "Langue", "Nom Auteur", "Prénom Auteur", "Genre"};
            for (int i = 0; i < 10; i++)
            {
                Columns[i].Name = name[i];
                Columns[i].HeaderText = text[i];
                Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[7].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[8].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[9].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[9].DefaultCellStyle.ForeColor = Color.FromArgb(98, 196, 98);
            Columns[7].DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
            Columns[8].DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
            Columns[9].DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
            Columns[7].DefaultCellStyle.ForeColor = Color.FromArgb(238, 95, 91);
            Columns[8].DefaultCellStyle.ForeColor = Color.FromArgb(238, 95, 91);

            try
            {
                Rows.Clear();
                Connection.MyConnection.Open();
                var myCommand = Connection.MyConnection.CreateCommand();
                myCommand.CommandText = "SELECT l.num,isbn,titre,prix,editeur,annee,langue,a.nom,a.prenom, g.libelle FROM livre l INNER JOIN auteur a INNER JOIN genre g where l.numAuteur=a.num and l.numGenre=g.num";
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Rows.Add(
                        myReader["num"].ToString(),
                        myReader["ISBN"].ToString(),
                        myReader["titre"].ToString(),
                        myReader["prix"] + " €",
                        myReader["editeur"].ToString(),
                        myReader["annee"].ToString(),
                        myReader["langue"].ToString(),
                        myReader["nom"].ToString(),
                        myReader["prenom"].ToString(),
                        myReader["libelle"].ToString()
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Erreur  (code E1) :" + e.Message);
            }
            finally
            {
                if (myReader != null) myReader.Close();
                Connection.MyConnection.Close();
            }

        }
        
        public int IntLivre()
        {
            return Convert.ToInt16(SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}