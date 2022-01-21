using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.FakeServices
{
    public abstract class FakeMapper
    {
        // This method maps two objcets. MapObjects takes two parameters <Source,Target>
        public abstract Product MapObjects(CreateProductModel createProductModel,Product product);
    }
}
