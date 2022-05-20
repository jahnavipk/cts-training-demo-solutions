using DemoAzureApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAzureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {

        sampleDBContext _context;

        public SampleController(sampleDBContext context)
        {
            _context = context;
        }


        public IEnumerable<TblSample> Get()
        {

            return _context.TblSamples.ToList();

        }
    }
}
