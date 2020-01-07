// <copyright file="AbilityScoreTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverCraft.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AbilityScoreTests
    {
        private AbilityScore _score;

        [TestInitialize]
        public void TestInitialize()
        {
            _score = new AbilityScore("Strength");
        }

        [TestMethod]
        public void AbilityScore_HasDefaultValue10()
        {
            var result = _score.Score;

            Assert.AreEqual(10u, result);
        }

        [DataTestMethod]
        [DataRow("This name sucks", "name", DisplayName = "AbilityScore_InvalidName_ShouldThrowException")]
        [DataRow("Strength", null, DisplayName = "AbilityScore_Strength_ShouldSetName")]
        [DataRow("Dexterity", null, DisplayName = "AbilityScore_Dexterity_ShouldSetName0")]
        [DataRow("Constitution", null, DisplayName = "AbilityScore_Constitution_ShouldSetName")]
        [DataRow("Intelligence", null, DisplayName = "AbilityScore_Intelligence_ShouldSetName")]
        [DataRow("Wisdom", null, DisplayName = "AbilityScore_Wisdom_ShouldSetName")]
        [DataRow("Charisma", null, DisplayName = "AbilityScore_Charisma_ShouldSetName")]
        public void AbilityScore_NameSet_WorksAsExpected(string name, string propertyName)
        {
            try
            {
                _score = new AbilityScore(name);
                Assert.AreEqual(name, _score.Name);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(propertyName, ex.Message);
            }
        }

        [DataTestMethod]
        [DataRow(1u, null, DisplayName = "AbilityScore_ScoreIsSetCorrectly_ToLowestValue")]
        [DataRow(20u, null, DisplayName = "AbilityScore_ScoreIsSetCorrectly_ToHighestValue")]
        [DataRow(0u, "Specified argument was out of the range of valid values. (Parameter 'Score')", DisplayName = "AbilityScore_ScoreZero_ShouldThrowException")]
        [DataRow(21u, "Specified argument was out of the range of valid values. (Parameter 'Score')", DisplayName = "AbilityScore_Score21_ShouldThrowException")]
        public void AbilityScoreValue_IsSetCorrectly(uint newScore, string errorMessage)
        {
            try
            {
                _score.Score = newScore;
                Assert.AreEqual(newScore, _score.Score);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(errorMessage, ex.Message);
            }
        }
    }
}
