using AutoMapper;
using Ecom.core.Dto;
using Ecom.core.Entities.Product;
using Ecom.core.interfaces;
using Ecom.core.Services;
using Ecom.core.Sharing;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositries.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositries
{
    public class productRepositry : GenericRepositry<Product>, IproductRepositry
    {
        private readonly AppDBcontext context;
        private readonly IMapper mapper;
        private readonly IImagemanagementService imageManagementService;

        public productRepositry(AppDBcontext context, IMapper mapper, IImagemanagementService imageManagementService)
            : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }
        public async Task<bool> Addasync(AddProductDto productDTO)
        {
            if (productDTO == null || productDTO.photo == null || !productDTO.photo.Any())
                return false;

            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                // تحويل DTO إلى كيان المنتج
                var product = mapper.Map<Product>(productDTO);
                await context.Product.AddAsync(product);
                await context.SaveChangesAsync();

                // رفع الصور وحفظ المسارات
                var imagePaths = await imageManagementService.AddImageAsync(productDTO.photo, productDTO.Name);

                // إنشاء كائنات الصور وربطها بالمنتج
                var photos = imagePaths.Select(path => new photo
                {
                    ImageName = path,
                    productid = product.Id
                }).ToList();

                // إضافة الصور إلى قاعدة البيانات
                await context.photo.AddRangeAsync(photos);
                await context.SaveChangesAsync();

                // تأكيد العملية
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync(ProductParam param)
        {
            var query = context.Product
                .Include(m => m.Category)
                .Include(m => m.photo)
                .AsNoTracking();
            if (!string.IsNullOrEmpty(param.Search))
            {
                var searchWords = param.Search
                                               .ToLower() 
                                               .Split(' ');

                query = query.Where(m => searchWords.All(word =>
                    m.Name.ToLower().Contains(word) ||
                    m.Description.ToLower().Contains(word)
                ));
            }

            if (param.CategoryId.HasValue)
            {
                query = query.Where(x => x.categroyid == param.CategoryId);
            }
            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "PriceAsc":
                        query = query.OrderBy(m => m.Newprice);
                        break;
                    case "PriceDes":
                        query = query.OrderByDescending(m => m.Newprice);
                        break;
                    default:
                        query = query.OrderBy(m => m.Name);
                        break;
                }
            }
         
            query = query.Skip((param.PageSize) * (param.PageNumber - 1)).Take(param.PageSize);
            var result =  mapper.Map<List<ProductDto>>(query).ToList();
            return result;
        }
        public async Task Deleteasync(Product entity)
        {
            var FindProduct = await context.Product
    .Include(m => m.Category)
    .Include(m => m.photo)
    .FirstOrDefaultAsync(m => m.Id == entity.Id);
            var FindPhoto = await context.photo
            .Where(m => m.productid == entity.Id)
            .ToListAsync();

            foreach (var item in FindPhoto)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            context.photo.RemoveRange(FindPhoto);
             context.Product.Remove(entity);
            await context.SaveChangesAsync();
           

        }

        public async Task<bool> UpdateProduct(UpdateProductDto entity)
        {
            if (entity is  null )
            {
                return false;
            }
            var FindProduct = await context.Product
    .Include(m => m.Category)
    .Include(m => m.photo)
    .FirstOrDefaultAsync(m => m.Id == entity.id);

            if (FindProduct is null)
            {
                return false;
            }

            mapper.Map(entity, FindProduct);

            var FindPhoto = await context.photo
                .Where(m => m.productid == entity.id)
                .ToListAsync();

            foreach (var item in FindPhoto)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            context.photo.RemoveRange(FindPhoto);

            var ImagePath = await imageManagementService.AddImageAsync(entity.photo, entity.Name);

            List<photo>photo = ImagePath.Select(path => new photo
            {
                ImageName = path,
                productid = entity.id
            }).ToList();
            await context.photo.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
