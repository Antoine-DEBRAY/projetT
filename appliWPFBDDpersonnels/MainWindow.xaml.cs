using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

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
                bddpersonnels = new CBDDPersonnels(); // connection à la bdd
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
                comboBox.SelectedIndex = 0; // on selectionne "Tous"
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
                comboBox.SelectedIndex = 0; // on selectionne "tous"
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
                if (comboboxServices.SelectedItem == null) // si il n'y a aucun service selectionné
                {
                    comboboxServices.SelectedIndex = 0; // on sélectionne "Tous"
                }
                foreach (var personnel in personnels) // pour chaque personnel de la liste
                {         
                    if (comboBoxServices.SelectedItem.ToString() == personnel.Service.Intitule || comboboxServices.SelectedItem.ToString() == "Tous")
                    { // 2 cas possible : soit il y a un item selectionné et on affiche le personnel correspond soit l'item sélectionné est "Tous" et on affiche tout
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
                if (comboBoxFonctions.SelectedItem == null) // si il n'y a auncune fonction selectionné
                {
                    comboBoxFonctions.SelectedIndex = 0; // on sélectionne "Tous"
                }
                foreach (var personnel in personnels) // pour chaque personnel dans la liste
                {
                    if (comboBoxFonctions.SelectedItem.ToString() == personnel.Fonction.Intitule || comboBoxFonctions.SelectedItem.ToString() == "Tous")
                    { // 2 cas possible: soit il y a un item selectionné et on affiche le personnel correspondant soit l'item sélectionné est "Tous" et on affiche tout
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
                listeviewPersonnels.SelectedItem = null;
                List<Personnel> TousLesPersonnels = bddpersonnels.RecupererLesPersonnels(); // recupere les personnels
                if (comboboxFonctions.SelectedItem == null || comboboxFonctions.SelectedItem.ToString() == "Tous") // si aucun ou toutes les fonctions sont sélectionnées
                {
                    AfficherLesPersonnelsParServices(TousLesPersonnels, listeviewPersonnels, comboboxServices); // on affiche les personnels
                }
                else // si il y a une fonction de selectionné
                {                    
                    for (int i = TousLesPersonnels.Count; i >0; i--) // pour chaque personnel en partant de la fin
                    {
                        if (TousLesPersonnels[i-1].Fonction.Intitule.ToString() != comboboxFonctions.SelectedItem.ToString()) // si il ne correspond pas à la bonne fonction
                        {
                            TousLesPersonnels.Remove(TousLesPersonnels[i-1]); // on le retire
                        }
                    }
                    AfficherLesPersonnelsParServices(TousLesPersonnels, listeviewPersonnels, comboboxServices); // on affiche les personnels
                }
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
                listeviewPersonnels.SelectedItem = null;
                List<Personnel> TousLesPersonnels = bddpersonnels.RecupererLesPersonnels(); // recupere les personnels
                if (comboboxServices.SelectedItem == null || comboboxServices.SelectedItem.ToString() == "Tous") // si aucun ou tous les services sont selectionnes
                {
                    AfficherLesPersonnelsParFonctions(TousLesPersonnels, listeviewPersonnels, comboboxFonctions); // on affiche les personnels
                }
                else // si il y a un service de selectionné
                {                    
                    for (int i = TousLesPersonnels.Count; i>0;i--) // pour chaque personnel en partant de la fin
                    {
                        if (TousLesPersonnels[i-1].Service.Intitule.ToString() != comboboxServices.SelectedItem.ToString()) // si il ne correspond pas au bon service
                        {
                            TousLesPersonnels.Remove(TousLesPersonnels[i-1]); // on le retire
                        }
                    }
                    AfficherLesPersonnelsParFonctions(TousLesPersonnels, listeviewPersonnels, comboboxFonctions); // on affiche les personnels
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
                if (listeviewPersonnels.SelectedItem != null) // si l'item selectionné n'est pas null
                {
                    personnel = listeviewPersonnels.SelectedItem.ToString(); // enregisre le nom+prenom du personnel selectionné
                    var listepersonnels = bddpersonnels.getAllPersonnels(); // recupere tous les personnels
                    foreach(var personn in listepersonnels) // pour chaque personne de la liste
                    {
                        if (personnel.ToLower().ToString().Contains(personn.Nom.ToLower().ToString()) || personnel.ToLower().ToString().Contains(personn.Prenom.ToLower().ToString()))
                        { // si le personnel selectionné est dans la liste
                            if (personn.Photo != null) // si il possède une photo
                            {
                                var image = GetImageFromByte(personn.Photo); // on recupère la photo
                                imagePersonnels.Source = image; // on affiche la photo

                            }
                            else // si il ne possède pas de photo
                            {
                                var path = Path.Combine(Environment.CurrentDirectory, "no_photo.jpg"); // défini le chemin de la photo
                                var uri = new Uri(path); // défini la photo en tant que ressource compacte
                                var bitmap = new BitmapImage(uri); // défini la photo en tant que pixels bitmap
                                imagePersonnels.Source = bitmap; // affiche la photo
                            }                            
                            if (personn.Telephone != null && personn.Telephone != "") // si il possède un téléphone
                            {
                                labelPersonnels.Content = personn.Telephone; // on affiche la téléphone
                            }
                            else // si il ne possède pas de téléphone
                            {
                                labelPersonnels.Content = "Aucun numéro connu"; // pas de numéros
                            }
                            if (personn.Service.Intitule != null) // si il possède un service
                            {
                                labelService.Content = personn.Service.Intitule.ToString(); // on affiche le service
                            }
                            else // si il ne possède pas de service
                            {
                                labelService.Content = "Aucun service connu"; // pas de service
                            }
                            if (personn.Fonction.Intitule != null) // si il possède une fonction
                            {
                                labelFonction.Content = personn.Fonction.Intitule.ToString(); // on affiche la fonction
                            }
                            else // si il ne possède pas de fonction
                            {
                                labelFonction.Content = "Aucune fonction connue"; // pas de fonction
                            }                            
                        }
                    }
                }
                else
                {
                    imagePersonnels.Source = null;
                    labelPersonnels.Content = null;
                    labelService.Content = null;
                    labelFonction.Content = null;
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
                List<Personnel> filtre = new List<Personnel>(); // création de la liste que l'on va afficher
                string Name = inputNom.Text.Trim().ToLower(); // recuperation de l'input
                listeviewPersonnels.Items.Clear(); // on nettoie la listeview
                if (comboboxFonctions.SelectedItem.ToString() == "Tous" && comboboxServices.SelectedItem.ToString() == "Tous")
                { // si toutes les fonctions et tous les services sont selectionnes
                    foreach (var personne in bddpersonnels.getAllPersonnels()) // pour chaque personne de tous les personnels
                    {
                        if ((personne.Nom.ToLower().Contains(Name) || personne.Prenom.ToLower().Contains(Name)))
                        { // si cette personne contient l'input
                            filtre.Add(personne); // on l'ajoute au filtre
                        }
                    }
                }
                else if (comboboxFonctions.SelectedItem.ToString() == "Tous")
                { // sinon si toutes les fonction sont sélectionnées (et que tous les services ne le sont pas)
                    foreach (var personne in bddpersonnels.getAllPersonnels()) // pour chaque personne de tous les personnels
                    {
                        if ((personne.Nom.ToLower().Contains(Name) || personne.Prenom.ToLower().Contains(Name)) && personne.Service.Intitule.ToString() == comboboxServices.SelectedItem.ToString())
                        { // si cette personne contient l'input ET que son service correspond
                            filtre.Add(personne); // on l'ajoute au filtre
                        }
                    }
                }
                else if (comboboxServices.SelectedItem.ToString() == "Tous")
                { // sinon si tous les services sont selectionnés (et que toutes les fonctions ne le sont pas)
                    foreach(var personne in bddpersonnels.getAllPersonnels()) // pour chaque personne de tous les personnels
                    {
                        if ((personne.Nom.ToLower().Contains(Name) || personne.Prenom.ToLower().Contains(Name)) && personne.Fonction.Intitule.ToString() == comboboxFonctions.SelectedItem.ToString())
                        { // si cette personne contient l'input ET que sa fonction correspond
                            filtre.Add(personne); // on l'ajoute au filtre
                        }
                    }
                }
                else
                { // sinon si un certain service est selectionne et qu'une certaine fonction est selectionne
                    foreach(var personne in bddpersonnels.getAllPersonnels()) // pour chaque personne de tous les personnels
                    {
                        if ((personne.Nom.ToLower().Contains(Name) || personne.Prenom.ToLower().Contains(Name)) && personne.Fonction.Intitule.ToString() == comboboxFonctions.SelectedItem.ToString() && personne.Service.Intitule.ToString() == comboboxServices.SelectedItem.ToString())
                        { // si cette personne contient l'input ET que sa fonction correspond ET que son service correspond
                            filtre.Add(personne); // on l'ajoute au filtre
                        }
                    }
                }
                foreach(var personne in filtre) // pour chaque personne du filtre
                {
                    listeviewPersonnels.Items.Add(personne.Nom.ToString() + " " + personne.Prenom.ToString()); // on l'ajoute dans la listeview
                }
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
                Application.Current.Shutdown(); // on ferme l'application
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Fait descendre la liste des services au passage de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxServices_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                var combobox = comboboxServices; // selection de la combobox
                if (combobox.IsInitialized == false) // si jamais la combobox n'est pas initialisée
                {
                    throw new Exception("La combobox n'est pas initialisée");
                }
                if (combobox.HasItems == false) // si jamais la combobox ne contient aucun items
                {
                    throw new Exception("La combobox ne dispose d'aucuns items");
                }
                combobox.IsDropDownOpen = true; // on descend la combobox
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source+" indique :", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
         }
        /// <summary>
        /// Fait remonter la liste des services quand la souris part
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxServices_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var combobox = comboboxServices; // selection de la combobox
                if (combobox.IsDropDownOpen == true) // si la combobox est descendue
                {
                    combobox.IsDropDownOpen = false; // on la remonte
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /// <summary>
        /// initialise la longueur max de la combmboxService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxServices_Initialized(object sender, EventArgs e)
        {
            comboboxServices.MaxDropDownHeight = 1080; // définie la longueur de la liste de la combobox à 1080px maximum
        }
        /// <summary>
        /// Fait descendre la liste au passage de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxFonctions_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                var combobox = comboboxFonctions; // selection de la combobox
                if (combobox.IsInitialized == false) // si jamais la combobox n'est pas initialisée
                {
                    throw new Exception("La combobox n'est pas initialisée");
                }
                if (combobox.HasItems == false) // si jamais la combobox ne possède aucun items
                {
                    throw new Exception("La combobox ne dispose d'aucuns items");
                }
                combobox.IsDropDownOpen = true; // on descend la combobox
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " indique :", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /// <summary>
        ///  Fait remonter la liste des fonctions quand la souris part
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxFonctions_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var combobox = comboboxFonctions; // selection de la combobox
                if (combobox.IsDropDownOpen == true) // si la combobox est descendue
                {
                    combobox.IsDropDownOpen = false; // on la remonte
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /// <summary>
        /// initialise la longueur max de la combmboxFonction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxFonctions_Initialized(object sender, EventArgs e)
        {
            comboboxFonctions.MaxDropDownHeight = 1080;  // définie la longueur de la liste de la combobox à 1080px maximum
        }
        /// <summary>
        /// Convertis un tableau de bytes en image Bitmap
        /// </summary>
        /// <param name="bitmapImag"></param>
        /// <returns></returns>
        public BitmapImage GetImageFromByte(byte[] bitmapImag)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(bitmapImag)) // précise une portée de ressources comprenant type tableau de bytes
                {
                    BitmapImage bitmapImage = new BitmapImage(); // création d'une instance BitmapImage
                    bitmapImage.BeginInit(); // initialisation de l'instance
                    bitmapImage.StreamSource = stream; // précise la source de flux
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // ferme le flux après création de l'image bitmap
                    bitmapImage.EndInit(); // fin de l'initialisation
                    return bitmapImage; // retourne l'image
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}