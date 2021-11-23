using PromotionEngineDAL;
using PromotionEngineModels;


namespace PromotionEngineBL
{
    public class CartBL : ICartBL
    {
        IProductDAL _productDAL;
        IPromotionDAL _promotionDAL;
        public CartBL(IPromotionDAL promotionDAL, IProductDAL productDAL)
        {
            _productDAL = productDAL;
            _promotionDAL = promotionDAL;
        }

        public decimal GetCartPrice(List<CartProduct> cart)
        {
            if (!cart.Any())
            {
                throw new ArgumentNullException(nameof(cart), "can not be empty");
            }

            var cartProductIds = cart.Select(x => x.ProductID).ToList();
            var promotions = _promotionDAL.GetPromotionsFor(cartProductIds);
            decimal cartPrice = 0;

            // validation check
            var products = _productDAL.GetProductsForIds(cartProductIds);
            if (cart.Count > products.Count)
            {
                throw new ArgumentNullException(nameof(cart), "contains some duplicate product ids or product ids that does not exist");
            }

            foreach (var promotion in promotions)
            {
                cartPrice += ApplyPromotion(ref cart, promotion);
            }

            // check for remaining cart items
            foreach (var remProduct in cart)
            {
                int remProductPrice = remProduct.Quantity * remProduct.ProductPrice;
                cartPrice += remProductPrice;
            }

            return cartPrice;
        }

        private int ApplyPromotion(ref List<CartProduct> cart, Promotion promotion)
        {
            var possiblePromotions = new List<int>();

            foreach (var item in promotion.Terms)
            {
                var cartProdQuantity = cart.Where(x => x.ProductID == item.ProductID).FirstOrDefault()?.Quantity ?? 0;
                int possiblePromotionsForProduct = cartProdQuantity / item.Quantity;
                possiblePromotions.Add(possiblePromotionsForProduct);
            }

            // if multiple products under a promotion terms have different applicable promotions, then pick the least promotion count
            int applicablePromotions = possiblePromotions.Min();
            if (applicablePromotions == 0)
                return 0;

            var applicablePromotionsDiscount = 0;
            foreach (ProductQuantity item in promotion.Terms)
            {
                var cartProduct = cart.Where(x => x.ProductID == item.ProductID).FirstOrDefault();
                cartProduct!.Quantity -= applicablePromotions * item.Quantity;

                if (promotion.DiscountPercent != null)
                {
                    decimal discountedPrice = cartProduct.ProductPrice * ((100 - (decimal)promotion.DiscountPercent) / 100);
                    applicablePromotionsDiscount += (int)(applicablePromotions * item.Quantity * discountedPrice);
                }
            }

            return promotion.DiscountPercent != null ? applicablePromotionsDiscount : (promotion.Price * applicablePromotions);
        }
    }
}
