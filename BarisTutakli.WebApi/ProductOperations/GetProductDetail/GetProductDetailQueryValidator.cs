using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.GetProductDetail
{
    public class GetProductDetailQueryValidator: AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(query => query.ProductId).GreaterThan(0);
            RuleFor(query => query.ProductId).NotNull().NotEmpty();
        }
    }
}
