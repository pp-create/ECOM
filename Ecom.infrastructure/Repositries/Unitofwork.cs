using AutoMapper;
using Ecom.core.interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositries
{
    public class Unitofwork : IunitofWork
    {
        private readonly AppDBcontext _context;
        private readonly IMapper mapper;
        private readonly IImagemanagementService imagemanagementService;

        public IproductRepositry productRepositry  {get;}

        public IcategoryRepositry categoryRepositry { get; }

        public IPhoto Photo { get; }
      

        public Unitofwork(AppDBcontext context,IMapper mapper,IImagemanagementService  imagemanagementService)
        {
            _context = context;
            this.mapper = mapper;
            this.imagemanagementService = imagemanagementService;
            Photo = new PhotoRepositry(context);
            categoryRepositry = new CategoryRepositry(context);
            productRepositry = new productRepositry(context,mapper, imagemanagementService);


        }
    }
}
