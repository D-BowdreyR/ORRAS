using System;
using System.Collections.Generic;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class Modality : AuditableEntity
    {
        public Guid Id { get; set; }

        public string ModalityCode { get; set; }

        public string ModalityName { get; set; }

        public IList<ImagingProcedure> ImagingProcedures { get; private set; } = new List<ImagingProcedure>();
    }
}