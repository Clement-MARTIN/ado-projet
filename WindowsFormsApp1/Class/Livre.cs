namespace WindowsFormsApp1.Class;

public class Livre
{
    public int Num { get; set;}
    public string Isbn { get; set; } = "";
    public string Titre { get; set;} = "";
    public short Prix { get; set;}
    public string Edition { get; set;} = "";
    public short Annee { get; set;}
    public string Langue { get; set;} = "";
    public short NumAuteur { get; set;}
    public short NumGenre { get; set;}
}