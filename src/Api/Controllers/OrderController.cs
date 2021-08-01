using System;
using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Data.Interfaces;
using Api.Data.Repositories;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IOrderRepository _repository;
        public OrderController(AppDbContext context, IOrderRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add(Order item)
        {
            _repository.Add(item);
            _repository.Commit();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Order item)
        {
            _repository.Update(item);
            _repository.Commit();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(order => order.Id == id);
            _repository.Commit();
            return Ok();
        }

        [HttpGet]
        public Order Find(Guid id)
        {
            return _repository.Find(id);
        }

        [HttpGet]
        public Order First(Guid id)
        {
            return _repository.First(order => order.Id == id);
        }

        [HttpGet]
        public IEnumerable<Order> GetAfterDate(DateTime date)
        {
            return _repository.Get(order => order.Date > date);
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _repository.GetAll();
        }
    }
}