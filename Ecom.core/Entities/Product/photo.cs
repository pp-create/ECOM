using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Entities.Product
{
   public class photo:BaseEntity<int>
    {
        public string ImageName { get; set; }
        public int productid { get; set; }
       // [ForeignKey(nameof(productid))]
      //  public virtual Product Product { get; set; }
    }
}
