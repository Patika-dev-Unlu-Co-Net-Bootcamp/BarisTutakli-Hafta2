using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Common.Abstract
{
    public abstract class Mapper
    {
        public abstract Product Map(CreateProductModel productModel);
      
    }
}
