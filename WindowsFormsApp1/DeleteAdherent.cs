﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class DeleteAdherent : Form
    {
        private MySqlCommand _myCommand;
        private int numadherents;
        public DeleteAdherent(int num)
        {
            InitializeComponent();
            numadherents = num;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                _myCommand = Connection.MyConnection.CreateCommand();
                _myCommand.CommandText = "DELETE FROM adherent where num = @paramNums";
                _myCommand.Parameters.AddWithValue("@paramNums", numadherents);
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
                    ? @"L'adherent à bien été mis supprimé !"
                    : @"Erreur (code E9) : L'adherent n'a pas été supprimé !");
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
            MessageBox.Show(numadherents + "");
        }
    }
}