using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eAMS.Models.Models;

namespace eAMS.BusinessNew.DbInteract
{
    public class MaintainancesInteractor: DbContext
    {
        private PROP_MNGEntities context;

        public MaintainancesInteractor()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public List<PropMaint> ListMaintainActions()
        {
            try
            {
                context = new PROP_MNGEntities();
                context.Configuration.ProxyCreationEnabled = false;
                return context.PropMaints.Include(m => m.PropRegi).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string SaveChanges(PropMaint propMaint)
        {
            try
            {
                string message = "Success";
                context = new PROP_MNGEntities();
                context.PropMaints.Add(propMaint);
                context.SaveChanges();
                return message;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}