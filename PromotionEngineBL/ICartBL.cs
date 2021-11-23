using PromotionEngineModels;


namespace PromotionEngineBL
{
    public interface ICartBL
    {
        public int GetCartPrice(List<CartProduct> cartProducts);
    }
}
