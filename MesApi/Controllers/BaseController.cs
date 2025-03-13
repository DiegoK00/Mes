using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MesApi.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    [Route("[api]/[controller]")]
    public class BaseController : ControllerBase
    {
        
    }

}