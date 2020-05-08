using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }
        public UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        public UserResponse(string message) : this(false, message, null) { }

        public UserResponse(User user) : this(true, string.Empty, user) { }
    }
}