using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Controls;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1
{
    public partial class FicheAuteur : Form
    {
        public bool Modify { get; }
        public Auteur AuteurCourant { get; set; } 

        public FicheAuteur(bool modify,Auteur unAuteur)
        {
            Modify = modify;
            InitializeComponent();
            if (unAuteur != null)
            {
                AuteurCourant = unAuteur;
            }
            textBoxNum.Text = AuteurCourant.Num.ToString();
            textBoxNom.Text = AuteurCourant.Nom;
            textBoxPrenom.Text = AuteurCourant.Prenom;
            textBoxNation.Text = AuteurCourant.Nationalite;
            Text += AuteurCourant.Nom.ToUpper() + " " + AuteurCourant.Prenom;
            if (modify == false)
            {
                textBoxNom.Enabled = false;
                textBoxPrenom.Enabled = false;
                textBoxNation.Enabled = false;
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
                        AuteurCourant.Nom = textBoxNom.Text;
                        AuteurCourant.Prenom = textBoxPrenom.Text;
                        AuteurCourant.Nationalite = textBoxNation.Text;
                        if (AuteurCourant.Num == 0)
                        {
                            bool response = ManagerAuteur.NewAuteur(AuteurCourant);
                            if (response)
                            {
                                MessageBox.Show(@"L'auteur à bien été ajouté !");
                            }
                            else
                            {
                                MessageBox.Show(@"Erreur (code E9) : L'auteur n'a pas été ajouté !");
                            }                        }
                        else
                        {
                            bool response = ManagerAuteur.UpdateAuteur(AuteurCourant);
                            if (response)
                            {
                                MessageBox.Show(@"L'auteur à bien été mis à jour !");
                            }
                            else
                            {
                                MessageBox.Show(@"Erreur (code E9) : L'auteur n'a pas été mis à jour !");
                            } 
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

            if (textBoxNation.Text == "")
            {
                MessageBox.Show(@"Erreur (code E6): Vous devez saisir une nationalité !");
                control = false;
            }

            return control;
        }
    }
}