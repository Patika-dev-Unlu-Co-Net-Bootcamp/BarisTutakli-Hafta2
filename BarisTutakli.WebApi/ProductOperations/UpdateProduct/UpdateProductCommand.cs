namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{
    using BarisTutakli.WebApi.DbOperations;
    using System;
    using System.Linq;

    public class UpdateProductCommand
    {
        private readonly ECommerceDbContext _context;

        public int ProductId { get; set; }

        public UpdateProductModel Model { get; set; }

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
            product.CategoryId = Model.CategoryId != default ? Model.CategoryId : product.CategoryId;
            product.ProductName = Model.ProductName != default ? Model.ProductName : product.ProductName;
            product.PublishingDate = Model.PublishingDate != default ? Model.PublishingDate : product.PublishingDate;

            _context.SaveChanges();
        }
    }
}
