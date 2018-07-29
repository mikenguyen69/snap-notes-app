using Snap.Notes.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Notes.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
    }
}
