using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BddpersonnelContext;

namespace biblioBDDpersonnels
{
    public class CBDDPersonnels
    {
        private BddpersonnelDataContext dc = null; // objet qui permet de se connecter à la base
        public CBDDPersonnels()
        {
            dc = new BddpersonnelDataContext(); // connection
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
    }
}
