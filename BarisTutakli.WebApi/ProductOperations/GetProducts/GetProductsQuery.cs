using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.GetProducts
{
    public class GetProductsQuery
    {
        public readonly ECommerceDbContext _context;
        public GetProductsQuery(ECommerceDbContext context)
        {
            _context = context;
        }
        public List<ProductsViewModel> Handle()
        {
            List<ProductsViewModel> productviewModels = new List<ProductsViewModel>();

            _context.Products.ToList().ForEach(product => productviewModels.Add(new ProductsViewModel { Category = ((CategoryEnum)product.CategoryId).ToString(), ProductName = product.ProductName, PublishingDate = product.PublishingDate }));
            if (productviewModels.Count==0)
            {
                throw new InvalidOperationException("ürünler buunamadı");
            }

            return productviewModels;


        }
    }
}
