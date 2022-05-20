using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ECommerceDBContext _context;

        public CategoryController(ECommerceDBContext DBContext)
        {
            _context = DBContext;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IEnumerable<TblCategory> GetAllCategories()
        {
            return _context.TblCategories.ToList();
        }
    }
}
