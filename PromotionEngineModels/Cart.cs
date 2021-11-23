
namespace PromotionEngineModels
{
    public class Cart
    {
        public int CartID { get; set; }
        public List<ProductQuantity> ProductQuantity { get; set; } = new List<ProductQuantity>();
    }
}
