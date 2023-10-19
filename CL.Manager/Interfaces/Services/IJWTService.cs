using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;

namespace CL.Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}