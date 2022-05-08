using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class DeleteGenre : Form
    {
        private MySqlCommand _myCommand;
        private int numGenre;
        public DeleteGenre(int num)
        {
            InitializeComponent();
            numGenre = num;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                _myCommand = Connection.MyConnection.CreateCommand();
                _myCommand.CommandText = "DELETE FROM genre where num = @paramNums";
                _myCommand.Parameters.AddWithValue("@paramNums", numGenre);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception +"");
            }
            
            try
            {
                Connection.MyConnection.Open();
                int result = _myCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(@"Le genre à bien été mis supprimé !");
                }
                else
                {
                    MessageBox.Show(@"Erreur (code E9) : Le genre n'a pas été supprimé !");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Erreur (code E10) :" + exception.Message);
                throw;
            }
            finally
            {
                Connection.MyConnection.Close();
                Close();
            }
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            MessageBox.Show(numGenre + "");
        }
    }
}