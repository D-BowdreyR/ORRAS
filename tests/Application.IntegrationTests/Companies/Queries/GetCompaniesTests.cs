using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ORRAS.Domain.Entities;
using System.Linq;
using ORRAS.Application.Features.Companies.Queries;

namespace ORRAS.Application.IntegrationTests.Companies.Queries
{
    using static TestingUtility;
    public class GetCompaniesTests : TestBase
    {

        [Test]
        public async Task ShouldReturnAllCompaniesAndRelatedDepartments()
        {
            // Arrange
            await AddAsync(new Company
            {
                DisplayName = "Oxford University",
                Abbreviation = "UO",
                Departments =
                {
                    new Department {DepartmentName = "Department of Computer Science", Acronym = "CS"},
                    new Department {DepartmentName = "Department of Physics", Acronym = "PYS"},
                    new Department {DepartmentName = "Nuffield Department of Medicine", Acronym = "NDM"},
                    new Department {DepartmentName = "Nuffield Department of Orthopaedics, Rheumatology and Musculoskeletal Sciences", Acronym = "NDORMS"},
                }
            });

            var query = new ListCompanies.Query();

            // Act
            CompaniesVm result = await SendAsync(query);
            // Assert
            result.Should().NotBeNull();
            result.Companies.Should().HaveCount(1);
            result.Companies.First().Departments.Should().HaveCount(4);
        }
      
    }
}