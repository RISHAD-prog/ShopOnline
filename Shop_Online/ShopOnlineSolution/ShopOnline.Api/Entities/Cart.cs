using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        
        [ForeignKey("CartId")]
        public virtual List<Cart>? Items { get; set; } = new List<Cart>();
    }
}
