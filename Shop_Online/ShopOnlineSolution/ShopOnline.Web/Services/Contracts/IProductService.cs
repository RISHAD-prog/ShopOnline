using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetItems();
        Task<ProductDTO> AddProducts(ProductDTO product);
    }
}
