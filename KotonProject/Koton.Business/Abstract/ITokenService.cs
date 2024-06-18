using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Abstract
{
    public interface ITokenService
    {
        public string CreateToken();
    }
}
