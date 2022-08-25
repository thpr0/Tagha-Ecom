namespace BastosEcommercePlatform.Respository.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public bool Deleted { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public ProductCategory Category { get; set; }
    }
}
