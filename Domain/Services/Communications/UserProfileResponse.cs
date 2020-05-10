using Dopta.API.Domain.Models;
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
