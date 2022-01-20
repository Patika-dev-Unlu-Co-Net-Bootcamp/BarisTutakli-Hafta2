﻿using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.CreateProduct;
using BarisTutakli.WebApi.ProductOperations.DeleteProduct;
using BarisTutakli.WebApi.ProductOperations.GetProductDetail;
using BarisTutakli.WebApi.ProductOperations.GetProducts;
using BarisTutakli.WebApi.ProductOperations.UpdateProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Controllers
{
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

        /// <summary>
        /// Get a specific product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

    
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Create([FromBody]Product product)
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
            return Created("Index",new {message="Product added.", time = DateTime.Now });//201
            
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Product product)
        {
            var result = CheckByIdIfItemExist(id);
            if (CheckByIdIfItemExist(product.Id) is  null)
            {
                return NotFound();//404
            }
           
            try
            {
                result.Id = product.Id != default ? product.Id : result.Id;
                result.ProductName = product.ProductName!= default ? product.ProductName:result.ProductName;
                result.CategoryId = product.CategoryId != default ? product.CategoryId : result.CategoryId; 
                result.PublishingDate = product.PublishingDate != default ? product.PublishingDate : result.PublishingDate;
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
            return Ok();

        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Update(int id,[FromBody] UpdateProductModel updateProductModel)
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

        /// <summary>
        ///  Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  Unauthorized request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorization"></param>
        /// <returns></returns>
        [HttpGet("/panel/{authorization}")]
        public IActionResult HowToReturn401(string authorization)
        {
            if (authorization=="user")
            {
                return Unauthorized();//401
            }
            return Ok();
        }

        /// <summary>
        ///  Forbidden
        /// </summary>
        /// <param name="authorization"></param>
        /// <returns></returns>
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
            List<Product> temp;
            try
            {
                temp = InMemoryDal.MemoryDal.ProductList.OrderBy(p => p.Id).ToList();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            if (temp.Count == 0)
            {
                return NotFound();
            }
            return Ok(temp);
        }
        [HttpGet("sortDescById")]
        public IActionResult SortDescById()
        {
            List<Product> temp;
            try
            {
                temp = InMemoryDal.MemoryDal.ProductList.OrderByDescending(p => p.Id).ToList();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            if (temp.Count==0)
            {
                return NotFound();
            }
            return Ok(temp);
        }
      

    }
}
