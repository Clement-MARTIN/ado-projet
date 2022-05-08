using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1.Manager
{
    public class ManagerAuteur
    {
        public static Auteur DonneAuteurDuReader(MySqlDataReader myReader)
        {
            Auteur unAuteur = new Auteur
            {
                Num = Convert.ToInt16(myReader["num"].ToString()),
                Nom = myReader["nom"] == DBNull.Value ? "" : myReader["nom"] as string,
                Prenom = myReader["prenom"] == DBNull.Value ? "" : myReader["prenom"] as string,
                Nationalite = myReader["nationalite"] == DBNull.Value ? "" : myReader["nationalite"] as string
            };
            return unAuteur;
        }

        public static List<Auteur> FindAll()
        {
            List<Auteur> lesAuteurs = new List<Auteur>();
            Connection.MyConnection.Open();
            var myCommand = Connection.MyConnection.CreateCommand();
            myCommand.CommandText = "SELECT * FROM auteur order by num";
            var myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                Auteur unAuteur = DonneAuteurDuReader(myReader);
                lesAuteurs.Add(unAuteur);
            }

            myReader.Close();
            Connection.MyConnection.Close();
            return lesAuteurs;
        }

        public static Auteur FindAuteur_ByID(int id)
        {
            Auteur monAuteur = new Auteur();
            Connection.MyConnection.Open();
            var myCommand = Connection.MyConnection.CreateCommand();
            myCommand.CommandText = "SELECT * from auteur where num=@paramNum";
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@paramNum", id);
            var myReader = myCommand.ExecuteReader();
            
            while (myReader.Read())
            {
                Auteur unAuteur = DonneAuteurDuReader(myReader);
                monAuteur = unAuteur;
            }

            myReader.Close();
            Connection.MyConnection.Close();
            return monAuteur;
        }

        public static bool UpdateAuteur(Auteur a)
        {
            bool response;
            var myCommand = Connection.MyConnection.CreateCommand();
            myCommand.CommandText =
                "Update auteur set nom=@paramNom, prenom=@paramPrenom, nationalite=@paramNation where num=@paramNum";
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@paramNom", a.Nom);
            myCommand.Parameters.AddWithValue("@paramPrenom", a.Prenom);
            myCommand.Parameters.AddWithValue("@paramNation", a.Nationalite);
            myCommand.Parameters.AddWithValue("@paramNum", a.Num);
            try
            {
                Connection.MyConnection.Open();
                int result = myCommand.ExecuteNonQuery();
                Connection.MyConnection.Close();
                if (result > 0)
                {
                    response = true;
                }
                else
                {
                    MessageBox.Show(@"Erreur (code E8) : L'auteur n'a pas été mis à jour !");
                    response = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Erreur (code E7) :" + exception.Message);
                throw;
            }

            return response;
        }

        public static bool NewAuteur(Auteur a)
        {
            bool response = false;
            var myCommand = Connection.MyConnection.CreateCommand();
            myCommand.CommandText =
                "insert into auteur (nom, prenom, nationalite) VALUES(@paramNom, @paramPrenom, @paramNation)";
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@paramNom", a.Nom);
            myCommand.Parameters.AddWithValue("@paramPrenom", a.Prenom);
            myCommand.Parameters.AddWithValue("@paramNation", a.Nationalite);
            try
            {
                Connection.MyConnection.Open();
                int result = myCommand.ExecuteNonQuery();
                Connection.MyConnection.Close();
                if (result > 0)
                {
                    response = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Erreur (code E7) :" + exception.Message);
            }

            return response;
        }
    }
}