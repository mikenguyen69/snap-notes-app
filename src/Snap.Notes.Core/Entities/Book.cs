using Snap.Notes.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Notes.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
    }
}
