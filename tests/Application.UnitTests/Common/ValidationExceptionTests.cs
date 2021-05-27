
using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using ORRAS.Application.Common.Exceptions;

namespace ORRAS.Application.UnitTests.Common
{
    public class ValidationExceptionTests
    {
        [Test]
        public void Default_Constructor_Should_Create_EmptyDictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Test]
        public void Given_Single_Validation_Failure_Should_Create_Single_Element_Dict()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Title", "must not be empty"),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Title" });
            actual["Title"].Should().BeEquivalentTo(new string[] { "must not be empty" });
        }

        [Test]
        public void Given_Multi_ValidationFailures_For_Multi_Properties_Should_Create_Multi_Element_Dict_With_Multi_Values()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Title", "must not be empty"),
                new ValidationFailure("Title", "must not be more than 30 characters long"),
                new ValidationFailure("Password", "must contain at least 8 characters"),
                new ValidationFailure("Password", "must contain a digit"),
                new ValidationFailure("Password", "must contain upper case letter"),
                new ValidationFailure("Password", "must contain lower case letter"),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Password", "Title" });

            actual["Title"].Should().BeEquivalentTo(new string[]
            {
                "must not be more than 30 characters long",
                "must not be empty",
            });

            actual["Password"].Should().BeEquivalentTo(new string[]
            {
                "must contain lower case letter",
                "must contain upper case letter",
                "must contain at least 8 characters",
                "must contain a digit",
            });
        }
    }
}