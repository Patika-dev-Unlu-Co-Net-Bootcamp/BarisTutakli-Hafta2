using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    {
        private readonly ECommerceDbContext _context;
        public int ProductId { get; set; }
        public UpdateProductModel Model{get;set;}
        public UpdateProductCommand(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("ürün bulunamadı");
            }
            product.CategoryId = Model.CategoryId;
            product.ProductName = Model.ProductName;

            _context.SaveChanges();



        }

    }
}
