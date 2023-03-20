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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BddpersonnelContext;
using biblioBDDpersonnels;

namespace appliWPFBDDpersonnels
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CBDDPersonnels bddpersonnels = null;
        public MainWindow()
        {
            InitializeComponent(); // toujours en premier NE PAS TOUCHER

            List<Service> services = RecupererLesServices();
            TrierLesServices(services);
            AfficherServices(services, comboboxServices);

            List<Fonction> fonctions = RecupererLesFonctions();
            TrierLesFonctions(fonctions);
            AfficherFonctions(fonctions, comboboxFonctions);

        }


        public void AfficherServices(List<Service> services, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Defaut");
            foreach (var service in services)
            {
                comboBox.Items.Add(service.Intitule);
            }
        }

        public void AfficherFonctions(List<Fonction> fonctions, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Defaut");
            foreach (var fonction in fonctions)
            {
                comboBox.Items.Add(fonction.Intitule);
            }

        }


        public void TrierLesServices(List<Service> services)
        {
            services.Sort(Service.ComparerLabelServices);
        }

        public void TrierLesFonctions(List<Fonction> fonctions)
        {
            fonctions.Sort(Fonction.ComparerLabelFonctions);
        }


        public List<Service> RecupererLesServices()
        {
            bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
            List<Service> services = bddpersonnels.getAllServices(); // récupère une liste de tous les services
            return services;
        }

        public List<Fonction> RecupererLesFonctions()
        {
            bddpersonnels = new CBDDPersonnels();
            List<Fonction> fonctions = bddpersonnels.getAllFonctions();
            return fonctions;
        }


        public List<Personnel> RecupererLesPersonnels()
        {
            bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
            List<Personnel> personnels = bddpersonnels.getAllPersonnels();
            return personnels;
        }


        public void AfficherLesPersonnelsParServices(List<Personnel> personnels, ListView listview, ComboBox comboBoxServices, string service)
        {
            comboBoxServices.SelectedItem = service;
            listview.Items.Clear();
            foreach (var personnel in personnels)
            {
                    if(comboBoxServices.SelectedItem.ToString() == personnel.Service.Intitule)
                    {
                        listview.Items.Add(personnel.Nom + " " + personnel.Prenom);
                    }                
            }
        }

        public void AfficherLesPersonnelsParFonctions(List<Personnel> personnels, ListView listview, ComboBox comboBoxFonctions, string fonctions)
        {
            comboBoxFonctions.SelectedItem = fonctions;
            listview.Items.Clear();
            foreach (var personnel in personnels)
            {
                if (comboBoxFonctions.SelectedItem.ToString() == personnel.Fonction.Intitule)
                {
                    listview.Items.Add(personnel.Nom + " " + personnel.Prenom);
                }
            }
        }


        private void comboboxServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxServices.SelectedItem.ToString() == "Defaut")
            {
                comboboxFonctions.IsEnabled = true;
            }
            else
            {
                comboboxFonctions.IsEnabled = false;
                comboboxServices.IsEnabled = true;
                List<Personnel> personnels = RecupererLesPersonnels();
                AfficherLesPersonnelsParServices(personnels, listeviewPersonnels, comboboxServices, comboboxServices.SelectedItem.ToString());
            }
        }

        private void comboboxFonctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxFonctions.SelectedItem.ToString() == "Defaut")
            {
                comboboxServices.IsEnabled = true;
            }
            else
            {

                comboboxServices.IsEnabled = false;
                comboboxFonctions.IsEnabled = true;
                List<Personnel> personnels = RecupererLesPersonnels();
                AfficherLesPersonnelsParFonctions(personnels, listeviewPersonnels, comboboxFonctions, comboboxFonctions.SelectedItem.ToString());
            }
        }

        private void listeviewPersonnels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           string personnel = listeviewPersonnels.SelectedItem.ToString();
            PageUtilisateur pageUtilisateur = new PageUtilisateur(personnel);
            pageUtilisateur.ShowDialog();
        }
    }
}
