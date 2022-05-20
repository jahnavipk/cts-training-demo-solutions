using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        EFTestDBContext _context;

        public ValuesController(EFTestDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IEnumerable<Table2> GetAllCategories()
        {
            return _context.Table2s.ToList();
        }
    }
}
