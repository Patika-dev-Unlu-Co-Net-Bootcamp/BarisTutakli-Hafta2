﻿using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.Common.Abstract;
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
        private readonly Mapper _mapper;
        public GetProductDetailQuery(ECommerceDbContext context,CustomMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product bulunamadı");
            }
            ProductDetailViewModel vm = _mapper.Map(product);

            return vm;
        }

    }
}
