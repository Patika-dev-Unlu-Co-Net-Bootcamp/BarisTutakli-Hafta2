using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using BarisTutakli.WebApi.ProductOperations.GetProductDetail;
using BarisTutakli.WebApi.ProductOperations.GetProducts;
using BarisTutakli.WebApi.ProductOperations.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Common.Abstract
{
    public abstract class Mapper
    {
        public abstract Product Map(CreateProductModel productModel);
        public abstract ProductDetailViewModel Map(Product product);
        public abstract Product Map(UpdateProductModel updateProduct);
        public abstract List<ProductsViewModel> Map(List<Product> productList);
    }
}
