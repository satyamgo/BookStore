using BookStore.Core.Entities.Models;
using BookStore.Services.Implementation;
using BookStore.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("{id}")]
        public Bookitem Get(int id)
        {
            return _itemService.Find(id);
        }


        [HttpGet]
        public IEnumerable<Bookitem> GetByStatus()
        {
            return _itemService.getbystatus();
        }
        [HttpPost]
        public IActionResult Add(Bookitem product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                _itemService.Add(product);
                _itemService.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Bookitem product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }
               _itemService.Update(product);
               _itemService.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
