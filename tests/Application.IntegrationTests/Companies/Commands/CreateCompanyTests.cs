using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using NUnit.Framework;
using ORRAS.Application.Companies.Commands;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.IntegrationTests.Companies.Commands
{
    using static TestingUtility;
    public class CreateCompanyTests : TestBase
    { 
        
        [Test]
        public async Task Should_Require_Unique_DisplayName()
        {
            // arrange
            await SendAsync(new CreateCompany.Command
            {
                Company = new Company 
                {   Id = Guid.NewGuid(), 
                    DisplayName = "Oxford Univerity"
                }
            });

            var command = new CreateCompany.Command 
            { 
                Company = new Company 
                {   Id = Guid.NewGuid(),
                    DisplayName = "Oxford Univerity"
                }
            };

            // act
            // assert
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }
        
        [Test]
        public async Task Should_Require_Minimum_Fields()
        {
            var command = new CreateCompany.Command 
            { 
                Company = new Company 
                {   Id = Guid.NewGuid(),
                    Abbreviation = "UO"
                }
            };

            // act
            // assert
            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }
        
        [Test]
        public async Task Should_Create_Company()
        {
            var command = new CreateCompany.Command
            {
                Company = new Company
                {
                    Id = Guid.NewGuid(),
                    DisplayName = "The Test Company",
                    Abbreviation = "TTC"
                }
            };

            var companyid = await SendAsync(command);

            var company = await FindAsync<Company>(command.Company.Id);

            company.Should().NotBeNull();
            company.DisplayName.Should().Be(command.Company.DisplayName);
            company.Created.Should().BeCloseTo(DateTime.Now, 10000);
        }

        


    }
}