﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Helpers
{
    public class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Role = "role", Id = "id";

           
            }

            public static class JwtClaims
            {
                public const string UserAccess = "user_access";
                public const string AdminAccess = "admin_access";
                public const string ApiAccess = "api_access";
            }
        }
    }
}
