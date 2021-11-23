using PromotionEngineModels;


namespace PromotionEngineDAL
{
    public interface IPromotionDAL
    {
        /// <summary>
        /// Get all promotions
        /// </summary>
        /// <returns></returns>
        public List<Promotion> GetAllPromotions();

        /// <summary>
        /// Get promotions that belong to product ids 
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public List<Promotion> GetPromotionsFor(List<int> productIds);
    }
}
