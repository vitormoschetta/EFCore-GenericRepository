using System;
using System.Collections;
using System.Collections.Generic;

namespace Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}