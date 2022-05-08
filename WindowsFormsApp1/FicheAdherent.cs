using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Controls;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1
{
    public partial class FicheAdherent : Form
    {
        public bool Modify { get; }
        public Adherent AdherentCourant { get; set; }

        public FicheAdherent(bool modify, Adherent unAdherent)
        {
            Modify = modify;
            InitializeComponent();
            if (unAdherent != null)
            {
                AdherentCourant = unAdherent;
            }

            textBoxNum.Text = AdherentCourant.Num.ToString();
            textBoxNom.Text = AdherentCourant.Nom;
            textBoxPrenom.Text = AdherentCourant.Prenom;
            TextBoxAdr.Text = AdherentCourant.AdrRue;
            TextBoxCP.Text = AdherentCourant.AdrCp;
            TextBoxVille.Text = AdherentCourant.AdrVille;
            TextBoxTel.Text = AdherentCourant.Tel;
            textBoxEmail.Text = AdherentCourant.Mel;
            Text += AdherentCourant.Nom.ToUpper() + " " + AdherentCourant.Prenom;
            if (modify == false)
            {
                textBoxNom.Enabled = false;
                textBoxPrenom.Enabled = false;
                TextBoxAdr.Enabled = false;
                TextBoxCP.Enabled = false;
                TextBoxVille.Enabled = false;
                TextBoxTel.Enabled = false;
                textBoxEmail.Enabled = false;
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
                        AdherentCourant.Nom = textBoxNom.Text;
                        AdherentCourant.Prenom = textBoxPrenom.Text;
                        AdherentCourant.AdrRue = TextBoxAdr.Text;
                        AdherentCourant.AdrCp = TextBoxCP.Text;
                        AdherentCourant.AdrVille = TextBoxVille.Text;
                        AdherentCourant.Tel = TextBoxTel.Text;
                        AdherentCourant.Mel = textBoxEmail.Text;
                        if (AdherentCourant.Num == 0)
                        {
                            var response = ManagerAdherent.NewAdherent(AdherentCourant);
                            MessageBox.Show(response
                                ? @"L'adherant à bien été ajouté !"
                                : @"Erreur (code E9) : L'auteur n'a pas été ajouté !");
                        }
                        else
                        {
                            var response = ManagerAdherent.UpdateAdherent(AdherentCourant);
                            MessageBox.Show(response
                                ? @"L'adherant à bien été mis à jour !"
                                : @"Erreur (code E9) : L'auteur n'a pas été mis à jour !");
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
            if (textBoxNom.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir un nom !");
                control = false;
            }

            if (textBoxPrenom.Text == "")
            {
                MessageBox.Show(@"Erreur (code E5): Vous devez saisir un prénom !");
                control = false;
            }

            if (TextBoxAdr.Text == "")
            {
                MessageBox.Show(@"Erreur (code E6): Vous devez saisir une adresse !");
                control = false;
            }
            
            if (TextBoxCP.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir un code postal !");
                control = false;
            }
            
            if (TextBoxVille.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir une ville !");
                control = false;
            }
            
            if (TextBoxTel.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir un numéro de téléphone !");
                control = false;
            }
            
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show(@"Erreur (code E4): Vous devez saisir un Email !");
                control = false;
            }

            return control;
        }
    }
}