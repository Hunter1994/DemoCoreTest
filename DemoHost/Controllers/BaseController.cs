using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController: Controller
    {
    }
}
