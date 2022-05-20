using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public interface IProductService
    {
        public List<Product> FindAll();
    }
}
