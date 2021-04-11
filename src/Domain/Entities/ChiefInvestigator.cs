using System;

namespace ORRA.Domain.Entities
{
    public class ChiefInvestigator
    {
        public string AppUserId { get; set; }
        public ResearchStudy ResearchStudy { get; set; }
        public Guid ResearchStudyId { get; set; }
        public bool IsPrimary { get; set; }
    }
}