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
        public DataGridAdherent DataAdherent { get; }
        public Auteur AuteurSelect { get; set; } = new();
        public Livre LivreSelect { get; set; } = new();
        public Genre GenreSelect { get; set; } = new();
        public Adherent AdherentSelect { get; set; } = new();
        public string TypeList { get; }

        public MainMenuStrip(DataGridAuteur dataAuteur, Form1 mainForm, string typeList, DataGridLivre dataLivre, DataGridGenre dataGenre, DataGridAdherent dataAdherent)
        {
            DataAuteur = dataAuteur;
            _mainForm = mainForm;
            TypeList = typeList;
            DataLivre = dataLivre;
            DataGenre = dataGenre;
            DataAdherent = dataAdherent;
            Name = "MainMenuStrip";
            Padding = new Padding(6, 2, 0, 2);
            Location = new Point(0, 0);
            BackColor =  Color.FromArgb(58, 68, 63);
            Font = new Font(Font.FontFamily, 14);
            Font = new Font(Font, FontStyle.Bold);
            ForeColor = Color.White;
            FileDropDownMenu();
        }

        public void FileDropDownMenu()
        {
            var fileDropDownMenuItem = new ToolStripMenuItem(TypeList);
            var newItem = new ToolStripMenuItem("Nouveau", null, null, Keys.Control | Keys.N);
            var seeItem = new ToolStripMenuItem("Afficher", null, null, Keys.Control | Keys.Enter);
            var deleteItem = new ToolStripMenuItem("Surpprimer", null, null, Keys.Control | Keys.Back);
            var editItem = new ToolStripMenuItem("Modifier", null, null, Keys.Control | Keys.E);
            var quitMenu = new ToolStripMenuItem("Quitter",null, null, Keys.Control | Keys.Tab);

            if( TypeList == "Auteurs" )
            {
                seeItem.Click += (sender, e) =>
                {
                    SeeAuteur();
                };
            
                editItem.Click += (sender, e) =>
                {
                    EditAuteur();
                };
                
                newItem.Click += (sender, e) =>
                {
                    NewAuteur();
                };

                deleteItem.Click += (sender, e) =>
                {
                    DeleteAuteur();
                };
            }
            else if ( TypeList == "Livres" )
            {
                seeItem.Click += (sender, e) =>
                {
                    SeeLivre();
                };
            
                editItem.Click += (sender, e) =>
                {
                    EditLivre();
                };

                newItem.Click += (sender, e) =>
                {
                    NewLivre();
                };

                deleteItem.Click += (sender, e) =>
                {
                    DeleteLivre();
                };
            }
            else if ( TypeList == "Genres" )
            {
                seeItem.Click += (sender, e) =>
                {
                    SeeGenre();
                };
            
                editItem.Click += (sender, e) =>
                {
                    EditGenre();
                };
                
                newItem.Click += (sender, e) =>
                {
                    NewGenre();
                };

                deleteItem.Click += (sender, e) =>
                {
                    DeleteGenre();
                };
            }
            else if ( TypeList == "Prets" )
            {
                seeItem.Click += (sender, e) =>
                {
                };
            
                editItem.Click += (sender, e) =>
                {
                };
                
                newItem.Click += (sender, e) =>
                {
                    
                };

                deleteItem.Click += (sender, e) =>
                {
                };
            }
            else if ( TypeList == "Adherents" )
            {
                seeItem.Click += (sender, e) =>
                {
                    SeeAdherent();
                };
            
                editItem.Click += (sender, e) =>
                {
                    EditAdherent();
                };
                
                newItem.Click += (sender, e) =>
                {
                    NewAdherent();
                };

                deleteItem.Click += (sender, e) =>
                {
                    DeleteAdherent();
                };
            }

            quitMenu.Click += (sender, e) =>
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
        
        public void SeeAuteur()
        {
            try
            {
                DataGridViewRow monAuteur = DataAuteur.SelectedRows[0];
                AuteurSelect = monAuteur.DataBoundItem as Auteur;
                if (AuteurSelect != null)
                {
                    try
                    {
                        FicheAuteur frm = new FicheAuteur(false, AuteurSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(AuteurSelect.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void EditAuteur()
        {
            try
            {
                DataGridViewRow monAuteur = DataAuteur.SelectedRows[0];
                AuteurSelect = monAuteur.DataBoundItem as Auteur;
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
        
        
        public void DeleteAuteur()
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

        public void NewAuteur()
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
        
        public void SeeLivre()
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
                    catch (Exception e)
                    {
                        MessageBox.Show("La fiche ne marche pas");
                    }
                }
                else
                {
                    MessageBox.Show("Livre null");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("SeeLivre marche pas");
            }
        }
        public void EditLivre()
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
                    MessageBox.Show("Livre null");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("EditLivre marche pas");
            }
        }
        
        public void NewLivre()
        {
            try
            {
                if (LivreSelect != null)
                {
                    FicheLivre frm = new FicheLivre(true, LivreSelect);
                    frm.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void DeleteLivre()
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
        
        public void SeeGenre()
        {
            try
            {
                DataGridViewRow monGenre = DataGenre.SelectedRows[0];
                GenreSelect = monGenre.DataBoundItem as Genre;
                if (GenreSelect != null)
                {
                    try
                    {
                        FicheGenre frm = new FicheGenre(false, GenreSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(GenreSelect.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void EditGenre()
        {
            try
            {
                DataGridViewRow monGenre = DataGenre.SelectedRows[0];
                GenreSelect = monGenre.DataBoundItem as Genre;
                if (GenreSelect != null)
                {
                    try
                    {
                        FicheGenre frm = new FicheGenre(true, GenreSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(GenreSelect.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void NewGenre()
        {
            try
            {
                if (AuteurSelect != null)
                {
                    FicheGenre frm = new FicheGenre(true, GenreSelect);
                    frm.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void DeleteGenre()
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
        
        public void SeeAdherent()
        {
            try
            {
                DataGridViewRow monAdherent = DataAdherent.SelectedRows[0];
                AdherentSelect = monAdherent.DataBoundItem as Adherent;
                if (AdherentSelect != null)
                {
                    try
                    {
                        FicheAdherent frm = new FicheAdherent(false, AdherentSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(AdherentSelect.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void EditAdherent()
        {
            try
            {
                DataGridViewRow monAdherent = DataAdherent.SelectedRows[0];
                AdherentSelect = monAdherent.DataBoundItem as Adherent;
                if (AdherentSelect != null)
                {
                    try
                    {
                        FicheAdherent frm = new FicheAdherent(true, AdherentSelect);
                        frm.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(GenreSelect.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void NewAdherent()
        {
            try
            {
                if (AdherentSelect != null)
                {
                    FicheAdherent frm = new FicheAdherent(true, AdherentSelect);
                    frm.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void DeleteAdherent()
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
    }
}