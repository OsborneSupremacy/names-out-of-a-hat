using AutoFixture;
using FluentAssertions;
using Moq;
using NamesOutOfAHat.Interface;
using NamesOutOfAHat.Models;
using NamesOutOfAHat.Test.Utility;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NamesOutOfAHat.Service.Tests
{
    public class ValidationServiceTests
    {
        [Fact]
        public void Validate_Should_Fail_When_People_Invalid()
        {
            // arrange
            var autoFixture = new Fixture().AddAutoMoqCustomization();

            IList<IGiver> input = new List<IGiver>();

            var expectedErrors = new List<string>() { "error1", "error2" };

            //
            autoFixture.Freeze<Mock<IComponentModelValidationService>>()
                .Setup(x => x.Validate(It.IsAny<IList<IGiver>>()))
                .Returns((false, expectedErrors));

            var service = autoFixture.Create<ValidationService>();

            // act
            var (isValid, errors) = service.Validate(input);

            // assert
            isValid.Should().BeFalse();
            errors.Should().BeEquivalentTo(expectedErrors);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(31)]
        public void Validate_Should_Fail_When_Invalid_Person_Count(int personCount)
        {
            // arrange
            var autoFixture = new Fixture().AddAutoMoqCustomization();
            IList<IGiver> input = new List<IGiver>();

            int x = 0;
            while(x++ < personCount)
                input.Add(new Giver());

            autoFixture.Freeze<Mock<IComponentModelValidationService>>()
                .Setup(x => x.Validate(It.IsAny<IList<IGiver>>()))
                .Returns((true, Enumerable.Empty<string>().ToList()));

            var service = autoFixture.Create<ValidationService>();

            // act
            var (isValid, errors) = service.Validate(input);

            // assert
            isValid.Should().BeFalse();
            errors.Count().Should().Be(1);
        }



    }
}
