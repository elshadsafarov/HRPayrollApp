using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPayrollApp.Models
{
    public class Pagination
    {
        public int ItemsPerPage { get; set; } = 1;
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems
        {
            get
            {
                return (int)Math.Ceiling(TotalItems / (decimal)ItemsPerPage);
            }

        }
    }
}
