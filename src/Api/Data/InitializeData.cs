using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Data
{
    public static class InitializeData
    {
        public static void InitializeOrders(AppDbContext context)
        {
            if (context.Order.Any())
                return;

            var orders = new List<Order>(){
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    Date = DateTime.Now
                },
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Number = 2,
                    Date = DateTime.Now
                }
            };           

            context.AddRange(orders);
            context.SaveChanges();
        }

        public static void InitializeItems(AppDbContext context)
        {
            if (context.Item.Any())
                return;

            var items = new List<Item>(){
                new Item() {
                    Id = Guid.NewGuid(),
                    Name = "Item A",
                    Price = 9.99m,
                    OrderId = context.Order.FirstOrDefault(x => x.Number == 1).Id
                },
                new Item() {
                    Id = Guid.NewGuid(),
                    Name = "Item B",
                    Price = 25.50m,
                    OrderId = context.Order.FirstOrDefault(x => x.Number == 1).Id
                },
                new Item() {
                    Id = Guid.NewGuid(),
                    Name = "Item C",
                    Price = 150.98m,
                    OrderId = context.Order.FirstOrDefault(x => x.Number == 1).Id
                }
            };

            context.AddRange(items);
            context.SaveChanges();
        }
    }
}