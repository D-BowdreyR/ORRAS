using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ORRAS.Application.Common.Exceptions;
using ORRAS.Application.Features.ResearchStudies.Queries;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.IntegrationTests.ResearchStudies.Queries
{

    using static TestingUtility;
    public class GetStudyTests : TestBase
    {
        [Test]
        public async Task ShouldReturnCorrectStudy()
        {
            // Arrange
            var teststudy = new ResearchStudy
            {
                Id = Guid.NewGuid(),
                LocalPID = "136448",
                IrasProjectID = "4554/454/443",
                EudraCTReference = "54861",
                HRAReference = "455464",
                ShortTitle = "ShortTitle TestStudy 1"
            };

            await AddAsync(teststudy);

            // Act
            var query = new GetStudy.Query { Id = teststudy.Id };
            ResearchStudyDto result = await SendAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(teststudy.Id);
        }

        [Test]
        public async Task GivenNoMatchingIdShouldReturnNotFoundException()
        {
            // Arrange
            var teststudy = new ResearchStudy
            {
                Id = Guid.NewGuid(),
                LocalPID = "136448",
                IrasProjectID = "4554/454/443",
                EudraCTReference = "54861",
                HRAReference = "455464",
                ShortTitle = "ShortTitle TestStudy 1"
            };

            await AddAsync(teststudy);

            var query = new GetStudy.Query { Id = Guid.NewGuid() };

            FluentActions.Invoking(() => SendAsync(query))
                .Should().Throw<NotFoundException>();
        }

    }
}