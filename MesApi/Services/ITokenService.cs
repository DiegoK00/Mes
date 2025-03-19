using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MesApi.Models;

namespace MesApi.Services
{
    public interface ITokenService
    {
        string CreateToken(Utenti user);
        
    }
}