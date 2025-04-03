using AutoMapper;
using Ecom.core.Dto;
using Ecom.core.Entities.Product;

namespace Ecom.Apl.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDto>()
              .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))

              .ReverseMap();
            CreateMap<AddProductDto, Product>()
         .ForMember(dest => dest.photo, opt => opt.Ignore()) 
         .ReverseMap(); CreateMap<UpdateProductDto, Product>()
         .ForMember(dest => dest.photo, opt => opt.Ignore()) 
         .ReverseMap();


            CreateMap<photo, photoDto>().ReverseMap(); 

        }

    }
}

