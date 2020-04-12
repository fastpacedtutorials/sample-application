using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataAccessHelper _da;
        public UserController(IDataAccessHelper da)
        {
            _da = da;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(_da.SelectList<User>("Select * from [User]"));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}