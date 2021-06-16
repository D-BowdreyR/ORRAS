using System;
namespace ORRAS.Domain.Entities
{
    public class ImagingProcedureModifierType
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string ShortCode { get; set; }
        public ImagingModality Modality { get; set; }
        public Guid ModalityId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}