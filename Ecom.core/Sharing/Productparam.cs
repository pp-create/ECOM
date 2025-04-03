using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Sharing
{
    public class ProductParam
    {
        public string? Sort { get; set; } 
        public string? Search { get; set; } 
        public int? CategoryId { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
