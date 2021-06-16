using System.Diagnostics.Contracts;
using System.Collections.Generic;
using ORRAS.Domain.Common;

namespace ORRAS.Domain.ValueObjects
{
    // Move info here https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    public class Address : ValueObject<Address>
    {
        public virtual string Line1 { get; private set; }
        public virtual string Line2 { get; private set; }
        public virtual string City { get; private set; }
        public virtual string County { get; private set; }
        public virtual string Country { get; private set; }
        public virtual string PostalCode { get; private set; }

        public Address() { }

        public Address(string line1, string line2, string city, string county, string country, string postalcode)
        {
            // Contracts.EnsureNotNull(line1, city, );
            Line1 = line1;
            Line2 = line2;
            City = city;
            County = county;
            Country = country;
            PostalCode = postalcode;
        }

        protected override bool EqualsCore(Address valueObject)
        {
        //    TODO: Implement Equality Check
           throw new System.NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            // TODO: implement HashCode overide
            throw new System.NotImplementedException();
        }
    }
}