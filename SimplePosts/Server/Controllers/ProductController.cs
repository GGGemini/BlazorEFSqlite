using Microsoft.AspNetCore.Mvc;
using SimplePosts.Server.Services;
using SimplePosts.Shared.Models.Entities;
using SimplePosts.Shared.Models.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimplePosts.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductServices service;

        public ProductController(ProductServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await service.GetProductsAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetProductAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductForm form)
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

                return Ok(await service.AddProductAsync(entity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductForm form)
        {
            try
            {
                Product entity = await service.GetProductAsync(id);

                if (entity == null)
                {
                    return BadRequest($"Сущности с id {id} не существует");
                }

                entity = new Product
                {
                    Id = id,
                    Name = form.Name,
                    Description = form.Description,
                    Price = form.Price,
                    Quantity = form.Quantity
                };

                return Ok(await service.UpdateProductAsync(entity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product entity = await service.GetProductAsync(id);

                if (entity == null)
                {
                    return BadRequest($"Сущности с id {id} не существует");
                }

                await service.DeleteProductAsync(entity);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
