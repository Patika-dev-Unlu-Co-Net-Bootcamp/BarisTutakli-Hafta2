using BarisTutakli.WebApi.Models.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public class ProductValidator:AbstractValidator<CreateProductModel>
    {
        public ProductValidator()
        {
            RuleFor(CreateProductModel => CreateProductModel.CategoryId).GreaterThan(0);
            RuleFor(CreateProductModel => CreateProductModel.ProductName).NotNull().NotEmpty().MinimumLength(2);
           
        }
    }
}
