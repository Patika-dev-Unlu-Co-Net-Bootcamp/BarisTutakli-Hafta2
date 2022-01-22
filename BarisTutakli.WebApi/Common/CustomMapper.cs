using BarisTutakli.WebApi.Common.Abstract;
using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using BarisTutakli.WebApi.ProductOperations.GetProductDetail;
using BarisTutakli.WebApi.ProductOperations.GetProducts;
using BarisTutakli.WebApi.ProductOperations.UpdateProduct;
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
        public override ProductDetailViewModel Map(Product product)
        {

            return new ProductDetailViewModel { Category = ((CategoryEnum)product.CategoryId).ToString(), ProductName = product.ProductName, PublishingDate = product.PublishingDate };

        }

        public override List<ProductsViewModel> Map(List<Product> productList)
        {
            List<ProductsViewModel> productviewModelsList = new List<ProductsViewModel>();
            productList.ForEach(product => productviewModelsList.Add(new ProductsViewModel { Category = ((CategoryEnum)product.CategoryId).ToString(), ProductName = product.ProductName, PublishingDate = product.PublishingDate }));
            return productviewModelsList;
        }

        public override Product Map(UpdateProductModel updateProduct)
        {
            Product product =new Product();
            product.CategoryId = updateProduct.CategoryId != default ? updateProduct.CategoryId : product.CategoryId;
            product.ProductName = updateProduct.ProductName != default ? updateProduct.ProductName : product.ProductName;
            product.PublishingDate = updateProduct.PublishingDate != default ? updateProduct.PublishingDate : product.PublishingDate;
            return product;
        }
    }
}
