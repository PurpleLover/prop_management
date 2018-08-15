using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eAMS.Dal.Repository
{
    public interface IPropertyRepository<T> where T: class
    {
        IEnumerable<T> ListProperty();
        T ListPropertyById(int id);
        void SaveProperty(T obj);
        void RemoveProperty(int id);
    }
}