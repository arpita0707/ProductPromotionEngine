using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PromotionEngineBL;
using PromotionEngineModels;

namespace PromotionEngineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        ICartBL _cartBL;
        public CartController(ICartBL cartBL)
        {
            _cartBL = cartBL;
        }

        [HttpPost("GetCartPrice")]
        public ActionResult<int> GetCartPrice(List<CartProduct> cartProducts)
        {
            try
            {
                return Ok(_cartBL.GetCartPrice(cartProducts));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
