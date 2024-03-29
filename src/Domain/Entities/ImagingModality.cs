using System;
using System.Collections.Generic;
using ORRAS.Domain.Common;

namespace ORRAS.Domain.Entities
{
    public class ImagingModality : AuditableEntity
    {
        public Guid Id { get; set; }
        public string ModalityCode { get; set; }
        public string ModalityName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ImagingProcedure> ImagingProcedures { get; private set; } = new List<ImagingProcedure>();
    }
}