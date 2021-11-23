using PromotionEngineModels;


namespace PromotionEngineDAL
{
    public class PromotionDAL : IPromotionDAL
    {
        public List<Promotion> GetAllPromotions()
        {
            List<Promotion> promotions = new();

            List<ProductQuantity> productQuantity = new()
            {
                new ProductQuantity { ProductID = 1, Quantity = 3 },
            };
            promotions.Add(new Promotion { Id = Guid.NewGuid(), Terms = productQuantity, Price = 130, Type = PromotionType.Single, Enabled = true });

            productQuantity = new()
            {
                new ProductQuantity { ProductID = 2, Quantity = 2 }
            };
            promotions.Add(new Promotion { Id = Guid.NewGuid(), Terms = productQuantity, Price = 45, Type = PromotionType.Single, Enabled = true });

            productQuantity = new()
            {
                new ProductQuantity { ProductID = 3, Quantity = 1 },
                new ProductQuantity { ProductID = 4, Quantity = 1 }
            };
            promotions.Add(new Promotion { Id = Guid.NewGuid(), Terms = productQuantity, Price = 30, Type = PromotionType.Multi, Enabled = true });

            productQuantity = new()
            {
                new ProductQuantity { ProductID = 3, Quantity = 2 },
                new ProductQuantity { ProductID = 5, Quantity = 2 }
            };
            promotions.Add(new Promotion { Id = Guid.NewGuid(), Terms = productQuantity, Price = 50, Type = PromotionType.Multi, Enabled = true });

            productQuantity = new()
            {
                new ProductQuantity { ProductID = 6, Quantity = 10 }
            };
            // if DiscountPercent is specified for promotion then DiscountPercent will be applied and promotion price will be ignored
            promotions.Add(new Promotion { Id = Guid.NewGuid(), Terms = productQuantity, DiscountPercent = 20, Price = 0, Type = PromotionType.Single, Enabled = true });


            return promotions;
        }

        public List<Promotion> GetPromotionsFor(List<int> productIds)
        {
            var promotions = GetAllPromotions();
            return promotions.Where(x => x.Enabled && x.Terms.Any(x => productIds.Contains(x.ProductID)) ).ToList();
        }
    }
}
