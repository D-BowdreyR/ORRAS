using System;
using System.Collections.Generic;

namespace ORRA.Domain.Entities
{
    public class Modality
    {
        public Guid Id { get; set; }

        public string ModalityCode { get; set; }

        public string ModalityName { get; set; }

        public IList<ImagingProcedure> ImagingProcedures { get; private set; } = new List<ImagingProcedure>();
    }
}