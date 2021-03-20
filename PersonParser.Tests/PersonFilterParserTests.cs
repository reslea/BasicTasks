﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace PersonParser.Tests
{
    public class PersonFilterParserTests
    {
        private readonly Mock<IPersonParser> _fakeParserMock;

        public PersonFilterParserTests()
        {
            _fakeParserMock = new Mock<IPersonParser>();
        }

        [Fact]
        public void Get_Adults()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Oleg",
                Age = 20
            };

            _fakeParserMock
                .Setup(_ => _.GetPeople())
                .Returns(new List<Person> { person });

            var personFilter = new PersonFilter(_fakeParserMock.Object);
            var adults = personFilter.GetAdults().ToList();

            Assert.True(adults.Any());
            Assert.True(adults.First().Id == person.Id);
        }
    }
}
