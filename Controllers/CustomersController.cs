using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GestorRRHH_BackEnd_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomersController : ControllerBase
    {
        private string[] lista = new string[] { "John Doe", "Jane Doe" };
        [HttpGet, Authorize]
        public IEnumerable<string> Get() => lista;
    }
}
