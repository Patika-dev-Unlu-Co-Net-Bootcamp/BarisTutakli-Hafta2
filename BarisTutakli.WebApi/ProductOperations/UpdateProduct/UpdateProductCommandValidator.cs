using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.UpdateProduct
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.CategoryId).GreaterThan(0).NotNull();
            RuleFor(command => command.Model.ProductName).MinimumLength(3).NotEmpty();
        }
    }
}
