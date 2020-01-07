// <copyright file="CharacterTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverCraft.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CharacterTests
    {
        private Character _character;

        [TestInitialize]
        public void TestInitialize()
        {
            _character = new Character();
        }

        [TestMethod]
        public void CharacterName_CanGetName()
        {
            var name = _character.Name;
            var expected = string.Empty;

            Assert.AreEqual(expected, name);
        }

        [TestMethod]
        public void CharacterName_CanSetName()
        {
            _character.Name = "William";

            var name = _character.Name;
            var expected = "William";

            Assert.AreEqual(expected, name);
        }

        [TestMethod]
        public void CharacterAlignment_CanGetAlignment()
        {
            var alignment = _character.Alignment;
            var expected = Alignment.Neutral;

            Assert.AreEqual(expected, alignment);
        }

        [DataTestMethod]
        [DataRow(Alignment.Good, DisplayName = "CharacterAlignment_GoodAlignment_CanSet")]
        [DataRow(Alignment.Evil, DisplayName = "CharacterAlignment_EvilAlignment_CanSet")]
        [DataRow(Alignment.Neutral, DisplayName = "CharacterAlignment_NeutralAlignment_CanSet")]
        public void CharacterAlignment_CanSetAlignment(Alignment alignment)
        {
            _character.Alignment = alignment;

            var characterAlignment = _character.Alignment;

            Assert.AreEqual(alignment, characterAlignment);
        }

        [TestMethod]
        public void CharacterArmorClass_CanGetDefaultArmorClassValue()
        {
            var expected = 10u;

            var armorClass = _character.ArmorClass;

            Assert.AreEqual(expected, armorClass);
        }

        [TestMethod]
        public void CharacterHealth_CanGetDefaultHealthValue()
        {
            var expected = 5;

            var health = _character.HealthPoints;

            Assert.AreEqual(expected, health);
        }

        [DataTestMethod]
        [DataRow(20, 10u, true, DisplayName = "CharacterDetermineAttackResult_AttackRollBeatsOpponentArmorClass_ShouldReturnTrue")]
        [DataRow(15, 15u, true, DisplayName = "CharacterDetermineAttackResult_AttackRollMeetsOpponentArmorClass_ShouldReturnTrue")]
        [DataRow(10, 20u, false, DisplayName = "CharacterDetermineAttackResult_AttackRollDoesntMeetOpponentArmorClass_ShouldReturnFalse")]
        public void CharacterDetermineAttackResult_ShouldReturnCorrectResult(int attackRoll, uint opponentArmorClass, bool expectedResult)
        {
            var result = _character.DetermineAttackResult(attackRoll, opponentArmorClass);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(false, 1, DisplayName = "CharacterCalculateDamage_HitIsNotCritical_ShouldReturnNormalDamage")]
        [DataRow(true, 2, DisplayName = "CharacterCalculateDamage_HitIsCritical_ShouldReturnDoubleDamage")]
        public void CharacterCalculateDamage_ShouldReturnExpectedDamage(bool isCriticalHit, int expectedDamage)
        {
            var result = _character.CalculateDamageOutput(isCriticalHit);

            Assert.AreEqual(expectedDamage, result);
        }

        [DataTestMethod]
        [DataRow(0, true, DisplayName = "CharacterIsDead_HealthIsZero_ShouldReturnTrue")]
        [DataRow(-1, true, DisplayName ="CharacterIsDead_HealthIsNegative_ShouldReturnTrue")]
        [DataRow(1, false, DisplayName = "CharacterIsDead_HealthIsPostive_ShouldReturnFalse")]
        public void CharacterIsDead_ShouldBeExpectedValue(int health, bool expectedDeathValue)
        {
            _character.SetCurrentHealth(health);

            var result = _character.IsDead;

            Assert.AreEqual(expectedDeathValue, result);
        }

        [TestMethod]
        public void CharacterTakeDamageInput_CharacterHasHealth5_HealthPointsShouldReturnExpectedValue()
        {
            var startingHealth = 5;
            var incomingDamage = 3;

            _character.SetCurrentHealth(startingHealth);
            _character.TakeDamageInput(incomingDamage);

            var result = _character.HealthPoints;

            Assert.AreEqual(startingHealth - incomingDamage, result);
        }

        [DataTestMethod]
        [DataRow("Strength", 10u, DisplayName = "CharacterAbilityScores_Strength_DefaultValueIs10")]
        [DataRow("Dexterity", 10u, DisplayName = "CharacterAbilityScores_Dexterity_DefaultValueIs10")]
        [DataRow("Constitution", 10u, DisplayName = "CharacterAbilityScores_Constitution_DefaultValueIs10")]
        [DataRow("Intelligence", 10u, DisplayName = "CharacterAbilityScores_Intelligence_DefaultValueIs10")]
        [DataRow("Wisdom", 10u, DisplayName = "CharacterAbilityScores_Wisdom_DefaultValueIs10")]
        [DataRow("Charisma", 10u, DisplayName = "CharacterAbilityScores_Charisma_DefaultValueIs10")]
        public void CharacterAbilityScores_HasDefaultValuesOnCharacterCreation(string abilityScoreName, uint expectedValue)
        {
            var abilityScores = _character.AbilityScores;

            var score = abilityScores.SingleOrDefault(s => s.Name.Equals(abilityScoreName));

            Assert.IsNotNull(score);
            Assert.AreEqual(expectedValue, score.Score);
        }
    }
}
