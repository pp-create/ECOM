using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.interfaces
{
     public interface IunitofWork
    {
        public IproductRepositry productRepositry { get;  }
        public IcategoryRepositry categoryRepositry { get;  }
        public IPhoto Photo { get;  }
    }
}
