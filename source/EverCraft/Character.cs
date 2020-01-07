// ---------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="Blizzards of the Coast">
// © 2019, Blizzards of the Coast. All rights reserved.
// Licensed under the MIT license. See LICENSE in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------

namespace EverCraft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a character in the world.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        public Character()
        {
            Name = string.Empty;
            Alignment = Alignment.Neutral;
            ArmorClass = 10;
            HealthPoints = 5;
            AbilityScores = Enum
                .GetValues(typeof(CharacterAbilityScores))
                .Cast<CharacterAbilityScores>()
                .Select(s => new AbilityScore(s.ToString()))
                .ToList();
        }

        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the alignment of the character.
        /// </summary>
        public Alignment Alignment { get; set; }

        /// <summary>
        /// Gets the armor class value of the character.
        /// </summary>
        public uint ArmorClass { get; }

        /// <summary>
        /// Gets the current number of hit points of the character.
        /// </summary>
        public int HealthPoints { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the character is currently dead.
        /// </summary>
        public bool IsDead => HealthPoints <= 0;

        public IList<AbilityScore> AbilityScores { get; }

        /// <summary>
        /// Determines the result of an attack roll on an enemy.
        /// </summary>
        public bool DetermineAttackResult(int attackRoll, uint opponentArmorClass) => attackRoll >= opponentArmorClass;

        /// <summary>
        /// Calculates the character's outgoing damage on a successful attack.
        /// </summary>
        public int CalculateDamageOutput(bool isCritical = false) => isCritical ? 2 : 1;

        /// <summary>
        /// Sets the character's health points when successfully attacked.
        /// </summary>
        public void TakeDamageInput(int incomingDamage) => SetCurrentHealth(HealthPoints - incomingDamage);

        /// <summary>
        /// Sets the character's current HealthPoints.
        /// </summary>
        /// <param name="health"></param>
        public void SetCurrentHealth(int health) => HealthPoints = health;
    }
}
