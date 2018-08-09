using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eAMS.Models.Models;

namespace eAMS.BusinessNew.DbInteract
{
    public class RegisterInteractor : DbContext
    {
        public RegisterInteractor()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        private PROP_MNGEntities context;
        const string SUCCESSFUL = "Successful";
        const string ERROR = "Error";
        public string SaveProperty(PropRegi propRegi)
        {
            try
            {
                string message;
                context = new PROP_MNGEntities();
                if (propRegi.ID == 0)
                {
                    PropRegi search = context.PropRegis
                        .Where(p => p.Code == propRegi.Code)
                        .FirstOrDefault();
                    if (search == null)
                    {
                        context.PropRegis.Add(propRegi);
                        message = SUCCESSFUL;
                    }
                    else
                    {
                        message = ERROR;
                    }
                }
                else
                {
                    PropRegi dbEntry = context.PropRegis
                        .Where(p => p.ID == propRegi.ID)
                        .FirstOrDefault();
                    if (dbEntry != null)
                    {
                        dbEntry.Name = propRegi.Name;
                        dbEntry.Code = propRegi.Code;
                        dbEntry.Brand = propRegi.Brand;
                        dbEntry.Year = propRegi.Year;
                        dbEntry.IsMaitained = propRegi.IsMaitained;
                    }
                    message = SUCCESSFUL;
                }
                context.SaveChanges();
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RemoveProperty(int propertyId)
        {
            try
            {
                string message;
                context = new PROP_MNGEntities();
                PropRegi dbEntry = context.PropRegis
                    .Where(p => p.ID == propertyId)
                    .FirstOrDefault();
                if (dbEntry != null)
                {
                    context.PropRegis.Remove(dbEntry);
                    context.SaveChanges();
                    message = SUCCESSFUL;
                }
                else
                {
                    message = ERROR;
                }
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PropRegi> ListProperty()
        {
            try
            {
                context = new PROP_MNGEntities();
                return context.PropRegis.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PropRegi ListPropertyById(int propertyId)
        {
            try
            {
                context = new PROP_MNGEntities();
                var dbEntry = context.PropRegis
                    .Where(p => p.ID == propertyId)
                    .FirstOrDefault();
                return dbEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}