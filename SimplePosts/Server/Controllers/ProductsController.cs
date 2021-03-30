using Microsoft.AspNetCore.Mvc;
using SimplePosts.Server.Repository.Interfaces;
using SimplePosts.Shared.Models.Entities;
using SimplePosts.Shared.Models.Forms;
using System;

namespace SimplePosts.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductForm form)
        {
            try
            {
                Product entity = new Product
                {
                    Name = form.Name,
                    Description = form.Description,
                    Price = form.Price,
                    Quantity = form.Quantity
                };

                return Ok(_repository.Create(entity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductForm form)
        {
            try
            {
                Product entity = new Product
                {
                    Id = id,
                    Name = form.Name,
                    Description = form.Description,
                    Price = form.Price,
                    Quantity = form.Quantity
                };

                return Ok(_repository.Update(entity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
