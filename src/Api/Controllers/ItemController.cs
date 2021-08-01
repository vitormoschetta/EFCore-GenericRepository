using System;
using System.Collections.Generic;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            return _context.Item;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            var item = _context.Item.Find(id);
            _context.Item.Remove(item);
            _context.SaveChanges();
        }
    }
}