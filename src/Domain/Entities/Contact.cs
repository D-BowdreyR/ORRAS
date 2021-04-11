using System;

namespace ORRA.Domain.Entities
{
    public class Contact : Person
    {
        public string JobTitle { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public string Qualification { get; set; }
        // this could be a collection of EmailAddresses with a default flag for one in the collection
        public string EmailAddress { get; set; }
        // this could be a collection of Telephone Objects
        public string TelephoneNumber { get; set; }
    }
}