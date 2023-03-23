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
            try
            {
                _personnel = personnel;
                AfficherNom(RecupererLesPersonnels());
                AfficherPrenom(RecupererLesPersonnels());
                AfficherImage(RecupererLesPersonnels());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AfficherNom(List<Personnel> personnels)
        {
            try
            {
                labelNomPersonnels.Content = TrouverPersonnel(personnels).Nom.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AfficherPrenom(List<Personnel> personnels)
        {
            try
            {
                labelPrenomPersonnels.Content = TrouverPersonnel(personnels).Prenom.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AfficherImage(List<Personnel> personnels)
        {
            try
            {
                imagePersonnels.Source = GetImageFromByte(TrouverPersonnel(personnels).Photo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public BitmapImage GetImageFromByte(byte[] bitmapImag)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Personnel> RecupererLesPersonnels()
        {
            try
            {
                bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
                List<Personnel> personnels = bddpersonnels.getAllPersonnels();
                return personnels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Personnel TrouverPersonnel(List<Personnel> personnels)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
