using PromotionEngineModels;

namespace PromotionEngineDAL
{
    public interface IProductDAL
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// Get products for specified product ids
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public List<Product> GetProductsForIds(List<int> productIds);
    }
}
