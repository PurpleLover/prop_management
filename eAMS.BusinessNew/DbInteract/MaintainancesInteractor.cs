using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eAMS.Models.Models;

namespace eAMS.BusinessNew.DbInteract
{
    public class MaintainancesInteractor
    {
        private PROP_MNGEntities context;
        
        public IQueryable<PropMaint> ListMaintained()
        {
            return context.PropMaints
                .Include(p=>p.PropRegi);
        }

        public void SaveChanges(PropMaint propMaint)
        {
            try
            {
                String message;
                context = new PROP_MNGEntities();
                context.PropMaints.Add(propMaint);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}