using AutoMapper;
using Ecom.core.Dto;
using Ecom.core.Entities.Product;

namespace Ecom.Apl.Mapping
{
    public class CategroyMapping:Profile
    {
        public CategroyMapping()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
