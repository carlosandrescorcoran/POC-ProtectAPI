using Microsoft.AspNetCore.Mvc;
using POC_ProtectAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_ProtectAPI.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet("getBooks")]
        public IActionResult GetBooks()
        {
            try
            {
                return Ok("");
            }
            catch (Exception)
            {
                return BadRequest("");
            }
        }

        [FeatureToggleValidation(ToggleName = "add-book")]
        [HttpPost("addBook")]
        public IActionResult AddBook()
        {
            try
            {
                return Ok("");
            }
            catch (Exception)
            {
                return BadRequest("");
            }
        }

    }
}
