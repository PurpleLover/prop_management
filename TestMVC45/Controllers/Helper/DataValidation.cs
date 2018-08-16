using eAMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC45.Controllers.Helper
{
    public class DataValidation
    {
        public bool CheckPropertyId(int propertyId)
        {
            return propertyId < 0;
        }

        public bool CheckPropertyName(string propertyName)
        {
            if (propertyName.Length > 50 || propertyName.Length < 3)
            {
                return false;
            }
            return true;
        }

        public bool CheckPropertyYear(string propertyYear)
        {
            if (propertyYear.Length != 4)
            {
                return false;
            }
            return true;
        }

        public bool CheckRequired(string any)
        {
            return String.IsNullOrEmpty(any);
        }

        public bool Check(PropRegi property)
        {
            if (!CheckRequired(property.Name) 
                || !CheckRequired(property.Brand) 
                || !CheckRequired(property.Year) 
                || !CheckRequired(property.Code))
            {
                return false;
            }

            if (!CheckPropertyName(property.Name))
            {
                return false;
            }

            if (!CheckPropertyId(property.ID))
            {
                return false;
            }

            if (!CheckPropertyYear(property.Year))
            {
                return false;
            }

            return true;
        }
    }
}