using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class AddProductBase:ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        
        public ProductDTO Product { get; set; }= new ProductDTO();

        protected async Task Add_Product_Click(ProductDTO product)
        {
            try
            {
                var item = await this.ProductService.AddProducts(product);
                
            }
            catch (Exception ex) { 
            }
            
        }
    }
}
