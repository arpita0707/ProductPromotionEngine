﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineModels
{
    public class Cart
    {
        public int CartID { get; set; }
        public List<ProductQuantity> ProductQuantity { get; set; } = new List<ProductQuantity>();
    }
}
