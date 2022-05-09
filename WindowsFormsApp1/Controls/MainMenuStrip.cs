using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Manager;

namespace WindowsFormsApp1.Controls
{
    class MainMenuStrip : MenuStrip
    {
        private Form1 _mainForm;

        public DataGridAuteur DataAuteur { get; }
        public DataGridLivre DataLivre { get; }
        public DataGridGenre DataGenre { get; }
        public DataGridPret DataPret { get; }
        public DataGridAdherent DataAdherent { get; }
        public Auteur AuteurSelect { get; set; } = new();
        public Livre LivreSelect { get; set; } = new();
        public Genre GenreSelect { get; set; } = new();
        public Adherent AdherentSelect { get; set; } = new();
        public Pret PretSelect { get; set; } = new();
        public string TypeList { get; }

        public MainMenuStrip(DataGridAuteur dataAuteur, Form1 mainForm, string typeList, DataGridLivre dataLivre, DataGridGenre dataGenre, DataGridAdherent dataAdherent, DataGridPret dataPret)
        {
            DataAuteur = dataAuteur;
            _mainForm = mainForm;
            TypeList = typeList;
            DataLivre = dataLivre;
            DataGenre = dataGenre;
            DataAdherent = dataAdherent;
            DataPret = dataPret;
            Name = "MainMenuStrip";
            Padding = new Padding(6, 2, 0, 2);
            Location = new Point(0, 0);
            BackColor =  Color.FromArgb(58, 68, 63);
            Font = new Font(Font.FontFamily, 14);
            Font = new Font(Font, FontStyle.Bold);
            ForeColor = Color.White;
            FileDropDownMenu();
        }

        private void FileDropDownMenu()
        {
            var fileDropDownMenuItem = new ToolStripMenuItem(TypeList);
            var newItem = new ToolStripMenuItem("Nouveau", null, null, Keys.Control | Keys.N);
            var seeItem = new ToolStripMenuItem("Afficher", null, null, Keys.Control | Keys.Enter);
            var deleteItem = new ToolStripMenuItem("Surpprimer", null, null, Keys.Control | Keys.Back);
            var editItem = new ToolStripMenuItem("Modifier", null, null, Keys.Control | Keys.E);
            var quitMenu = new ToolStripMenuItem("Quitter",null, null, Keys.Control | Keys.Tab);

            switch (TypeList)
            {
                case "Auteurs":
                    seeItem.Click += (_, _) =>
                    {
                        SeeAuteur();
                    };
            
                    editItem.Click += (_, _) =>
                    {
                        EditAuteur();
                    };
                
                    newItem.Click += (_, _) =>
                    {
                        NewAuteur();
                    };

                    deleteItem.Click += (_, _) =>
                    {
                        DeleteAuteur();
                    };
                    break;
                case "Livres":
                    seeItem.Click += (_, _) =>
                    {
                        SeeLivre();
                    };
            
                    editItem.Click += (_, _) =>
                    {
                        EditLivre();
                    };

                    newItem.Click += (_, _) =>
                    {
                        NewLivre();
                    };

                    deleteItem.Click += (_, _) =>
                    {
                        DeleteLivre();
                    };
                    break;
                case "Genres":
                    seeItem.Click += (_, _) =>
                    {
                        SeeGenre();
                    };
            
                    editItem.Click += (_, _) =>
                    {
                        EditGenre();
                    };
                
                    newItem.Click += (_, _) =>
                    {
                        NewGenre();
                    };

                    deleteItem.Click += (_, _) =>
                    {
                        DeleteGenre();
                    };
                    break;
                case "Prets":
                    seeItem.Click += (_, _) =>
                    {
                        SeePret();
                    };
            
                    editItem.Click += (_, _) =>
                    {
                    };
                
                    newItem.Click += (_, _) =>
                    {
                    
                    };

                    deleteItem.Click += (_, _) =>
                    {
                    };
                    break;
                case "Adherents":
                    seeItem.Click += (_, _) =>
                    {
                        SeeAdherent();
                    };
            
                    editItem.Click += (_, _) =>
                    {
                        EditAdherent();
                    };
                
                    newItem.Click += (_, _) =>
                    {
                        NewAdherent();
                    };

                    deleteItem.Click += (_, _) =>
                    {
                        DeleteAdherent();
                    };
                    break;
            }

            quitMenu.Click += (_, _) =>
            {
                try
                {
                    _mainForm.Custom();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            };
            
            fileDropDownMenuItem.DropDownItems.AddRange(new ToolStripItem[] { seeItem, newItem, editItem , deleteItem, quitMenu });

            Items.Add(fileDropDownMenuItem);
        }

        private void SeeAuteur()
        {
            try
            {
                DataGridViewRow monAuteur = DataAuteur.SelectedRows[0];
                AuteurSelect = monAuteur.DataBoundItem as Auteur;
                if (AuteurSelect == null) return;
                try
                {
                    FicheAuteur frm = new FicheAuteur(false, AuteurSelect);
                    frm.ShowDialog();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditAuteur()
        {
            try
            {
                DataGridViewRow monAuteur = DataAuteur.SelectedRows[0];
                AuteurSelect = monAuteur.DataBoundItem as Auteur;
                if (AuteurSelect == null) return;
                FicheAuteur frm = new FicheAuteur(true, AuteurSelect);
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void DeleteAuteur()
        {
            try
            {
                DeleteAuteur frm = new DeleteAuteur(DataAuteur.IntAuteur());
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void NewAuteur()
        {
            try
            {
                if (AuteurSelect != null)
                {
                    FicheAuteur frm = new FicheAuteur(true, AuteurSelect);
                    frm.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SeeLivre()
        {
            try
            {
                DataGridViewRow monLivre = DataLivre.SelectedRows[0];
                int numL = Convert.ToInt32(monLivre.Cells["num"].Value);
                LivreSelect = ManagerLivre.FindLivre_ByID(numL);
                if (LivreSelect != null)
                {
                    try
                    {
                        FicheLivre frm = new FicheLivre(false, LivreSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"La fiche ne marche pas");
                    }
                }
                else
                {
                    MessageBox.Show(@"Livre null");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"SeeLivre marche pas");
            }
        }

        private void EditLivre()
        {
            try
            {
                DataGridViewRow monLivre = DataLivre.SelectedRows[0];
                int numL = Convert.ToInt32(monLivre.Cells["num"].Value);
                LivreSelect = ManagerLivre.FindLivre_ByID(numL);
                if (LivreSelect != null)
                {
                    try
                    {
                        FicheLivre frm = new FicheLivre(true, LivreSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    MessageBox.Show(@"Livre null");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"EditLivre marche pas");
            }
        }

        private void NewLivre()
        {
            try
            {
                if (LivreSelect == null) return;
                FicheLivre frm = new FicheLivre(true, LivreSelect);
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteLivre()
        {
            try
            {
                DeleteLivre frm = new DeleteLivre(DataLivre.IntLivre());
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SeeGenre()
        {
            try
            {
                DataGridViewRow monGenre = DataGenre.SelectedRows[0];
                GenreSelect = monGenre.DataBoundItem as Genre;
                if (GenreSelect == null) return;
                try
                {
                    FicheGenre frm = new FicheGenre(false, GenreSelect);
                    frm.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(GenreSelect.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditGenre()
        {
            try
            {
                DataGridViewRow monGenre = DataGenre.SelectedRows[0];
                GenreSelect = monGenre.DataBoundItem as Genre;
                if (GenreSelect == null) return;
                try
                {
                    FicheGenre frm = new FicheGenre(true, GenreSelect);
                    frm.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(GenreSelect.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void NewGenre()
        {
            try
            {
                if (AuteurSelect == null) return;
                FicheGenre frm = new FicheGenre(true, GenreSelect);
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteGenre()
        {
            try
            {
                DeleteGenre frm = new DeleteGenre(DataGenre.IntGenre());
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SeeAdherent()
        {
            try
            {
                DataGridViewRow monAdherent = DataAdherent.SelectedRows[0];
                AdherentSelect = monAdherent.DataBoundItem as Adherent;
                if (AdherentSelect == null) return;
                try
                {
                    FicheAdherent frm = new FicheAdherent(false, AdherentSelect);
                    frm.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(AdherentSelect.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditAdherent()
        {
            try
            {
                DataGridViewRow monAdherent = DataAdherent.SelectedRows[0];
                AdherentSelect = monAdherent.DataBoundItem as Adherent;
                if (AdherentSelect == null) return;
                try
                {
                    FicheAdherent frm = new FicheAdherent(true, AdherentSelect);
                    frm.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(GenreSelect.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void NewAdherent()
        {
            try
            {
                if (AdherentSelect == null) return;
                FicheAdherent frm = new FicheAdherent(true, AdherentSelect);
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteAdherent()
        {
            try
            {
                DeleteAdherent frm = new DeleteAdherent(DataAdherent.IntAdherent());
                frm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SeePret()
        {
            try
            {
                DataGridViewRow monPret = DataPret.SelectedRows[0];
                int numL = Convert.ToInt32(monPret.Cells["num"].Value);
                PretSelect = ManagerPret.FindPret_ByID(numL);
                if (PretSelect != null)
                {
                    try
                    {
                        FichePret frm = new FichePret(false, PretSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"La fiche ne marche pas");
                    }
                }
                else
                {
                    MessageBox.Show(@"Livre null");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"SeeLivre marche pas");
            }
        }
    }
}