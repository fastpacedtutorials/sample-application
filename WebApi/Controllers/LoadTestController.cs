using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadTestController : ControllerBase
    {
        Random rand = new Random();
        List<Thread> threads = new List<Thread>();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var futureTime = DateTime.Now.AddSeconds(5);
                while (DateTime.Now < futureTime)
                {
                    threads.Add(new Thread(new ThreadStart(KillCore)));
                }
                return new OkObjectResult(DateTime.Now);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void KillCore()
        {
            var futureTime = DateTime.Now.AddSeconds(5);
            long num = 0;
            while (DateTime.Now < futureTime)
            {
                num += rand.Next(100, 1000);
                if (num > 1000000) { num = 0; }
            }
        }

    }
}