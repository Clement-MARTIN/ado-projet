using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class DeleteLivre : Form
    {
        private MySqlCommand _myCommand;
        public int NumLivre { get; }
        
        public DeleteLivre(int num)
        {
            InitializeComponent();
            NumLivre = num;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                _myCommand = Connection.MyConnection.CreateCommand();
                _myCommand.CommandText = "DELETE FROM livre where num = @paramNums";
                _myCommand.Parameters.AddWithValue("@paramNums", NumLivre);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception +"");
            }
            
            try
            {
                Connection.MyConnection.Open();
                var result = _myCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0
                    ? @"Le livre à bien été mis supprimé !"
                    : @"Erreur (code E9) : Le livre n'a pas été supprimé !");
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
            MessageBox.Show(NumLivre + "");
        }
    }
}