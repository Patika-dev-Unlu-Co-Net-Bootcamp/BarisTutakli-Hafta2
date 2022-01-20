using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.GetProductDetail
{
    public class GetProductDetailQuery
    {
        private readonly ECommerceDbContext _context;
        public int ProductId { get; set; }
        public GetProductDetailQuery(ECommerceDbContext context)
        {
            _context = context;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product bulunamadı");
            }
            ProductDetailViewModel vm = new ProductDetailViewModel();
            vm.Category = ((CategoryEnum)product.CategoryId).ToString();
            vm.ProductName = product.ProductName;
            vm.PublishingDate = product.PublishingDate;

            return vm;
        }

    }
}
