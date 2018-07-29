using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap.Notes.Api.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int BookId { get; set; }
    }
}
