﻿using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections
{
    /// <content>
    /// The HaveCountGreaterThan specs.
    /// </content>
    public partial class CollectionAssertionSpecs
    {
        #region Have Count Greater Than

        [Fact]
        public void Should_succeed_when_asserting_collection_has_a_count_greater_than_less_the_number_of_items()
        {
            // Arrange
            var collection = new[] { 1, 2, 3 };

            // Act / Assert
            collection.Should().HaveCountGreaterThan(2);
        }

        [Fact]
        public void Should_fail_when_asserting_collection_has_a_count_greater_than_the_number_of_items()
        {
            // Arrange
            var collection = new[] { 1, 2, 3 };

            // Act
            Action act = () => collection.Should().HaveCountGreaterThan(3);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_collection_has_a_count_greater_than_the_number_of_items_it_should_fail_with_descriptive_message_()
        {
            // Arrange
            var collection = new[] { 1, 2, 3 };

            // Act
            Action action = () => collection.Should().HaveCountGreaterThan(3, "because we want to test the failure {0}", "message");

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage("*more than*3*because we want to test the failure message*3*");
        }

        [Fact]
        public void When_collection_count_is_greater_than_and_collection_is_null_it_should_throw()
        {
            // Arrange
            IEnumerable<string> collection = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                collection.Should().HaveCountGreaterThan(1, "we want to test the behaviour with a null subject");
            };

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*more than*1*we want to test the behaviour with a null subject*found <null>*");
        }

        #endregion
    }
}
