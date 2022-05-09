using System;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private MainMenuStrip _menuStrip;
        public DataGridAuteur DataAuteur { get; private set; }
        public DataGridLivre DataLivre { get; private set; }
        public DataGridGenre DataGenre { get; private set; }
        public DataGridAdherent DataAdherent { get; private set; }
        public DataGridPret DataPret { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataAuteur = new DataGridAuteur();
            _menuStrip = new MainMenuStrip(DataAuteur, this, "Auteurs", DataLivre, DataGenre, DataAdherent, DataPret);
            Controls.Clear();
            Controls.AddRange(new Control [] {DataAuteur, _menuStrip});
        }

        public void Custom()
        {
            Controls.Clear();
            Controls.AddRange(new Control[] {btn_list_auteurs, btn_list_livre, btn_genre, btn_adherents, btn_close, DataPret});
        }

        private void btn_list_livre_Click(object sender, EventArgs e)
        {
            DataLivre = new DataGridLivre();
            _menuStrip = new MainMenuStrip(DataAuteur, this, "Livres", DataLivre, DataGenre, DataAdherent, DataPret);
            Controls.Clear();
            Controls.AddRange(new Control [] {DataLivre, _menuStrip});
        }

        private void btn_genre_Click(object sender, EventArgs e)
        {
            try
            {
                DataGenre = new DataGridGenre();
                _menuStrip = new MainMenuStrip(DataAuteur, this, "Genres", DataLivre, DataGenre, DataAdherent, DataPret);
                Controls.Clear();
                Controls.AddRange(new Control [] {DataGenre, _menuStrip});
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception + "");
            }
            
        }

        private void btn_adherents_Click(object sender, EventArgs e)
        {
            try
            {
                DataAdherent = new DataGridAdherent();
                _menuStrip = new MainMenuStrip(DataAuteur, this, "Adherents", DataLivre, DataGenre, DataAdherent, DataPret);
                Controls.Clear();
                Controls.AddRange(new Control [] {DataAdherent, _menuStrip});
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception + "");
            }        
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_pret_Click(object sender, EventArgs e)
        {
            DataPret = new DataGridPret();
            _menuStrip = new MainMenuStrip(DataAuteur, this, "Prets", DataLivre, DataGenre, DataAdherent, DataPret);
            Controls.Clear();
            Controls.AddRange(new Control [] {DataPret, _menuStrip});
        }
    }
}