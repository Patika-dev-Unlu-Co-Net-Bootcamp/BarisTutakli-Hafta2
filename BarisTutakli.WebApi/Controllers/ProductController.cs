namespace BarisTutakli.WebApi.Controllers
{
    using BarisTutakli.WebApi.DbOperations;
    using BarisTutakli.WebApi.Models.Concrete;
    using BarisTutakli.WebApi.ProductOperations.CreateProduct;
    using BarisTutakli.WebApi.ProductOperations.DeleteProduct;
    using BarisTutakli.WebApi.ProductOperations.GetProductDetail;
    using BarisTutakli.WebApi.ProductOperations.GetProducts;
    using BarisTutakli.WebApi.ProductOperations.ListProducts;
    using BarisTutakli.WebApi.ProductOperations.UpdateProduct;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public ProductController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetProductsQuery query = new GetProductsQuery(_context);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            GetProductDetailQuery query = new GetProductDetailQuery(_context);
            query.ProductId = id;

            var result = query.Handle();
            if (result is not null)
            {
                return Ok(result);
            }
            return NoContent();// return 204 
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Product product)
        {



            try
            {
                CreateProductCommand command = new CreateProductCommand(_context);

                command.Model = new CreateProductModel { CategoryId = product.CategoryId, ProductName = product.ProductName, PublishingDate = product.PublishingDate };

                command.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500); //500
            }
            // Return a message and the creation time of the product
            return Created("Index", new { message = "Product added.", time = DateTime.Now });//201
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductModel updateProductModel)
        {
            UpdateProductCommand command = new UpdateProductCommand(_context);
            command.ProductId = id;
            command.Model = updateProductModel;


            try
            {
                command.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProductCategory(int id, [FromBody] UpdateProductCategoryViewModel updateProductCategoryViewModel)
        {

            UpdateProductCommand command = new UpdateProductCommand(_context);

            command.ProductId = id;
            command.Model = new UpdateProductModel { CategoryId = updateProductCategoryViewModel.CategoryId };

            try
            {
                command.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {



            try
            {
                DeleteProductCommand command = new DeleteProductCommand(_context);
                command.ProductId = id;
                command.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }



            return Ok();//200
        }

        [HttpHead("{id}")]
        public string PostHead(int id)
        {
            return "merhaba";
        }

        private Product CheckByIdIfItemExist(int id)
        {

            var temp = InMemoryDal.MemoryDal.ProductList.SingleOrDefault(p => p.Id == id);
            if (temp is not null)
            {
                return temp;
            }
            return null;
        }

        [HttpGet("/panel/{authorization}")]
        public IActionResult HowToReturn401(string authorization)
        {
            if (authorization == "user")
            {
                return Unauthorized();//401
            }
            return Ok();
        }

        [HttpGet("/panel/vip/{authorization}")]
        public IActionResult HowToReturn403(string authorization)
        {
            if (authorization == "user")
            {
                return StatusCode(403);// Forbidden
            }
            return Ok();
        }

        [HttpGet("/admin")]
        public IActionResult HowToReturn503()
        {

            return StatusCode(503);
        }

        [HttpGet("sortAscById")]
        public IActionResult SortAscById()
        {
            ListProductsByAscOrderQuery query = new ListProductsByAscOrderQuery(_context);
            List<Product> orderedList;
            try
            {
                orderedList = query.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

            if (orderedList.Count == 0)
            {
                return NotFound();
            }
            return Ok(orderedList);
        }

        [HttpGet("sortDescById")]
        public IActionResult SortDescById()
        {
            ListProductsByDescOrderQuery query = new ListProductsByDescOrderQuery(_context);
            List<Product> descOrderedList;
            try
            {
                descOrderedList = query.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

            if (descOrderedList.Count == 0)
            {
                return NotFound();
            }
            return Ok(descOrderedList);
        }
    }
}
