using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Manager;

public class ManagerGenre
{
    public static Genre DonneGenreDuReader(MySqlDataReader myReader)
    {
        Genre unGenre = new Genre();
        unGenre.Num = Convert.ToInt16(myReader["num"].ToString());
        unGenre.Libelle = myReader["libelle"] == DBNull.Value ? "" : myReader["libelle"] as string;
        return unGenre;
    }
    
    public static List<Genre> FindAll()
    {
        List<Genre> lesGenres = new List<Genre>();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * FROM genre order by num";
        var myReader = myCommand.ExecuteReader();
             
        while (myReader.Read())
        {
            Genre unGenre = DonneGenreDuReader(myReader);
            lesGenres.Add(unGenre);
        }
        myReader.Close();
        Connection.MyConnection.Close();
        return lesGenres;
    }
    
    public static Genre FindGenre_ByID(int id)
    {
        Genre monGenre = new Genre();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * from genre where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramNum", id);
        var myReader = myCommand.ExecuteReader();
            
        while (myReader.Read())
        {
            Genre unGenre = DonneGenreDuReader(myReader);
            monGenre = unGenre;
        }

        myReader.Close();
        Connection.MyConnection.Close();
        return monGenre;
    }
    
    public static bool UpdateGenre(Genre g)
    {
        bool response;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "Update genre set libelle=@paramLibelle where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramLibelle", g.Libelle);
        myCommand.Parameters.AddWithValue("@paramNum", g.Num);
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
                MessageBox.Show(@"Erreur (code E19) : Le genre n'a pas été mis à jour !");
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
    
    public static bool NewGenre(Genre g)
    {
        bool response = false;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "insert into genre (libelle) VALUES(@paramLibelle)";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramLibelle", g.Libelle);
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