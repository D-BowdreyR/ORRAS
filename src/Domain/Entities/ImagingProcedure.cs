using System;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class ImagingProcedure : AuditableEntity
    {
        public Guid Id { get; set; }

        public string CrisCode { get; set; }

        public string Term { get; set; }

        public int ExamCount { get; set; }

        public Modality Modality { get; set; }

        public Guid ModalityId { get; set; }

        public bool Interventional { get; set; }        

    }
}