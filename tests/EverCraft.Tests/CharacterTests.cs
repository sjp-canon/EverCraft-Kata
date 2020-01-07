// <copyright file="CharacterTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverCraft.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void CharacterName_CanGetName()
        {
            var character = new Character("Robert");

            var name = character.Name;

            Assert.AreEqual("Robert", name);
        }

        [TestMethod]
        public void CharacterName_CanSetName()
        {
            var character = new Character("Robert");
            character.Name = "William";

            var name = character.Name;

            Assert.AreEqual("William", name);
        }
    }
}
