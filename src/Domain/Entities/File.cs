using System;

namespace ORRAS.Domain.Entities
{
    public class File
    {
        public Guid Id { get; set; }
        public Document Document { get; set; }
        public Guid DocumentId { get; set; }
        public float Version { get; set; }
        public bool IsSuperseeded { get; set; }
        public byte MyProperty { get; set; }
    }
}