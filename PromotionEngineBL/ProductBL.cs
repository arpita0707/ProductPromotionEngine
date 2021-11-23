using PromotionEngineDAL;
using PromotionEngineModels;

namespace PromotionEngineBL
{
    public class ProductBL: IProductBL
    {
        IProductDAL _productDAL;
        public ProductBL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public List<Product> GetAllProducts()
        {
            return _productDAL.GetAllProducts();
        }
    }
}