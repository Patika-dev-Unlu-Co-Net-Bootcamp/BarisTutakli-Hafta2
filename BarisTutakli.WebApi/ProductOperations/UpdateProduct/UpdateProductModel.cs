﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{
    public class UpdateProductModel
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}
