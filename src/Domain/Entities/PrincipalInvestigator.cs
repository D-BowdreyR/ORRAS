using System;

namespace ORRAS.Domain.Entities
{
    public class PrincipalInvestigator
    {
        public string AppUserId { get; set; }
        public ResearchStudy ResearchStudy { get; set; }
        public Guid ResearchStudyId { get; set; }
        public bool IsPrimary { get; set; }
    }
}