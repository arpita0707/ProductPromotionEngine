using PromotionEngineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineBL
{
    public interface IProductBL
    {
        public List<Product> GetAllProducts();
    }
}
