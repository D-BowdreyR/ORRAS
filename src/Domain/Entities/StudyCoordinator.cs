using System;
using ORRAS.Domain.Common;

namespace ORRAS.Domain.Entities
{
    public class StudyCoordinator : AuditableEntity
    {
        public string AppUserId { get; set; }
        public ResearchStudy ResearchStudy { get; set; }
        public Guid ResearchStudyId { get; set; }
        public bool IsPrimary { get; set; }
    }
}