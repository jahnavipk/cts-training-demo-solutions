using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        EFTestDBContext _context;

        public HomeController(EFTestDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IEnumerable<Table1> GetAllCategories()
        {
            return _context.Table1s.ToList();
        }
    }
}
