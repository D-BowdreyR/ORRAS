using System;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string CreatorId { get; set; }
        public Comment ParentComment { get; set; }
        public Guid ParentCommentId { get; set; }
    }
}