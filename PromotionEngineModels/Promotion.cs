
namespace PromotionEngineModels
{
    public enum PromotionType
    {
        Single,
        Multi
    }

    public class Promotion
    {
        public Guid Id { get; set; }
        public List<ProductQuantity> Terms { get; set; } = new List<ProductQuantity>();
        public int Price { get; set; }
        public decimal? DiscountPercent { get; set; }
        public bool Enabled { get; set; }
        public PromotionType Type { get; set; }
    }
}
