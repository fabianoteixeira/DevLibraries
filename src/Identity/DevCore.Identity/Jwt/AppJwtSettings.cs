using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCore.Identity.Jwt
{
    public class AppJwtSettings
    {
        public string SecretKey { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public IList<string> Issuers { get; set; }
        public string Audience { get; set; }
        public IList<string> Audiences { get; set; }
    }
}
