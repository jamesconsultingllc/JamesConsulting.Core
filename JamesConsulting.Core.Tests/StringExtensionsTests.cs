//  ----------------------------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="James Consulting LLC">
//    Copyright (c) 2019 All Rights Reserved
//  </copyright>
//  <author>Rudy James</author>
//  <summary>
//  
//  </summary>
//  ----------------------------------------------------------------------------------------------------------------------

namespace JamesConsulting.Core.Tests
{
    using System;

    using FluentAssertions;

    using JamesConsulting.Core.Data.Common;

    using Xunit;

    /// <summary>
    ///     The string extensions tests.
    /// </summary>
    public class StringExtensionsTests
    {
        /// <summary>
        ///     The get bytes empty string returns empty byte array.
        /// </summary>
        [Fact]
        public void GetBytesEmptyStringReturnsEmptyByteArray()
        {
            var arg = string.Empty;
            arg.GetBytes().Should().BeEmpty();
        }

        /// <summary>
        ///     The get bytes null argument.
        /// </summary>
        [Fact]
        public void GetBytesNullArgument()
        {
            string arg = null;
            Assert.Throws<ArgumentNullException>(() => arg.GetBytes());
        }

        /// <summary>
        /// The string password from connection string strips password entry.
        /// </summary>
        /// <param name="passwordVariation">
        /// The password variation.
        /// </param>
        [Theory]
        [InlineData("Password")]
        [InlineData("password")]
        [InlineData("Pwd")]
        [InlineData("pwd")]
        public void StringPasswordFromConnectionStringStripsPasswordEntry(string passwordVariation)
        {
            var connectionString = $"Server=Test;Database=Test; User ID=Test;{passwordVariation}=Test;Trusted_Connection=false; Connection Timeout=60;";
            connectionString.StripPasswordFromConnectionString().Should().NotContain($"{passwordVariation}=Test");
        }

        /// <summary>
        ///     The strip password from connection string with empty connection string returns empty string.
        /// </summary>
        [Fact]
        public void StripPasswordFromConnectionStringWithEmptyConnectionStringReturnsEmptyString()
        {
            string.Empty.StripPasswordFromConnectionString().Should().BeEmpty();
        }

        /// <summary>
        ///     Strip password from connection string with null connection string throws argument null exception.
        /// </summary>
        [Fact]
        public void StripPasswordFromConnectionStringWithNullConnectionStringThrowsArgumentNullException()
        {
            string connectionString = null;
            Assert.Throws<ArgumentNullException>(() => connectionString.StripPasswordFromConnectionString());
        }

        /// <summary>
        /// The to title case.
        /// </summary>
        /// <param name="stringToConvertToTitleCase">
        /// The string to convert to title case.
        /// </param>
        /// <param name="titleCasedString">
        /// The title cased string.
        /// </param>
        /// <param name="expectedResult">
        /// The expected result.
        /// </param>
        [Theory]
        [InlineData("rudy james", "Rudy James", true)]
        [InlineData("rudy james", "Rudy james", false)]
        [InlineData("", "", true)]
        public void ToTitleCase(string stringToConvertToTitleCase, string titleCasedString, bool expectedResult)
        {
            var result = string.Equals(stringToConvertToTitleCase.ToTitleCase(), titleCasedString, StringComparison.Ordinal);
            result.Should().Be(expectedResult);
        }

        /// <summary>
        ///     The to title case null argument.
        /// </summary>
        [Fact]
        public void ToTitleCaseNullArgument()
        {
            string arg = null;
            Assert.Throws<ArgumentNullException>(() => arg.ToTitleCase());
        }

        /// <summary>
        ///     The truncate empty string returns empty string.
        /// </summary>
        [Fact]
        public void TruncateEmptyStringReturnsEmptyString()
        {
            string.Empty.Truncate(100).Should().BeEmpty();
        }

        /// <summary>
        /// The truncate invalid length throws argument out of range exception.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TruncateInvalidLengthThrowsArgumentOutOfRangeException(int length)
        {
            var arg = "testing";
            Assert.Throws<ArgumentOutOfRangeException>(() => arg.Truncate(length));
        }

        /// <summary>
        ///     The truncate null string throws argument null exception.
        /// </summary>
        [Fact]
        public void TruncateNullStringThrowsArgumentNullException()
        {
            string arg = null;
            Assert.Throws<ArgumentNullException>(() => arg.Truncate(0));
        }
    }
}