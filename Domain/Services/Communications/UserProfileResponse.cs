<<<<<<< HEAD
﻿using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
      public class UserProfileResponse : BaseResponse
   {
       public UserProfile UserProfile { get; private set; }
       public UserProfileResponse(bool success, string message, UserProfile userProfile) : base(success, message)
       {
           UserProfile = userProfile;
       }

       public UserProfileResponse(string message) : this(false, message, null) { }

       public UserProfileResponse(UserProfile userProfile) : this(true, string.Empty, userProfile) { }
   }
   
}
=======
﻿using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
      public class UserProfileResponse : BaseResponse<UserProfile>
   {
        public UserProfileResponse(UserProfile userProfile) : base(userProfile)
        {
        }

        public UserProfileResponse(string message) : base(message) { }
    }
   
}
>>>>>>> Miguel
