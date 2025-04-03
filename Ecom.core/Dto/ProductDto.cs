using Microsoft.AspNetCore.Http;

namespace Ecom.core.Dto
{
  public  record ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    
         public virtual List<photoDto> photo { get; set; }
            public decimal Oldprice { get; set; }
        public decimal Newprice { get; set; }
        int categroyid { get; set; }
   
    } 
    public  record AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public IFormFileCollection photo { get; set; }
        
            public decimal Oldprice { get; set; }
        public decimal Newprice { get; set; }
        public int categroyid { get; set; }
   
    } public  record UpdateProductDto: AddProductDto
    {
        public int id { get; set; }

    }
    
   
     
}
