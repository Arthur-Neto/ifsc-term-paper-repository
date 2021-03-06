﻿using System;
using FluentAssertions;
using NUnit.Framework;
using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Infra.Data.Crosscutting.Guard;

namespace ifsc.tcc.Portal.Tests.Infra.Data.Crosscutting.GuardTests
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void Should_NotThrowException_When_ObjectIsNotNull()
        {
            // Arrange
            var notNull = new object();
            var argument = ExceptionArguments.NotFound;

            // Action
            Action action = () => Guard.AgainstNull(notNull, argument);

            // Assert
            action.Should().NotThrow();
        }

        [Test]
        public void Should_ThrowNullReferenceException_When_ObjectIsNull()
        {
            // Arrange
            object nullObj = null;
            var argument = ExceptionArguments.NotFound;

            // Action
            Action action = () => Guard.AgainstNull(nullObj, argument);

            // Assert
            action.Should().Throw<NullReferenceException>().WithMessage("NotFound");
        }
    }
}
