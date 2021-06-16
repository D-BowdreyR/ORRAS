using System;

namespace ORRAS.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }

        // will need to implement a current user service for these
        // public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        // will need to implement a current user service for these
        // public string LastModifiedBy { get; set; }
    }
}