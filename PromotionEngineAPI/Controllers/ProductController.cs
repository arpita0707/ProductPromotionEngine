using Microsoft.AspNetCore.Mvc;
using PromotionEngineBL;
using PromotionEngineModels;

namespace PromotionEngineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
       
        private readonly ILogger<ProductController> _logger;
        IProductBL _productBL;

        public ProductController(ILogger<ProductController> logger, IProductBL productBL)
        {
            _logger = logger;
            _productBL = productBL;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productBL.GetAllProducts();
        }
    }
}