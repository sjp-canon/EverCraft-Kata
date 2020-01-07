// ---------------------------------------------------------------------------------------------
// <copyright file="AbilityScore.cs" company="Blizzards of the Coast">
// © 2019, Blizzards of the Coast. All rights reserved.
// Licensed under the MIT license. See LICENSE in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------

namespace EverCraft
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines a basic statistic for a character.
    /// </summary>
    public class AbilityScore
    {
        private uint _score;

        public AbilityScore(string name)
        {
            Name = Enum
                .GetValues(typeof(CharacterAbilityScores))
                .Cast<CharacterAbilityScores>()
                .Any(x => x.ToString().Equals(name))
                ? name
                : throw new Exception(nameof(name));
            Score = 10;
        }

        /// <summary>
        /// Gets the name of this ability score.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the current value of this ability score.
        /// </summary>
        public uint Score
        {
            get => _score;
            set
            {
                if (value > 0 && value <= 20)
                {
                    _score = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Score));
                }
            }
        }
    }
}
