using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCore.Identity.Jwt.Model
{
    public class UserResponse<TKey>
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken<TKey> UserToken { get; set; }
    }

    public class UserResponse : UserResponse<string>
    {

    }
}
