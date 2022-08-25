using BastosEcommercePlafrom.BlobStorage.Interfaces;
using BastosEcommercePlatform.API.Dtos;
using BastosEcommercePlatform.Respository.Configuration;
using BastosEcommercePlatform.Respository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IStorageManager _storageManager;

        public ProductController(IUnitOfWork unitOfWork, IStorageManager storageManager)
        {
            _unitOfWork = unitOfWork;
            _storageManager = storageManager;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _unitOfWork.ProductRepository.All());
        }

        
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> SaveProduct(SaveProductDto product)
        {

            var productToSave = new Product
            {
                Category = product.Category,
                description = product.description,
                Price = product.Price,
                Title = product.Title
            };

            if (product.File.Length > 0)
            {
                using (var stream = product.File.OpenReadStream())
                {
                    var uploadResult = await _storageManager.Upload(stream);
                    productToSave.ImageUrl = uploadResult.Link.ToString();
                }
            }
            
            await _unitOfWork.ProductRepository.Add(productToSave);
            await _unitOfWork.CompleteAsync();

            return Ok(product);
        }
       
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _unitOfWork.ProductRepository.GetByeId(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.CompleteAsync();
            return Ok("Deleted");
        }
    }
}
