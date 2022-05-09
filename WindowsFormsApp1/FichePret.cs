using System;
using System.Globalization;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1
{
    public partial class FichePret : Form
    {
        public bool Modify { get; }
        public Pret PretCourant { get; }

        public FichePret(bool modify, Pret unPret)
        {
            Modify = modify;
            InitializeComponent();
            if (unPret != null)
            {
                PretCourant = unPret;
            }
            if (modify == false)
            {
                textBoxDate.Enabled = false;
                textBoxRP.Enabled = false;
                textBoxRetour.Enabled = false;
                comboBox2.Enabled = false;
                comboBox1.Enabled = false;
                Livre monLivre = ManagerLivre.FindLivre_ByID(PretCourant.NumLivre);
                comboBox1.Items.Insert(0, monLivre.Titre);
                Adherent monAdherent = ManagerAdherent.FindAdherent_ByID(PretCourant.NumAdherents);
                comboBox2.Items.Insert(0,monAdherent.Nom.ToUpper() + " " + monAdherent.Prenom);
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                var mesLivres = ManagerLivre.FindAll();
                foreach (var livre in mesLivres)
                {
                    comboBox1.Items.Insert(livre.Num - 1, livre.Titre);
                }

                var mesAdherents = ManagerAdherent.FindAll();
                foreach (var adhe in mesAdherents)
                {
                    comboBox2.Items.Insert(adhe.Num - 1, adhe.Nom.ToUpper() + " " + adhe.Prenom);
                }

                comboBox1.SelectedIndex = PretCourant.NumAdherents - 1;
                comboBox2.SelectedIndex = PretCourant.NumLivre - 1;
            }

            textBoxNum.Text = PretCourant.Num.ToString();
            textBoxDate.Text = PretCourant.DatePret.ToString(CultureInfo.InvariantCulture);
            textBoxRP.Text = PretCourant.DateRetourPrevues.ToString(CultureInfo.InvariantCulture);
            textBoxRetour.Text = PretCourant.DateRetourReelle.ToString(CultureInfo.InvariantCulture);
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            // if (Modify == false)
            // {
            //     Close();
            // }
            // else
            // {
            //     if (ControlsSaisie())
            //     {
            //         try
            //         {
            //             textBoxNum.Text = PretCourant.Num.ToString();
            //             textBoxDate.Text = PretCourant.DatePret.ToString(CultureInfo.InvariantCulture);
            //             textBoxRP.Text = PretCourant.DateRetourPrevues.ToString(CultureInfo.InvariantCulture);
            //             textBoxDate.Text = PretCourant.DateRetourReelle.ToString(CultureInfo.InvariantCulture);
            //             LivreCourant.Titre = textBoxNum.Text;
            //             LivreCourant.Edition =textBoxDate.Text;
            //             LivreCourant.Langue =textBoxRP.Text;
            //             LivreCourant.Isbn = textBoxISBN.Text;
            //             PretCourant.Num = Convert.ToInt16(textBoxNum.Text);
            //             LivreCourant.NumGenre = Convert.ToInt16(comboBox2.SelectedIndex + 1);
            //             LivreCourant.Prix = Convert.ToInt16(textBoxPrix.Text);
            //             LivreCourant.NumAuteur = Convert.ToInt16(comboBox1.SelectedIndex + 1);
            //             if (LivreCourant.Num == 0)
            //             {
            //                 var response = ManagerLivre.NewLivre(LivreCourant);
            //                 MessageBox.Show(response
            //                     ? @"Le livre à bien été ajouté !"
            //                     : @"Erreur (code E9) : Le livre n'a pas été ajouté !");
            //             }
            //             else
            //             {
            //                 var response = ManagerLivre.UpdateLivre(LivreCourant);
            //                 MessageBox.Show(response
            //                     ? @"Le livre à bien été mis à jour !"
            //                     : @"Erreur (code E9) : Le livre n'a pas été mis à jour !");
            //             }
            //             Close();
            //         }
            //         catch (Exception exception)
            //         {
            //             MessageBox.Show(exception.Message);
            //         }
            //     }
            // }
            // Close();
        }

        private bool ControlsSaisie()
        {
            var control = true;
            if (textBoxNum.Text == "")
            {
                MessageBox.Show(@"Erreur (code E14): Vous devez saisir un titre !");
                control = false;
            }

            if (textBoxRetour.Text == "")
            {
                MessageBox.Show(@"Erreur (code E15): Vous devez saisir une année valide !");
                control = false;
            }

            if (textBoxDate.Text == "")
            {
                MessageBox.Show(@"Erreur (code E17): Vous devez saisir un éditeur !");
                control = false;
            }

            if (textBoxRP.Text == "")
            {
                MessageBox.Show(@"Erreur (code E18): Vous devez saisir une nationalité !");
                control = false;
            }

            return control;
        }
    }
}