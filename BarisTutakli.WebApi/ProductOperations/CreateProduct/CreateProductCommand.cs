using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.Common.Abstract;
using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }
        private readonly ECommerceDbContext _dbcontext;
        private readonly Mapper _mapper;
        public CreateProductCommand(ECommerceDbContext context,Mapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var product = _dbcontext.Products.SingleOrDefault(product => product.ProductName == Model.ProductName);
            if (product is not null)
                throw new InvalidOperationException("Urun zaten mevcut");

            
            product = _mapper.Map(Model);
            //product.ProductName = Model.ProductName;
            //product.CategoryId = Model.CategoryId;
            //product.PublishingDate = Model.PublishingDate;
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();


        }
    }
}
