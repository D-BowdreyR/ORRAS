using System;
using System.Collections.Generic;

namespace ORRAS.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DocumentCategory Category { get; set; }
        public ICollection<File> Files { get; set; } = new List<File>();
    }
}