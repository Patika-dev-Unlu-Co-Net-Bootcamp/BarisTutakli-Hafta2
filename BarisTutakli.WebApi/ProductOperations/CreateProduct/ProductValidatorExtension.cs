using BarisTutakli.WebApi.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public static class ProductValidatorExtension
    {
        public static bool IsLongEnough(this Product product)
        {
            return product.ProductName.Length > 5 ? true : false;
        }
    }
}
