using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductServiceImpl : IProductService
    {
        public List<Product> FindAll()
        {
            return new List<Product> { 
            new Product{Id=1,Name="User 1",Price=11.7},
            new Product{Id=2,Name="User 2",Price=67},
            new Product{Id=3,Name="User 3",Price=43},
            new Product{Id=4,Name="User 4",Price=89.7}
            };
        }
    }
}
