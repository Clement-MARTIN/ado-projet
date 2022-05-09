using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Manager;

public class ManagerLivre
{
    public static Livre DonneLivreDuReader(MySqlDataReader myReader)
    {
        Livre unLivre = new Livre
        {
            Num = Convert.ToInt16(myReader["num"].ToString()),
            Isbn = myReader["ISBN"] as string,
            Annee = Convert.ToInt16(myReader["annee"].ToString()),
            Edition = myReader["editeur"] as string,
            Langue = myReader["langue"] as string,
            Prix = Convert.ToInt16(myReader["prix"].ToString()),
            Titre = myReader["titre"] as string,
            NumAuteur = Convert.ToInt16(myReader["numAuteur"].ToString()),
            NumGenre = Convert.ToInt16(myReader["numGenre"].ToString())
        };
        return unLivre;
    }
    
    public static List<Livre> FindAll()
    {
        List<Livre> lesLivres = new List<Livre>();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * FROM livre order by num";
        var myReader = myCommand.ExecuteReader();
             
        while (myReader.Read())
        {
            Livre unGenre = DonneLivreDuReader(myReader);
            lesLivres.Add(unGenre);
        }
        myReader.Close();
        Connection.MyConnection.Close();
        return lesLivres;
    }

    public static Livre FindLivre_ByID(int id)
    {
        Livre monLivre = new Livre();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * from livre where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramNum", id);
        var myReader = myCommand.ExecuteReader();
        while (myReader.Read())
        {
            Livre unLivre = DonneLivreDuReader(myReader);
            monLivre = unLivre;
        }
        myReader.Close();
        Connection.MyConnection.Close();
        return monLivre;
    }

    public static bool UpdateLivre(Livre l)
    {
        bool response;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "Update livre set ISBN=@paramISBN, titre=@paramTitre, prix=@paramPrix, langue=@paramLangue, editeur=@paramEdit, annee=@paramAnnee, numAuteur=@paramNumA, numGenre=@paramNumG where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramISBN", l.Isbn);
        myCommand.Parameters.AddWithValue("@paramTitre", l.Titre);
        myCommand.Parameters.AddWithValue("@paramPrix", l.Prix);
        myCommand.Parameters.AddWithValue("@paramLangue", l.Langue);
        myCommand.Parameters.AddWithValue("@paramEdit", l.Edition);
        myCommand.Parameters.AddWithValue("@paramAnnee", l.Annee);
        myCommand.Parameters.AddWithValue("@paramNumA", l.NumAuteur);
        myCommand.Parameters.AddWithValue("@paramNumG", l.NumGenre);
        myCommand.Parameters.AddWithValue("@paramNum", l.Num);
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
                MessageBox.Show(@"Erreur (code E22) : Le livre n'a pas été mis à jour !");
                response = false;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(@"Erreur (code E23) :" + exception.Message);
            throw;
        }

        return response;
    }

    public static bool NewLivre(Livre l)
    {
        bool response = false;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "insert into livre (isbn,titre,prix,langue,editeur,annee,numAuteur,numGenre) VALUES(@paramISBN, @paramTitre, @paramPrix,@paramLangue, @paramEdit, @paramAnnee, @paramNumA, @paramNumG)";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramISBN", l.Isbn);
        myCommand.Parameters.AddWithValue("@paramTitre", l.Titre);
        myCommand.Parameters.AddWithValue("@paramPrix", l.Prix);
        myCommand.Parameters.AddWithValue("@paramLangue", l.Langue);
        myCommand.Parameters.AddWithValue("@paramEdit", l.Edition);
        myCommand.Parameters.AddWithValue("@paramAnnee", l.Annee);
        myCommand.Parameters.AddWithValue("@paramNumA", l.NumAuteur);
        myCommand.Parameters.AddWithValue("@paramNumG", l.NumGenre);
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
            MessageBox.Show(@"Erreur (code E24) :" + exception.Message);
        }

        return response;
    }
}