using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IconCSS { get; set; }

        [ForeignKey("CategoryId")]
        public virtual List<Product> Products { get; set; } = new List<Product>();
        
    }
}
