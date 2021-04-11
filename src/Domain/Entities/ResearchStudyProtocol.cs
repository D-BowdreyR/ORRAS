using System;
namespace ORRA.Domain.Entities
{
    public class ResearchStudyProtocol
    {
        public Guid Id { get; set; }
        public bool IsSuperseeded { get; set; }
        public DateTime version { get; set; }
    }
}