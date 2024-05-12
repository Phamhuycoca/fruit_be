using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Features.Auth
{
    public class Refresh_TokenDto
    {
        public long UserId { get; set; }
        public DateTime Refresh_TokenExpires { get; set; }
        public string? RefreshToken { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
