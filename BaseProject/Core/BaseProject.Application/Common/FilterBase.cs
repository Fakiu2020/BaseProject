using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Application.Common
{
    public abstract class FilterBase
    {

        protected FilterBase()
        {
            PageNumber = 1;
            PageSize = 4;
            SortBy = "CreationTime";
            SortDirection = "DESC";
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public string SortBy { get; set; }

        public string SortDirection { get; set; }

        public int PageTotal { get; set; }

        public int PageCount
        {
            get
            {
                if (PageTotal > 0)
                {
                    return (int)Math.Ceiling((decimal)PageTotal / (decimal)PageSize);
                }
                return 0;
            }
        }
    }
}
