using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class PostResponse : BaseResponse<Post>
    {
        public PostResponse(Post post) : base(post)
        {
        }

        public PostResponse(string message) : base(message) { }

    }
}
