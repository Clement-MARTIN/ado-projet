using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Manager;

public class ManagerAdherent
{
    public static Adherent DonneAdherentDuReader(MySqlDataReader myReader)
    {
        Adherent unAdherent = new Adherent
        {
            Num = Convert.ToInt16(myReader["num"].ToString()),
            Nom = myReader["nom"] == DBNull.Value ? "" : myReader["nom"] as string,
            Prenom = myReader["prenom"] == DBNull.Value ? "" : myReader["prenom"] as string,
            AdrRue = myReader["adrRue"] == DBNull.Value ? "" : myReader["adrRue"] as string,
            AdrCp = Convert.ToInt64(myReader["adrCP"] == DBNull.Value ? "" : myReader["adrCP"]).ToString(),
            AdrVille = myReader["adrVille"] == DBNull.Value ? "" : myReader["adrVille"] as string,
            Tel = myReader["tel"] == DBNull.Value ? "" : myReader["tel"] as string,
            Mel = myReader["mel"] == DBNull.Value ? "" : myReader["mel"] as string
        };
        return unAdherent;
    }
    
    public static List<Adherent> FindAll()
    {
        List<Adherent> lesAdherents = new List<Adherent>();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * FROM adherent order by num";
        var myReader = myCommand.ExecuteReader();
             
        while (myReader.Read())
        {
            Adherent unAdherent = DonneAdherentDuReader(myReader);
            lesAdherents.Add(unAdherent);
        }
        myReader.Close();
        Connection.MyConnection.Close();
        return lesAdherents;
    }
    
    public static Adherent FindAdherent_ByID(int id)
    {
        Adherent monAdherent = new Adherent();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * from adherent where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramNum", id);
        var myReader = myCommand.ExecuteReader();
            
        while (myReader.Read())
        {
            Adherent unAdherent = DonneAdherentDuReader(myReader);
            monAdherent = unAdherent;
        }

        myReader.Close();
        Connection.MyConnection.Close();
        return monAdherent;
    }
    
    public static bool UpdateAdherent(Adherent a)
    {
        bool response;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "Update adherent set nom=@paramNom, prenom=@paramPrenom, adrRue = @paramAdrRue, adrCP = @paramCP, adrVille = @paramVille, tel = @paramTel, mel = @paramMel where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramNom", a.Nom);
        myCommand.Parameters.AddWithValue("@paramPrenom", a.Prenom);
        myCommand.Parameters.AddWithValue("@paramAdrRue", a.AdrRue);
        myCommand.Parameters.AddWithValue("@paramCP", a.AdrCp);
        myCommand.Parameters.AddWithValue("@paramVille", a.AdrVille);
        myCommand.Parameters.AddWithValue("@paramTel", a.Tel);
        myCommand.Parameters.AddWithValue("@paramMel", a.Mel);
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
                MessageBox.Show(@"Erreur (code E19) : L'adherent n'a pas été mis à jour !");
                response = false;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(@"Erreur (code E20) :" + exception.Message);
            throw;
        }
        return response;
    }
    
    public static bool NewAdherent(Adherent a)
    {
        bool response = false;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "insert into adherent (nom, prenom, adrRue, adrCP, adrVille, tel, mel) VALUES(@paramNom, @paramPrenom, @paramAdrRue, @paramCP, @paramVille, @paramTel, @paramMel)";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramNom", a.Nom);
        myCommand.Parameters.AddWithValue("@paramPrenom", a.Prenom);
        myCommand.Parameters.AddWithValue("@paramAdrRue", a.AdrRue);
        myCommand.Parameters.AddWithValue("@paramCP", a.AdrCp);
        myCommand.Parameters.AddWithValue("@paramVille", a.AdrVille);
        myCommand.Parameters.AddWithValue("@paramTel", a.Tel);
        myCommand.Parameters.AddWithValue("@paramMel", a.Mel);        
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
            MessageBox.Show(@"Erreur (code E21) :" + exception.Message);
        }
        return response;
    }
}