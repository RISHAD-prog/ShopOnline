using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repository
{
    public class ProductRepository 
    {

        public async Task<String> AddProductAsync<TResult>(Func<Task<TResult>> methodname)
        {
            String baseResponse = "";
            try
            {
                var product =await methodname();
                if(product != null) {
                    baseResponse= "Product has been added with id:"+product;
                }
            }
            catch(Exception ex) {
                return ex.Message.ToString();
            }
            return baseResponse;
        }
    }
}
