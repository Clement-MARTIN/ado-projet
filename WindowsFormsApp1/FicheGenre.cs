using System;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1
{
    public partial class FicheGenre : Form
    {
        public bool Modify { get; }
        public Genre GenreCourant { get; } 

        public FicheGenre(bool modify,Genre unGenre)
        {
            Modify = modify;
            InitializeComponent();
            if (unGenre != null)
            {
                GenreCourant = unGenre;
            }
            textBoxNum.Text = GenreCourant.Num.ToString();
            textBoxLibelle.Text = GenreCourant.Libelle;
            if (modify == false)
            {
                textBoxLibelle.Enabled = false;
            }
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btn_valider_Click(object sender, EventArgs e)
        {
            if (Modify == false)
            {
                Close();
            }
            else
            {
                if (ControlsSaisie())
                {
                    try
                    {
                        GenreCourant.Libelle = textBoxLibelle.Text;
                        if (GenreCourant.Num == 0)
                        {
                            var response = ManagerGenre.NewGenre(GenreCourant);
                            MessageBox.Show(response
                                ? @"Le genre à bien été ajouté !"
                                : @"Erreur (code E9) : Le genre n'a pas été ajouté !");
                        }
                        else
                        {
                            var response = ManagerGenre.UpdateGenre(GenreCourant);
                            MessageBox.Show(response
                                ? @"Le genre à bien été mis à jour !"
                                : @"Erreur (code E9) : Le genre n'a pas été mis à jour !");
                        }
                        Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    
                }
            }
        }

        private bool ControlsSaisie()
        {
            var control = true;
            if (textBoxLibelle.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir un libelle !");
                control = false;
            }
            return control;
        }
    }
}