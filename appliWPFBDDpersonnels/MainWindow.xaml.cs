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
            try
            {
                bddpersonnels = new CBDDPersonnels();
                List<Service> services = bddpersonnels.RecupererLesServices(); // Récupère les services
                bddpersonnels.TrierLesServices(services); // Trie les services
                AfficherServices(services, comboboxServices); // Affiche les services dans la combobox

                List<Fonction> fonctions = bddpersonnels.RecupererLesFonctions(); // Récupère les fonctions
                bddpersonnels.TrierLesFonctions(fonctions); // Trie les fonctions
                AfficherFonctions(fonctions, comboboxFonctions); // Affiche les fonction dans la combobox
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void AfficherServices(List<Service> services, ComboBox comboBox) // Affiche les services dans la combobox
        {
            try
            {
                comboBox.Items.Clear(); // Nettoie la combobox
                comboBox.SelectedValue = ""; // Met la valeur a vide
                foreach (var service in services) // pour chaque service de la liste
                {
                    comboBox.Items.Add(service.Intitule); // on l'ajoute dans le combobox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AfficherFonctions(List<Fonction> fonctions, ComboBox comboBox) // Affiche les fonction dans la combobox
        {
            try
            {
                comboBox.Items.Clear(); // Nettoie la combobox
                comboBox.SelectedValue = ""; // Met la valeur a vide
                foreach (var fonction in fonctions) // pour chaque fonction de la liste
                {
                    comboBox.Items.Add(fonction.Intitule); // on l'ajoute dans le combobox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        


        public void AfficherLesPersonnelsParServices(List<Personnel> personnels, ListView listview, ComboBox comboBoxServices, string service)
        { // Depuis une liste de tous les personnels, ne renvoie que ceux dont le service correspond au paramètre passé
            //comboBoxServices.SelectedItem = service; // Affiche le bon service dans la combobox
            try
            {
                listview.Items.Clear(); // Nettoie la listeview
                foreach (var personnel in personnels) // pour chaque personnel de la liste
                {
                    if (comboboxServices.SelectedValue == null || comboboxServices.SelectedValue.ToString() == "" || comboBoxServices.SelectedItem.ToString() == personnel.Service.Intitule)
                    { // 2 cas possible : soit il y a un item selectionné et on affiche le personnel correspond soit l'item sélectionné est "" est on affiche tout
                        listview.Items.Add(personnel.Nom + " " + personnel.Prenom); // affiche le nom et le prenom de la personne
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AfficherLesPersonnelsParFonctions(List<Personnel> personnels, ListView listview, ComboBox comboBoxFonctions, string fonctions)
        { // Depuis une liste de tous les personnels, ne renvoie que ceux dont la fonction correspond au paramètre passé
            try
            {
                listview.Items.Clear(); // Nettoie la listeview
                foreach (var personnel in personnels) // pour chaque personnel dans la liste
                {
                    if (comboboxFonctions.SelectedValue == null || comboboxFonctions.SelectedValue.ToString() == "" || comboBoxFonctions.SelectedItem.ToString() == personnel.Fonction.Intitule)
                    { // 2 cas possible: soit il y a un item selectionné et on affiche le personnel correspondant soit l'item sélectionné est "" est on affiche tout
                        listview.Items.Add(personnel.Nom + " " + personnel.Prenom); // affiche le nom et le prénom de la personne 
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboboxServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // quand la sélection du service change
            try
            {
                if (comboboxServices.SelectedValue == null) // Si l'item sélectionné est le défaut
                {
                    comboboxServices.SelectedValue = "";
                    List<Personnel> personnels = bddpersonnels.RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParServices(personnels, listeviewPersonnels, comboboxServices, "");
                } // on affiche tous les personnels
                else
                {
                    comboboxFonctions.SelectedValue = ""; // on change l'item sélectionné de l'autre combobox
                    List<Personnel> personnels = bddpersonnels.RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParServices(personnels, listeviewPersonnels, comboboxServices, comboboxServices.SelectedItem.ToString());
                } // on affiche les personnels correspondants au service sélectionné
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboboxFonctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { // quand la sélection de la fonction change
            try
            {
                if (comboboxFonctions.SelectedValue == null)
                {
                    comboboxFonctions.SelectedValue = "";
                    List<Personnel> personnels = bddpersonnels.RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParFonctions(personnels, listeviewPersonnels, comboboxFonctions, "");
                } // on affiche tous les personnels
                else
                { 
                    comboboxServices.SelectedValue = ""; // on change l'item sélectionné de l'autre combobox
                    List<Personnel> personnels = bddpersonnels.RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParFonctions(personnels, listeviewPersonnels, comboboxFonctions, comboboxFonctions.SelectedItem.ToString());
                } // on affiche les personnels correspondants à la fonction sélectionnée
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    List<Service> services = bddpersonnels.RecupererLesServices();
                    bddpersonnels.TrierLesServices(services);
                    AfficherServices(services, comboboxServices);

                    List<Fonction> fonctions = bddpersonnels.RecupererLesFonctions();
                    bddpersonnels.TrierLesFonctions(fonctions);
                    AfficherFonctions(fonctions, comboboxFonctions);
                    AfficherLesPersonnelsParFonctions(bddpersonnels.RecupererLesPersonnels(), listeviewPersonnels, comboboxFonctions, "");
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void boutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
