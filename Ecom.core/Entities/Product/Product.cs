using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Entities.Product
{
    public class Product:BaseEntity<int>

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<photo> photo { get; set; }
        public decimal Oldprice { get; set; }
        public decimal Newprice { get; set; }
        public int categroyid { get; set; }
        [ForeignKey(nameof(categroyid))]
        public  virtual Category Category { get; set; }

    }
}
