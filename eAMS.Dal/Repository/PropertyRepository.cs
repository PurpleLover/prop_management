using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eAMS.Dal.Repository
{
    public class PropertyRepository<T> : IPropertyRepository<T> where T : class
    {
        protected readonly DbContext context;

        public PropertyRepository(DbContext _context)
        {
            context = _context;
        }

        public IEnumerable<T> ListProperty()
        {
            throw new NotImplementedException();
        }

        public T ListPropertyById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProperty(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveProperty(T obj)
        {
            throw new NotImplementedException();
        }
    }
}