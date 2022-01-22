using BarisTutakli.WebApi.Common.Abstract;
using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Common
{
    public class CustomMapper : Mapper
    {
        public override Product Map(CreateProductModel productModel)
        {

            return new Product { CategoryId = productModel.CategoryId, ProductName = productModel.ProductName, PublishingDate = productModel.PublishingDate };

        }
    }
}
