//// -----------------------------------------------------------------------
//// <copyright file="App_Start.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using Fluent.Infrastructure.FluentTools;
using UnitTestExample.Testt.DataBase;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnitTestExample.Testt.App_Start), "PreStart")]

namespace UnitTestExample.Testt {
    public static class App_Start {
        public static void PreStart() {
            FluentStartup.Initialize(typeof(DbContextLocal));
        }
    }
}