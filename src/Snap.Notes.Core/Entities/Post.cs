using Snap.Notes.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Notes.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int BookId { get; set; }
    }
}
