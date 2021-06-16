using System;
using System.Collections.Generic;
using ORRAS.Domain.Common;

namespace ORRAS.Domain.Entities
{
    public class ResearchStudy : AuditableEntity
    {
        public Guid Id { get; set; }
        public string LocalPID { get; set; }
        public string IrasProjectID { get; set; }
        public string EudraCTReference { get; set; }
        public string HRAReference { get; set; }
        public string ShortTitle { get; set; }
        public string Acronym { get; set; }
        public string LongTitle { get; set; }

        // commented out for simplicity for prototype

        // public ClinicalResearchCategory ResearchCategory { get; set; }
        // public int ResearchTypeId { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public float EstimatedTotalDurationInMonths { get; set; }
        public Boolean IsInvolvingMedicalDeviceTrial { get; set; } = false;
        public Boolean IsInvolvingRadiotherapy { get; set; } = false;
        public Boolean IsInvolvingRadioactiveSubstances { get; set; } = false;
        public Boolean IsMultiCentre { get; set; } = false;
        public int NumberOfUKCentres { get; set; }

        // commented out for simplicity for prototype

        // public ICollection<Comment> ReseachStudyComments { get; set; } = new List<Comment>();
        // public ICollection<StudyCoordinator> StudyCoordinators { get; set; } = new List<StudyCoordinator>();
        // public ICollection<PrincipalInvestigator> PrincipalInvestigators { get; set; } = new List<PrincipalInvestigator>();
        // public ICollection<ChiefInvestigator> ChiefInvestigators { get; set; } = new List<ChiefInvestigator>();
        // public ICollection<Document> StudyDocuments { get; set; } = new List<Document>();
        // public Company StudySponsor { get; set; }
        // public Guid StudySponsorId { get; set; }

    }
}