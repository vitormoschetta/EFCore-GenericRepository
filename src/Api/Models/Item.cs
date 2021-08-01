using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }        
    }
}