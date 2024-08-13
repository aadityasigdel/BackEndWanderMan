using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models;


namespace NewProject.Interface
{
    public interface ITokenService
    {
         string CreateToken (AppUser user);
    }
}