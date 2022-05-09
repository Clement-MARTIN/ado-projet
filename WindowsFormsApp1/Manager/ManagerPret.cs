using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Manager;

public class ManagerPret
{
    public static Pret DonnePretDuReader(MySqlDataReader myReader)
    {
        Pret unPret = new Pret
        {
            Num = Convert.ToInt16(myReader["num"].ToString()),
            NumLivre = Convert.ToInt32(myReader["numLivre"] == DBNull.Value ? "" : myReader["numLivre"]),
            NumAdherents = Convert.ToInt32(myReader["numAdherent"] == DBNull.Value ? "" : myReader["numAdherent"]),
            DatePret = myReader["datePret"] as DateTime? ?? default,
            DateRetourPrevues = myReader["dateRetourPrevue"] as DateTime? ?? default,
            DateRetourReelle =myReader["dateRetourReelle"] as DateTime? ?? default
        };
        return unPret;
    }
    
    public static List<Pret> FindAll()
    {
        List<Pret> lesPrets = new List<Pret>();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * FROM pret order by num";
        var myReader = myCommand.ExecuteReader();
             
        while (myReader.Read())
        {
            Pret unPret = DonnePretDuReader(myReader);
            lesPrets.Add(unPret);
        }
        myReader.Close();
        Connection.MyConnection.Close();
        return lesPrets;
    }
    
    public static Pret FindPret_ByID(int id)
    {
        Pret monPret = new Pret();
        Connection.MyConnection.Open();
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText = "SELECT * from pret where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramNum", id);
        var myReader = myCommand.ExecuteReader();
            
        while (myReader.Read())
        {
            Pret unPret = DonnePretDuReader(myReader);
            monPret = unPret;
        }

        myReader.Close();
        Connection.MyConnection.Close();
        return monPret;
    }
    
    public static bool UpdatePret(Pret p)
    {
        bool response;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "Update pret set numLivre=@paramLivre, numAdherent=@paramAdherent, datePret = @paramPret, dateRetourPrevue = @paramRP, dateRetourReelle = @paramRetour where num=@paramNum";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramLivre", p.NumLivre);
        myCommand.Parameters.AddWithValue("@paramAdherent", p.NumAdherents);
        myCommand.Parameters.AddWithValue("@paramPret", p.DatePret);
        myCommand.Parameters.AddWithValue("@paramRP", p.DateRetourPrevues);
        myCommand.Parameters.AddWithValue("@paramRetour", p.DateRetourReelle);
        myCommand.Parameters.AddWithValue("@paramNum", p.Num);
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
                MessageBox.Show(@"Erreur (code E19) : Le pret n'a pas été mis à jour !");
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
    
    public static bool Newpret(Pret p)
    {
        bool response = false;
        var myCommand = Connection.MyConnection.CreateCommand();
        myCommand.CommandText =
            "insert into pret (numLivre, numAdherent, datePret, dateRetourPrevue, dateRetourPrevue) VALUES(@paramLivre, @paramAdherent, @paramPret, @paramRP, @paramRetour)";
        myCommand.Parameters.Clear();
        myCommand.Parameters.AddWithValue("@paramLivre", p.NumLivre);
        myCommand.Parameters.AddWithValue("@paramAdherent", p.NumAdherents);
        myCommand.Parameters.AddWithValue("@paramPret", p.DatePret);
        myCommand.Parameters.AddWithValue("@paramRP", p.DateRetourPrevues);
        myCommand.Parameters.AddWithValue("@paramRetour", p.DateRetourReelle);
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