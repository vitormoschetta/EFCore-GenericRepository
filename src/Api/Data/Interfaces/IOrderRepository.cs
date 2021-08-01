using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Api.Data.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
       
    }
}