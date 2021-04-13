using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ORRA.Application.Companies.Queries;
using ORRA.Domain.Entities;
using System.Linq;
using ORRA.Application.Companies.Commands;

namespace ORRA.Application.IntegrationTests.Companies.Queries
{
    using static TestingUtility;
    public class CompaniesTests : TestBase
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

        // [Test]
        // public async Task ShouldRequireUniqueDisplayName()
        // {
        //     // arrange
        //     await SendAsync(new CreateCompany.Command
        //     {
        //         DisplayName = "Oxford"
        //     });

        //     var command = new CreateCompany.Command { DisplayName = "Oxford" };

        //     // act
        //     // assert

        //     FluentActions.Invoking(() => SendAsync(command))
        //         .Should().Throw<ValidationException>();
        // }

      
    }
}