using BddpersonnelContext;
using biblioBDDpersonnels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace appliWPFBDDpersonnels
{
    /// <summary>
    /// Logique d'interaction pour PageUtilisateur.xaml
    /// </summary>
    public partial class PageUtilisateur : Window
    {
        private string _personnel = null;
        private CBDDPersonnels bddpersonnels = null;
        public PageUtilisateur(string personnel)
        {
            InitializeComponent();
            _personnel = personnel;
            AfficherNom(personnel);
            AfficherPrenom(personnel);
        }

        public void AfficherNom(string personnel)
        {
            string Nom = personnel.Split(' ')[0].ToUpper();
            List<Personnel> personnels = RecupererLesPersonnels();
            foreach (var personne in personnels)
            {
                if (personne.Nom.ToString() == Nom)
                {

                }
            }
        }

        public void AfficherPrenom(string personnel)
        {
            labelPrenomPersonnels.Content = personnel.Split(' ')[1];
        }

        public List<Personnel> RecupererLesPersonnels()
        {
            bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
            List<Personnel> personnels = bddpersonnels.getAllPersonnels();
            return personnels;
        }
    }
}
