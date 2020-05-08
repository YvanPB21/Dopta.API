using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class PostResponse : BaseResponse
    {
        public Post Post{ get; private set; }
        public PostResponse(bool success, string message, Post post) : base(success, message)
        {
            Post = post;
        }

        public PostResponse(string message) : this(false, message, null) { }

        public PostResponse(Post post) : this(true, string.Empty, post) { }

    }
}
