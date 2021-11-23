using PromotionEngineModels;
using System.Collections.Generic;

namespace PromotionEngineDAL
{
    public class ProductDAL : IProductDAL
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new()
            {
                new Product { ProductID = 1, ProductName = "A", ProductPrice = 50 },
                new Product { ProductID = 2, ProductName = "B", ProductPrice = 30 },
                new Product { ProductID = 3, ProductName = "C", ProductPrice = 20 },
                new Product { ProductID = 4, ProductName = "D", ProductPrice = 15 },
                new Product { ProductID = 5, ProductName = "E", ProductPrice = 10 },
                new Product { ProductID = 6, ProductName = "F", ProductPrice = 5 }
            };
            return products;
        }

        public List<Product> GetProductsForIds(List<int> productIds)
        {
            var products = GetAllProducts();
            return products.Where(x => productIds.Contains(x.ProductID)).ToList();
        }
    }
}