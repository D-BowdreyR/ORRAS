using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ORRAS.Application.Features.ResearchStudies.Queries;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.IntegrationTests.ResearchStudies.Queries
{
    using static TestingUtility;
    public class GetStudiesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllStudies()
        {
            // Arrange
            await AddRangeAsync(
                new List<ResearchStudy> {
                    new ResearchStudy {
                        Id = Guid.NewGuid(),
                        LocalPID = "136448",
                        IrasProjectID = "4554/454/443",
                        EudraCTReference = "54861",
                        HRAReference = "455464",
                        ShortTitle = "ShortTitle TestStudy 1"
                    },
                    new ResearchStudy {
                        Id = Guid.NewGuid(),
                        LocalPID = "165446",
                        IrasProjectID = "4564/6164/165",
                        EudraCTReference = "48564",
                        HRAReference = "397126",
                        ShortTitle = "ShortTitle TestStudy 2"
                    },
                    new ResearchStudy {
                        Id = Guid.NewGuid(),
                        LocalPID = "187532",
                        IrasProjectID = "7568/464d/8df45",
                        EudraCTReference = "45554",
                        HRAReference = "564684",
                        ShortTitle = "ShortTitle TestStudy 3"
                    },
                }
            );

            var query = new ListStudies.Query();

            // Act
            StudiesVm result = await SendAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.Studies.Should().HaveCount(3);
        }

        
    }
}