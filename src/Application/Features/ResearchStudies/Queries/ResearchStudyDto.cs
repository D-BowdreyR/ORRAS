using System;

namespace ORRAS.Application.Features.ResearchStudies.Queries
{
    public class ResearchStudyDto
    {
        public Guid Id { get; set; }
        public string LocalPID { get; set; }
        public string IrasProjectID { get; set; }
        public string EudraCTReference { get; set; }
        public string HRAReference { get; set; }
        public string ShortTitle { get; set; }
        public string Acronym { get; set; }
        public string LongTitle { get; set; }
        public DateTime Created { get; set; }
        public DateTime EstimatedStartDate { get; set; }
    }
}