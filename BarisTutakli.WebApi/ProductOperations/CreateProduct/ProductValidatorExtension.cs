using BarisTutakli.WebApi.Models.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.CreateProduct
{
    public static class ProductValidatorExtension
    {
       
        public static bool IsValid{ get; set; }
        
        public static void ValidateIt(this ProductValidator validator,CreateProductModel createProductModel)
        {
          
            if (createProductModel.PublishingDate.Year<1800)
            {
                IsValid = false;
            }
            IsValid = true;
            
        }
    }
}
