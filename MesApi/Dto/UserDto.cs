using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MesApi.Dto
{
    public class UserDto
    {
        public required string Username {  get; set; }
        public required string Token { get; set; }
    }
}