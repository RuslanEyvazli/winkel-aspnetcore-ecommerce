namespace WINKEL_ECOMMERCE.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool HasDiscount { get; set; } 

        public decimal DiscountPrice { get; set; } 
        public int Rating { get; set; }
        public int Quantity { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public static implicit operator BasketProduct(Product v)
        {
            return new BasketProduct
            {
                Id = v.Id,
                Image = v.Image,
                DiscountPrice = v.DiscountPrice,
                HasDiscount = v.HasDiscount,
                Name = v.Name,
                Price = v.Price,
                Rating = v.Rating,
                Quantity = 1
            }; 
        }
    }
}
