﻿//  ----------------------------------------------------------------------------------------------------------------------
//  <copyright file="DbConnectionStringBuilderExtensionTests.cs" company="James Consulting LLC">
//    Copyright (c) 2020 All Rights Reserved
//  </copyright>
//  <author>Rudy James</author>
//  <summary>
//  
//  </summary>
//  ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Common;
using FluentAssertions;
using JamesConsulting.Data.Common;
using Xunit;

namespace JamesConsulting.Tests.Data.Common
{
    /// <summary>
    ///     The <see cref="DbConnectionStringBuilderExtensions" /> tests.
    /// </summary>
    public class DbConnectionStringBuilderExtensionTests
    {
        [Fact]
        public void RemoveKeysFromConnectionString()
        {
            DbConnectionStringBuilder dbConnectionStringBuilder = new DbConnectionStringBuilder
            {
                ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
            };

            dbConnectionStringBuilder.ConnectionString.Contains("myPassword").Should().BeTrue();

            dbConnectionStringBuilder.RemoveKeys("Password");

            dbConnectionStringBuilder.ConnectionString.Contains("myPassword").Should().BeFalse();
        }

        /// <summary>
        ///     The remove keys throws <see cref="ArgumentException" /> when keys is empty.
        /// </summary>
        [Fact]
        public void RemoveKeysThrowsArgumentNullExceptionWhenKeysIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new DbConnectionStringBuilder().RemoveKeys());
        }

        /// <summary>
        ///     The remove keys throws argument null exception when <see cref="DbConnectionStringBuilder" /> is null.
        /// </summary>
        [Fact]
        public void RemoveKeysThrowsArgumentNullExceptionWhenDbConnectionStringBuilderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => default(DbConnectionStringBuilder)!.RemoveKeys());
        }

        /// <summary>
        ///     The remove keys throws <see cref="ArgumentNullException" /> when keys is null.
        /// </summary>
        [Fact]
        public void RemoveKeysThrowsArgumentNullExceptionWhenKeysIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DbConnectionStringBuilder().RemoveKeys(default!));
        }
    }
}