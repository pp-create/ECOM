using Ecom.core.Entities.Product;
using Ecom.core.interfaces;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositries
{
    public class PhotoRepositry : GenericRepositry<photo>, IPhoto
    {
        public PhotoRepositry(AppDBcontext context) : base(context)
        {
        }
    }
}
