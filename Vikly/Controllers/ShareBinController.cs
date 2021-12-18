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
    [Route("api/sb/")]
    [ApiController]
    public class ShareBinController : ControllerBase
    {
        private readonly SqlDbContext dbContext;
        private readonly IKeyGenerator _keyGenerator;
        public ShareBinController(SqlDbContext sqlDbContext, IKeyGenerator keyGenerator)
        {
            dbContext = sqlDbContext;
            _keyGenerator = keyGenerator;
        }
        [HttpGet("{key}")]
        public async Task<IActionResult> GetBinDataAsync(string key)
        {
            var queryResult = await dbContext.FindAsync<ShareBinModel>(key);
            if (queryResult != null)
            {
                var result = new ShareBinReturnModel()
                {
                    Status = true,
                    Title = queryResult.ShareBinTitle.ToString(),
                    CodeBin = queryResult.ShareBinCode.ToString()
                };
                return Ok(result);
            }
            else
            {
                var result = new ShortnrReturnModel()
                {
                    Status = false
                };
                return Ok(result);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> createAsync([FromBody] ShareBinObject content)
        {
            {
                var data = new ShareBinModel()
                {
                    ShareBinKey = _keyGenerator.GetKey(),
                    ShareBinCode = content.BinCode.ToString(),
                    ShareBinTitle = content.Title.ToString()
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

                return Ok(new LinkObject()
                {
                    Url = "localhost/sb/" + data.ShareBinKey.ToString()
                });
            }
        }
    }
}
