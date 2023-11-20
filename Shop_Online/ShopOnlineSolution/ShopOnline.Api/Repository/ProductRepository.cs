using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;
using System.Collections.Generic;

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

        public async Task<IEnumerable<TResult>> GetAllProductAsync<TResult>(Func<Task<IEnumerable<TResult>>> methodname)
        {
            try
            {
                var items = await methodname();
                if (items != null)
                {
                    return items;
                }
                return Enumerable.Empty<TResult>();
            }
            catch (Exception ex) {
                throw new Exception();
            }
        }
    }
}
