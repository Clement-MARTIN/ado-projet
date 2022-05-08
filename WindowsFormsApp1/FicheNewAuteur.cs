using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class FicheNewAuteur : Form
    {
        private MySqlCommand myCommand;
        private MySqlDataReader myReader;
        internal DataGridAuteur DataAuteur { get; set; }

        public FicheNewAuteur()
        {
            InitializeComponent();
        }

        private bool ControlsSaisie()
        {
            var control = true;
            if (textBoxNom.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir un nom !");
                control = false;
            }

            if (textBoxPrenom.Text == "")
            {
                MessageBox.Show(@"Erreur (code E5): Vous devez saisir un prénom !");
                control = false;
            }

            if (textBoxNation.Text == "")
            {
                MessageBox.Show(@"Erreur (code E6): Vous devez saisir une nationalité !");
                control = false;
            }

            return control;
        }

        private void btn_valider_Click_1(object sender, EventArgs e)
        {
            if (ControlsSaisie())
            {
                try
                {
                    myCommand = Connection.MyConnection.CreateCommand();
                    myCommand.CommandText =
                        "insert into auteur (nom, prenom, nationalite) VALUES(@paramNom, @paramPrenom, @paramNation)";
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@paramNom", textBoxNom.Text);
                    myCommand.Parameters.AddWithValue("@paramPrenom", textBoxPrenom.Text);
                    myCommand.Parameters.AddWithValue("@paramNation", textBoxNation.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }


                try
                {
                    Connection.MyConnection.Open();
                    int result = myCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show(@"L'auteur à bien été mis ajouté !");
                    }
                    else
                    {
                        MessageBox.Show(@"Erreur (code E8) : L'auteur n'a pas été ajouté !");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"Erreur (code E13) :" + exception.Message);
                    throw;
                }
                finally
                {
                    Close();
                    Connection.MyConnection.Close();
                }
            }
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}