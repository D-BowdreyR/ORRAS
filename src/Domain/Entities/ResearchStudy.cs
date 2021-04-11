using System;
using System.Collections.Generic;

namespace ORRA.Domain.Entities
{
    public class ResearchStudy
    {
        public Guid Id { get; set; }
        public string PID { get; set; }
        public string ShortTitle { get; set; }
        public string Acronym { get; set; }
        public string LongTitle { get; set; }
        public ClinicalResearchType ResearchType { get; set; }
        public int ResearchTypeId { get; set; }
        public ICollection<Comment> ReseachStudyComments { get; set; } = new List<Comment>();
        public ICollection<StudyCoordinator> StudyCoordinators { get; set; } = new List<StudyCoordinator>();
        public ICollection<PrincipalInvestigator> PrincipalInvestigators { get; set; } = new List<PrincipalInvestigator>();
        public ICollection<ChiefInvestigator> ChiefInvestigators { get; set; } = new List<ChiefInvestigator>();
        public ICollection<Document> StudyDocuments { get; set; } = new List<Document>();
        public Organisation StudySponsor { get; set; }
        public Guid StudySponsorId { get; set; }

    }
}