using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repository.Query
{
    public class ProductQueryService : IProductRepository
    {
        private readonly ShopOnlineContext dbContext;

        public ProductQueryService(ShopOnlineContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        async Task<ProductDTO> IProductRepository.AddProducts(ProductDTO products)
        {
            var config = Services.Mapping<Product, ProductDTO>();
            var mapper = new Mapper(config);
            var p= mapper.Map<Product>(products);
   
            await dbContext.Products.AddAsync(p);
            if (dbContext.SaveChanges() > 0)
            {
                return mapper.Map<ProductDTO>(p);
            }
            return null!;
        }

        async Task<ProductDTO> IProductRepository.GetItem(int id)
        {
            var item = await dbContext.Products.FindAsync(id);
            if (item == null)
            {
                return null!;
            }
            var config = Services.OneTimeMapping<Product, ProductDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<ProductDTO>(item);
        }

        async Task<IEnumerable<ProductDTO>> IProductRepository.GetItems()
        {
            var product = await dbContext.Products.ToListAsync();
            var config = Services.OneTimeMapping<Product, ProductDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<List<ProductDTO>>(product);
        }
    }
}
