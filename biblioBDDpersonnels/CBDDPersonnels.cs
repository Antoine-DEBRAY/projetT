using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BddpersonnelContext;
using biblioBDDpersonnels;


namespace biblioBDDpersonnels
{
    public class CBDDPersonnels
    {
        private BddpersonnelDataContext dc = null; // objet qui permet de se connecter à la base
        public CBDDPersonnels()
        {
            try
            {

                dc = new BddpersonnelDataContext(); // connection
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public virtual List<Service> getAllServices()
        {
            try
            {
                return dc.Services.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<Personnel> getAllPersonnels()
        {
            try
            {
                return dc.Personnels.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<Fonction> getAllFonctions()
        {
            try
            {
                return dc.Fonctions.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void TrierLesServices(List<Service> services) // Trie les services
        {
            try {
                if (services.Count == 0)
                {
                    throw new ArgumentException("Il n'y a aucun service à trier");
                }
                services.Sort(Service.ComparerLabelServices);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void TrierLesFonctions(List<Fonction> fonctions) // Trie les fonctions
        {
            try {
                if (fonctions.Count == 0)
                {
                    throw new ArgumentException("Il n'y a aucune fonction à trier");
                }
                fonctions.Sort(Fonction.ComparerLabelFonctions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual List<Service> RecupererLesServices() // Récupère tous les services
        {
            try
            {
                CBDDPersonnels bddpersonnels = new CBDDPersonnels(); // initialise la connection
                List<Service> services = bddpersonnels.getAllServices(); // récupère une liste de tous les services
                if (services.Count == 0)
                {
                    throw new Exception("Il n'y a aucun services");
                }
                return services;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<Fonction> RecupererLesFonctions() // Récupère toutes les fonctions
        {
            try
            {
                CBDDPersonnels bddpersonnels = new CBDDPersonnels(); // initialise la classe, se connecte à la BDD
                List<Fonction> fonctions = bddpersonnels.getAllFonctions(); // récupère une liste de toutes les fonctions
                if (fonctions.Count == 0)
                {
                    throw new Exception("Il n'y a aucune fonction");
                }
                return fonctions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<Personnel> RecupererLesPersonnels()
        {
            try
            {
                CBDDPersonnels bddpersonnels = new CBDDPersonnels(); // initilise la classe, se connecte à la BDD
                List<Personnel> personnels = bddpersonnels.getAllPersonnels(); // récupère une liste de tous les personnels
                return personnels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
