using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        /// <summary>
        /// Fenêtre principale de l'application
        /// </summary>
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

        /// <summary>
        /// Affiche les services dans la combobox correspondante
        /// </summary>
        /// <param name="services">Liste de services</param>
        /// <param name="comboBox">Combobox pour l'affichage</param>
        public void AfficherServices(List<Service> services, ComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear(); // Nettoie la combobox
                //comboBox.SelectedValue = ""; // Met la valeur a vide
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
        /// <summary>
        /// Affiche les fonctions dans la combobox correspondante
        /// </summary>
        /// <param name="fonctions">Liste des fonctions</param>
        /// <param name="comboBox">Combobox fonctions</param>
        public void AfficherFonctions(List<Fonction> fonctions, ComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear(); // Nettoie la combobox
                //comboBox.SelectedValue = ""; // Met la valeur a vide
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

        /// <summary>
        /// Depuis une liste de tous les personnels, ne renvoie que ceux dont le service correspond au paramètre passé
        /// </summary>
        /// <param name="personnels">Liste des personnels</param>
        /// <param name="listview">ListeView pour l'affichage</param>
        /// <param name="comboBoxServices">Combobox des services</param>
        public void AfficherLesPersonnelsParServices(List<Personnel> personnels, ListView listview, ComboBox comboBoxServices)
        {
            try
            {
                listview.Items.Clear(); // Nettoie la listeview
                if (comboboxServices.HasItems == false)
                {
                    comboboxServices.SelectedIndex = 0;
                }
                foreach (var personnel in personnels) // pour chaque personnel de la liste
                {         
                    if (comboBoxServices.SelectedItem == null || comboBoxServices.SelectedItem.ToString() == personnel.Service.Intitule || comboboxServices.SelectedItem.ToString() == "Tous")
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
        /// <summary>
        /// Depuis une liste de tous les personnels, ne renvoie que ceux dont la fonction correspond au paramètre passé
        /// </summary>
        /// <param name="personnels">Liste des personnels</param>
        /// <param name="listview">ListeView a utiliser</param>
        /// <param name="comboBoxFonctions">Combobox fonctions</param>
        public void AfficherLesPersonnelsParFonctions(List<Personnel> personnels, ListView listview, ComboBox comboBoxFonctions)
        {
            try
            {
                listview.Items.Clear(); // Nettoie la listeview
                if (comboBoxFonctions.HasItems == false)
                {
                    comboBoxFonctions.SelectedIndex = 0;
                }
                foreach (var personnel in personnels) // pour chaque personnel dans la liste
                {
                    if (comboBoxFonctions.SelectedItem == null || comboBoxFonctions.SelectedItem.ToString() == personnel.Fonction.Intitule || comboBoxFonctions.SelectedItem.ToString() == "Tous")
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

        /// <summary>
        /// quand la sélection du service change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (comboboxFonctions.SelectedItem == null || comboboxFonctions.SelectedItem.ToString() == "Tous")
                {
                    List<Personnel> personnels = bddpersonnels.RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParServices(personnels, listeviewPersonnels, comboboxServices);
                }
                else
                {
                    List<Personnel> TousLesPersonnels = bddpersonnels.RecupererLesPersonnels();
                    for (int i = TousLesPersonnels.Count; i >0; i--)
                    {
                        if (TousLesPersonnels[i-1].Fonction.Intitule.ToString() != comboboxFonctions.SelectedItem.ToString())
                        {
                            TousLesPersonnels.Remove(TousLesPersonnels[i-1]);
                        }
                    }
                    AfficherLesPersonnelsParServices(TousLesPersonnels, listeviewPersonnels, comboboxServices);
                }
                // on affiche les personnels correspondants au service sélectionné
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// quand la sélection de la fonction change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxFonctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (comboboxServices.SelectedItem == null || comboboxServices.SelectedItem.ToString() == "Tous")
                {
                    List<Personnel> personnels = bddpersonnels.RecupererLesPersonnels(); // on récupère les personnels
                    AfficherLesPersonnelsParFonctions(personnels, listeviewPersonnels, comboboxFonctions);
                    // on affiche les personnels correspondants à la fonction sélectionnée
                }
                else
                {
                    List<Personnel> TousLesPersonnels = bddpersonnels.RecupererLesPersonnels();
                    for (int i = TousLesPersonnels.Count; i>0;i--)
                    {
                        if (TousLesPersonnels[i-1].Service.Intitule.ToString() != comboboxServices.SelectedItem.ToString())
                        {
                            TousLesPersonnels.Remove(TousLesPersonnels[i-1]);
                        }
                    }
                    AfficherLesPersonnelsParFonctions(TousLesPersonnels, listeviewPersonnels, comboboxFonctions);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///  quand on clique sur un personnel de la listeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listeviewPersonnels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        /// <summary>
        /// quand le text de recherche change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                List<Personnel> filtre = new List<Personnel>();
                string Name = inputNom.Text.Trim().ToLower();
                listeviewPersonnels.Items.Clear();
                foreach(var personne in bddpersonnels.getAllPersonnels())
                {
                    if (!String.IsNullOrEmpty(Name) && personne.Nom.ToLower().Contains(Name))
                    {
                        filtre.Add(personne);
                    }
                    else if (!String.IsNullOrEmpty(Name) && personne.Prenom.ToLower().Contains(Name))
                    {
                        filtre.Add(personne);
                    }
                }
                foreach(var personne in filtre)
                {
                    listeviewPersonnels.Items.Add(personne.Nom.ToString() + " " + personne.Prenom.ToString());
                }
               /* if (inputNom.Text != "") // vérifie l'input
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
                    /*List<Service> services = bddpersonnels.RecupererLesServices();
                    bddpersonnels.TrierLesServices(services);
                    AfficherServices(services, comboboxServices);

                    List<Fonction> fonctions = bddpersonnels.RecupererLesFonctions();
                    bddpersonnels.TrierLesFonctions(fonctions);
                    AfficherFonctions(fonctions, comboboxFonctions);
                }*/
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Boutton Quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void comboboxServices_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                var combobox = comboboxServices;
                if (combobox.IsInitialized == false)
                {
                    throw new Exception("La combobox n'est pas initialisée");
                }
                if (combobox.HasItems == false)
                {
                    throw new Exception("La combobox ne dispose d'aucuns items");
                }
                combobox.IsDropDownOpen = true;
                //comboboxNouveau.
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source+" indique :", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
         }

        private void comboboxServices_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var combobox = comboboxServices;
                if (combobox.IsDropDownOpen == true)
                {
                    combobox.IsDropDownOpen = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void comboboxServices_Initialized(object sender, EventArgs e)
        {
            comboboxServices.MaxDropDownHeight = 1080;
        }

        private void comboboxFonctions_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                var combobox = comboboxFonctions;
                if (combobox.IsInitialized == false)
                {
                    throw new Exception("La combobox n'est pas initialisée");
                }
                if (combobox.HasItems == false)
                {
                    throw new Exception("La combobox ne dispose d'aucuns items");
                }
                combobox.IsDropDownOpen = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " indique :", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void comboboxFonctions_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var combobox = comboboxFonctions;
                if (combobox.IsDropDownOpen == true)
                {
                    combobox.IsDropDownOpen = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void comboboxFonctions_Initialized(object sender, EventArgs e)
        {
            comboboxFonctions.MaxDropDownHeight = 1080;
        }


    }
}
