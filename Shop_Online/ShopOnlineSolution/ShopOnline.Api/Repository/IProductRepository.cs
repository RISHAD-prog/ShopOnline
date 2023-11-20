using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;
using System.Collections.Generic;

namespace ShopOnline.Api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetItems();
        Task<ProductDTO> AddProducts(ProductDTO products);
        Task<ProductDTO> GetItem(int id);
    }
}
