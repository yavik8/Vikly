using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vikly.Context;
using Vikly.Keys;
using Vikly.Models;

namespace Vikly.Controllers
{
    [Route("api/sr/")]
    [ApiController]
    public class ShortnrController : ControllerBase
    {
        private readonly SqlDbContext dbContext;
        private readonly IKeyGenerator _keyGenerator;
        public ShortnrController(SqlDbContext sqlDbContext, IKeyGenerator keyGenerator)
        {
            dbContext = sqlDbContext;
            _keyGenerator = keyGenerator;
        }
        [HttpGet("{key}")]
        public async Task<IActionResult> GetFullUrlAsync(string key)
        {

            var queryResult=  await dbContext.FindAsync<ShortnrModel>(key);
            if (queryResult != null)
            {
                var result = new ShortnrReturnModel()
                {
                    Message = "Url Found",
                    Status = true,
                    Url = queryResult.LongUrl
                };
                return Ok(result);
            }
            else
            {
                var result = new ShortnrReturnModel()
                {
                    Message = "Url Not Found",
                    Status = false,
                };
                return Ok(result);
            }           
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> createShortUrl([FromBody] ShortnrObject content)
        {
            var data = new ShortnrModel()
            {              
                ShortUrl = _keyGenerator.GetKey(),
                LongUrl = content.Url.ToString(),
            };
            try
            {
                await dbContext.AddAsync(data);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }          
           return Ok( new LinkObject()
           {
               Url = "localhost/sr/" + data.ShortUrl.ToString()
           });
        }
    }
}
