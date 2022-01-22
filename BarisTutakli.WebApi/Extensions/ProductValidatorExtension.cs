using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.Extensions

{
    public static class ProductValidatorExtension
    {
       
        public static bool IsValid{ get; set; }
        
        public static void ValidateIt(this ProductValidator validator,CreateProductModel createProductModel)
        {
          
            if (createProductModel.PublishDate.Year<1800)
            {
                IsValid = false;
            }
            IsValid = true;
            
        }
    }
}
