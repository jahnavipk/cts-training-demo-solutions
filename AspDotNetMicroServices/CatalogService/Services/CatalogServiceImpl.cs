using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Services
{
    public class CatalogServiceImpl : ICatalogService
    {
        public List<Category> FindAll()
        {
            return new List<Category> { 
            new Category{Id=1,Name="User 1"},
            new Category{Id=2,Name="User 2"},
            new Category{Id=3,Name="User 3"},
            new Category{Id=4,Name="User 4"}
            };
        }
    }
}
