using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.ModelSecurity
{
    public class AccessToken
    {
        public string Token { get; set; }
        public long ExpirationTicks { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public AccessToken(string token, long expirationTicks, RefreshToken refreshToken)
        {
            Token = token;
            ExpirationTicks = expirationTicks;
            RefreshToken = refreshToken;
        }
    }
}
