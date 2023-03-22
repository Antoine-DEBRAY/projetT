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

            List<Service> services = RecupererLesServices(); // Récupère les services
            TrierLesServices(services); // Trie les services
            AfficherServices(services, comboboxServices); // Affiche les services dans la combobox

            List<Fonction> fonctions = RecupererLesFonctions(); // Récupère les fonctions
            TrierLesFonctions(fonctions); // Trie les fonctions
            AfficherFonctions(fonctions, comboboxFonctions); // Affiche les fonction dans la combobox

        }


        public void AfficherServices(List<Service> services, ComboBox comboBox) // Affiche les services dans la combobox
        {
            comboBox.Items.Clear(); // Nettoie la combobox
            comboBox.SelectedValue = ""; // Met la valeur a vide
            foreach (var service in services) // pour chaque service de la liste
            {
                comboBox.Items.Add(service.Intitule); // on l'ajoute dans le combobox
            }
        }

        public void AfficherFonctions(List<Fonction> fonctions, ComboBox comboBox) // Affiche les fonction dans la combobox
        {
            comboBox.Items.Clear(); // Nettoie la combobox
            comboBox.SelectedValue = ""; // Met la valeur a vide
            foreach (var fonction in fonctions) // pour chaque fonction de la liste
            {
                comboBox.Items.Add(fonction.Intitule); // on l'ajoute dans le combobox
            }

        }


        public void TrierLesServices(List<Service> services) // Trie les services
        {
            services.Sort(Service.ComparerLabelServices);
        }

        public void TrierLesFonctions(List<Fonction> fonctions) // Trie les fonctions
        {
            fonctions.Sort(Fonction.ComparerLabelFonctions);
        }


        public List<Service> RecupererLesServices() // Récupère tous les services
        {
            bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
            List<Service> services = bddpersonnels.getAllServices(); // récupère une liste de tous les services
            return services;
        }

        public List<Fonction> RecupererLesFonctions() // Récupère toutes les fonctions
        {
            bddpersonnels = new CBDDPersonnels(); // initialise la classe, se connecte à la BDD
            List<Fonction> fonctions = bddpersonnels.getAllFonctions(); // récupère une liste de toutes les fonctions
            return fonctions;
        }


        public List<Personnel> RecupererLesPersonnels()
        {
            bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
            List<Personnel> personnels = bddpersonnels.getAllPersonnels(); // récupère une liste de tous les personnels
            return personnels;
        }


        public void AfficherLesPersonnelsParServices(List<Personnel> personnels, ListView listview, ComboBox comboBoxServices, string service)
        { // Depuis une liste de tous les personnels, ne renvoie que ceux dont le service correspond au paramètre passé
            comboBoxServices.SelectedItem = service; // Affiche le bon service dans la combobox
            listview.Items.Clear(); // Nettoie la listeview
            foreach (var personnel in personnels) // pour chaque personnel de la liste
            {
                    if(comboBoxServices.SelectedItem.ToString() == personnel.Service.Intitule || comboboxServices.SelectedValue.ToString() == "")
                    { // 2 cas possible : soit il y a un item selectionné et on affiche le personnel correspond soit l'item sélectionné est "" est on affiche tout
                        listview.Items.Add(personnel.Nom + " " + personnel.Prenom); // affiche le nom et le prenom de la personne
                    }                
            }
        }

        public void AfficherLesPersonnelsParFonctions(List<Personnel> personnels, ListView listview, ComboBox comboBoxFonctions, string fonctions)
        { // Depuis une liste de tous les personnels, ne renvoie que ceux dont la fonction correspond au paramètre passé
            comboBoxFonctions.SelectedItem = fonctions; // Affiche la bonne fonction dans la combobox
            listview.Items.Clear(); // Nettoie la listeview
            foreach (var personnel in personnels) // pour chaque personnel dans la liste
            {
                if (comboBoxFonctions.SelectedItem.ToString() == personnel.Fonction.Intitule || comboboxFonctions.SelectedValue.ToString() == "")
                { // 2 cas possible: soit il y a un item selectionné et on affiche le personnel correspondant soit l'item sélectionné est "" est on affiche tout
                    listview.Items.Add(personnel.Nom + " " + personnel.Prenom); // affiche le nom et le prénom de la personne 
                }
            }
        }


        private void comboboxServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // quand la sélection du service change
            try
            {
                if (comboboxServices.SelectedValue.ToString() == "") // Si l'item sélectionné est le défaut
                {
                    List<Personnel> personnels = RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParServices(personnels, listeviewPersonnels, comboboxServices, comboboxServices.SelectedItem.ToString());
                } // on affiche tous les personnels
                else
                {
                    comboboxFonctions.SelectedValue = ""; // on change l'item sélectionné de l'autre combobox
                    List<Personnel> personnels = RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParServices(personnels, listeviewPersonnels, comboboxServices, comboboxServices.SelectedItem.ToString());
                } // on affiche les personnels correspondants au service sélectionné
            }
            catch (NullReferenceException ex)
            {
                // Quand le comboboxServices.SelectedItem n'existe pas
            }
        }

        private void comboboxFonctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // quand la sélection de la fonction change
            try
            {
                if (comboboxFonctions.SelectedValue.ToString() == "") // si l'item sélectionné est le défaut
                {
                    List<Personnel> personnels = RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParFonctions(personnels, listeviewPersonnels, comboboxFonctions, comboboxFonctions.SelectedItem.ToString());
                } // on affiche tous les personnels
                else
                { 
                    comboboxServices.SelectedValue = ""; // on change l'item sélectionné de l'autre combobox
                    List<Personnel> personnels = RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParFonctions(personnels, listeviewPersonnels, comboboxFonctions, comboboxFonctions.SelectedItem.ToString());
                } // on affiche les personnels correspondants à la fonction sélectionnée
            }
            catch (NullReferenceException ex)
            {
                // Quand le comboboxFonctions.SelectedItem n'existe pas
            }
        }

        private void listeviewPersonnels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // quand on clique sur un personnel de la listeview
            string personnel; // string correspondant au nom du personnel
            try
            {
                if (listeviewPersonnels.SelectedItem != null)
                {
                    personnel = listeviewPersonnels.SelectedItem.ToString(); // enregisre le nom du personnel
                    PageUtilisateur pageUtilisateur = new PageUtilisateur(personnel); // créer une page d'affichage du personnel sélectionné
                    pageUtilisateur.ShowDialog(); // affiche la page
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void inputNom_TextChanged(object sender, TextChangedEventArgs e)
        { // quand le text de recherche change
            try
            {
                if (inputNom.Text != "") // vérifie l'input
                {
                    for (int i = listeviewPersonnels.Items.Count - 1; i >= 0; i--)
                    {
                        var item = listeviewPersonnels.Items[i];
                        if (item.ToString().ToLower().Contains(inputNom.Text.ToLower()))
                        {

                        }
                        else
                        {
                            listeviewPersonnels.Items.Remove(item);
                        }
                    }
                }
                else
                {
                    List<Service> services = RecupererLesServices();
                    TrierLesServices(services);
                    AfficherServices(services, comboboxServices);

                    List<Fonction> fonctions = RecupererLesFonctions();
                    TrierLesFonctions(fonctions);
                    AfficherFonctions(fonctions, comboboxFonctions);
                    AfficherLesPersonnelsParFonctions(RecupererLesPersonnels(), listeviewPersonnels, comboboxFonctions, "");
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void boutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
