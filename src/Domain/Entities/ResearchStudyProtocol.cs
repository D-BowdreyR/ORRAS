using System;
namespace ORRAS.Domain.Entities
{
    public class ResearchStudyProtocol
    {
        public Guid Id { get; set; }
        public bool IsSuperseeded { get; set; }
        public DateTime Version { get; set; }
    }
}