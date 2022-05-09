using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Controls
{
    public sealed class DataGridPret : DataGridView
    {
        private MySqlDataReader _myReader;

        public DataGridPret()
        {
            Location = new Point(0, 48);
            Dock = DockStyle.Fill;
            Name = "data_list_pret";
            GridColor = Color.FromArgb(91, 192, 222);
            BorderStyle = BorderStyle.None;
            MultiSelect = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ScrollBars = ScrollBars.Both;
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 148, 6);
            ColumnCount = 7;
            BackgroundColor = Color.White;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            string[] name = {"num", "titre", "nom", "prenom", "datePret", "dateRetourPrevue", "dateRetourReelle"};
            string[] text = {"Numéro", "Titre", "Nom Adhérent", "Prénom Adhérent" , "Date de Pret" , "Date de Retour Prevue", "Vrai date de Retour"};
            for (int i = 0; i < 7; i++)
            {
                Columns[i].Name = name[i];
                Columns[i].HeaderText = text[i];
                Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[3].DefaultCellStyle.BackColor = Color.FromArgb(233, 236, 239);
            Columns[1].DefaultCellStyle.ForeColor = Color.FromArgb(98, 196, 98);
            Columns[1].DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
            Columns[2].DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
            Columns[3].DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
            Columns[2].DefaultCellStyle.ForeColor = Color.FromArgb(238, 95, 91);
            Columns[3].DefaultCellStyle.ForeColor = Color.FromArgb(238, 95, 91);

            try
            {
                Rows.Clear();
                Connection.MyConnection.Open();
                var myCommand = Connection.MyConnection.CreateCommand();
                myCommand.CommandText = "SELECT p.num,datePret,dateRetourPrevue,dateRetourReelle,a.nom,a.prenom, l.titre FROM pret p INNER JOIN adherent a INNER JOIN livre l where l.num=p.numLivre and a.num=p.numAdherent ORDER BY num";
                _myReader = myCommand.ExecuteReader();
                while (_myReader.Read())
                {
                    Rows.Add(
                        _myReader["num"].ToString(),
                        _myReader["titre"].ToString(),
                        _myReader["nom"].ToString(),
                        _myReader["prenom"].ToString(),
                        _myReader["datePret"].ToString(),
                        _myReader["dateRetourPrevue"].ToString(),
                        _myReader["dateRetourReelle"].ToString()
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Erreur  (code E1) :" + e.Message);
            }
            finally
            {
                if (_myReader != null) _myReader.Close();
                Connection.MyConnection.Close();
            }

        }
        
        public int IntLivre()
        {
            return Convert.ToInt16(SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}