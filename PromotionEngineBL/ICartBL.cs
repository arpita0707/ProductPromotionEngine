using PromotionEngineModels;


namespace PromotionEngineBL
{
    public interface ICartBL
    {
        public decimal GetCartPrice(List<CartProduct> cartProducts);
    }
}
