using BddpersonnelContext;
using biblioBDDpersonnels;
using System;
using System.Collections.Generic;
using System.IO;
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
            AfficherNom(RecupererLesPersonnels());
            AfficherPrenom(RecupererLesPersonnels());
            AfficherImage(RecupererLesPersonnels());
        }

        public void AfficherNom(List<Personnel> personnels)
        {
            labelNomPersonnels.Content=TrouverPersonnel(personnels).Nom.ToString();
        }

        public void AfficherPrenom(List<Personnel> personnels)
        {
            labelPrenomPersonnels.Content = TrouverPersonnel(personnels).Prenom.ToString();
        }

        public void AfficherImage(List<Personnel> personnels)
        {
            imagePersonnels.Source = GetImageFromByte(TrouverPersonnel(personnels).Photo);
        }

        public BitmapImage GetImageFromByte(byte[] bitmapImag)
        {
            using (MemoryStream stream = new MemoryStream(bitmapImag))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }


        public List<Personnel> RecupererLesPersonnels()
        {
            bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
            List<Personnel> personnels = bddpersonnels.getAllPersonnels();
            return personnels;
        }

        public Personnel TrouverPersonnel(List<Personnel> personnels)
        {
            foreach (var personnel in personnels)
            {
                if (personnel.Nom.ToString() == _personnel.Split(' ')[0])
                {
                    return personnel;
                }
            }
            return new Personnel();
        }
    }
}
