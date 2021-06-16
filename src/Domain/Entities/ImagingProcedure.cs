using System;
using ORRAS.Domain.Common;
using ORRAS.Domain.Enums;

namespace ORRAS.Domain.Entities
{
    public class ImagingProcedure : AuditableEntity
    {
        public int Id { get; set; }
        public string ShortCode { get; set; }
        public string DisplayTerm { get; set; }
        public ImagingProcedureStatus Status { get; set; } = ImagingProcedureStatus.Active;
        public string RecommendedSubstituteProcedure { get; set; }
        public ImagingModality Modality { get; set; }
        public Guid ModalityId { get; set; }
        public string SNOMEDCT_ConceptID { get; set; }
        public string SNOMEDCT_LateralityID { get; set; }
        public string SNOMEDCT_FSN { get; set; }
        public int BodyPartMultiplicationFactor { get; set; }
        public bool IsInterventional { get; set; }
        public bool IsDiagnostic { get; set; }
        public bool IsDeprecated { get; set; } = false;
    }
}