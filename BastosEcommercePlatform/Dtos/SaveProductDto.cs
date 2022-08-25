using BastosEcommercePlatform.Respository.Models;
using Microsoft.AspNetCore.Http;

namespace BastosEcommercePlatform.API.Dtos
{
    public class SaveProductDto
    {
        public string Title { get; set; }
        public string description { get; set; }
        public double Price { get; set; }
        public ProductCategory Category { get; set; }
        public IFormFile File { get; set; }
    }
}
