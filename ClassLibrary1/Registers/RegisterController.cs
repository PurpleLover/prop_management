using System.Linq;
using System.Collections.Generic;
using eAMS.Models.Models;

namespace eAMS.Business.Registers
{
    class RegisterController
    {
        // Unite Create and Update Method
        public void SaveProperty(PropRegi propRegi)
        {
            using (var context = new PROP_MNGEntities())
            {
                if (propRegi.ID == 0)
                {
                    var search = context.PropRegis
                        .Where(p => p.Code == propRegi.Code)
                        .FirstOrDefault();
                    if (search == null)
                    {
                        context.PropRegis.Add(propRegi);
                    }
                } else
                {
                    var dbEntry = context.PropRegis
                        .Find(propRegi.ID);
                    if (dbEntry!=null)
                    {
                        dbEntry.Name = propRegi.Name;
                        dbEntry.Brand = propRegi.Brand;
                        dbEntry.Year = propRegi.Year;
                        dbEntry.IsMaitained = propRegi.IsMaitained;
                    }
                }
                context.SaveChanges();
            }
        }

        public void RemoveProperty(PropRegi propRegi)
        {
            using (var context = new PROP_MNGEntities())
            {
                var dbValid = context.PropRegis
                    .Where(p => p.ID == propRegi.ID)
                    .FirstOrDefault();
                if (dbValid != null)
                {
                    context.PropRegis.Remove(propRegi);
                    context.SaveChanges();
                }
            }
        }

        public List<PropRegi> ListProperty()
        {
            using (var context = new PROP_MNGEntities())
            {
                List<PropRegi> propRegis = context.PropRegis.ToList();
                return propRegis;
            }
        }
    }
}
