using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eAMS.BusinessNew.Helper
{
    public static class Pagination
    {
        public static PagedData<T> PageResult<T>(this List<T> list, int PageNumber, int PageSize) where T:class
        {
            try
            {
                var result = new PagedData<T>
                {
                    Data = list.Skip(PageSize * (PageNumber - 1))
                        .Take(PageSize)
                        .ToList(),
                    TotalPages = Convert.ToInt32(Math.Ceiling((double)list.Count() / PageSize)),
                    CurrentPages = PageNumber
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}