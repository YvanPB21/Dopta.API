using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User user) : base(user)
        {
        }

        public UserResponse(string message) : base(message) { }
    }
}