using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.GetProductDetail
{
    public class ProductDetailViewModel
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
