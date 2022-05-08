using System;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1
{
    public partial class FicheLivre : Form
    {
        public bool Modify { get; }
        public Livre LivreCourant { get; }

        public FicheLivre(bool modify, Livre unLivre)
        {
            Modify = modify;
            InitializeComponent();
            if (unLivre != null)
            {
                LivreCourant = unLivre;
            }
            if (modify == false)
            {
                textBoxISBN.Enabled = false;
                textBoxTitre.Enabled = false;
                textBoxEditeur.Enabled = false;
                textBoxLangue.Enabled = false;
                textBoxAnnee.Enabled = false;
                comboBox2.Enabled = false;
                textBoxPrix.Enabled = false;
                comboBox1.Enabled = false;
                Auteur monAuteur = ManagerAuteur.FindAuteur_ByID(LivreCourant.NumAuteur);
                comboBox1.Items.Insert(0, monAuteur.Nom.ToUpper() + " " + monAuteur.Prenom);
                Genre monGenre = ManagerGenre.FindGenre_ByID(LivreCourant.NumGenre);
                comboBox2.Items.Insert(0,monGenre.Libelle);
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                var mesAuteurs = ManagerAuteur.FindAll();
                foreach (var auteur in mesAuteurs)
                {
                    comboBox1.Items.Insert(auteur.Num - 1, auteur.Nom.ToUpper() + " " + auteur.Prenom);
                }

                var mesGenres = ManagerGenre.FindAll();
                foreach (var genre in mesGenres)
                {
                    comboBox2.Items.Insert(genre.Num - 1, genre.Libelle);
                }

                comboBox1.SelectedIndex = LivreCourant.NumAuteur - 1;
                comboBox2.SelectedIndex = LivreCourant.NumGenre - 1;
            }

            textBoxISBN.Text = LivreCourant.Isbn;
            Text = textBoxISBN.Text;
            textBoxTitre.Text = LivreCourant.Titre;
            textBoxEditeur.Text = LivreCourant.Edition;
            textBoxLangue.Text = LivreCourant.Langue;
            textBoxAnnee.Text = LivreCourant.Annee.ToString();
            textBoxPrix.Text = LivreCourant.Prix.ToString();
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
                        LivreCourant.Titre = textBoxTitre.Text;
                        LivreCourant.Edition =textBoxEditeur.Text;
                        LivreCourant.Langue =textBoxLangue.Text;
                        LivreCourant.Isbn = textBoxISBN.Text;
                        LivreCourant.Annee = Convert.ToInt16(textBoxAnnee.Text);
                        LivreCourant.NumGenre = Convert.ToInt16(comboBox2.SelectedIndex + 1);
                        LivreCourant.Prix = Convert.ToInt16(textBoxPrix.Text);
                        LivreCourant.NumAuteur = Convert.ToInt16(comboBox1.SelectedIndex + 1);
                        if (LivreCourant.Num == 0)
                        {
                            var response = ManagerLivre.NewLivre(LivreCourant);
                            MessageBox.Show(response
                                ? @"Le livre à bien été ajouté !"
                                : @"Erreur (code E9) : Le livre n'a pas été ajouté !");
                        }
                        else
                        {
                            var response = ManagerLivre.UpdateLivre(LivreCourant);
                            MessageBox.Show(response
                                ? @"Le livre à bien été mis à jour !"
                                : @"Erreur (code E9) : Le livre n'a pas été mis à jour !");
                        }
                        Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            Close();
        }

        private bool ControlAnnee()
        {
            try
            {
                var annee = Convert.ToInt16(textBoxAnnee.Text);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ControlPrix()
        {
            try
            {
                var prix = Convert.ToInt16(textBoxPrix.Text);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ControlsSaisie()
        {
            var control = true;
            if (textBoxTitre.Text == "")
            {
                MessageBox.Show(@"Erreur (code E14): Vous devez saisir un titre !");
                control = false;
            }

            if (textBoxAnnee.Text == "" || ControlAnnee() == false)
            {
                MessageBox.Show(@"Erreur (code E15): Vous devez saisir une année valide !");
                control = false;
            }

            if (textBoxPrix.Text == "" || ControlPrix() == false)
            {
                MessageBox.Show(@"Erreur (code E16): Vous devez saisir un prix valide !");
                control = false;
            }

            if (textBoxEditeur.Text == "")
            {
                MessageBox.Show(@"Erreur (code E17): Vous devez saisir un éditeur !");
                control = false;
            }

            if (textBoxLangue.Text == "")
            {
                MessageBox.Show(@"Erreur (code E18): Vous devez saisir une nationalité !");
                control = false;
            }

            return control;
        }
    }
}