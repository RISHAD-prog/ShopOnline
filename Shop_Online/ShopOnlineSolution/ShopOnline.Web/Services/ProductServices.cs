using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services
{
    public class ProductServices : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductServices(HttpClient httpClient )
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDTO> AddProducts(ProductDTO product)
        {
            try
            {
                 var response  = await this._httpClient.PostAsJsonAsync<ProductDTO>("api/Product", product);
                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent )
                    {
                        return default (ProductDTO)!;
                    }
                    return await response.Content.ReadFromJsonAsync<ProductDTO>();

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<ProductDTO>> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
