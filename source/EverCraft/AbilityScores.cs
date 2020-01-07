// ---------------------------------------------------------------------------------------------
// <copyright file="AbilityScores.cs" company="Blizzards of the Coast">
// © 2019, Blizzards of the Coast. All rights reserved.
// Licensed under the MIT license. See LICENSE in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------

namespace EverCraft
{
    using System.ComponentModel.DataAnnotations;

    public enum CharacterAbilityScores
    {
        /// <summary>
        /// The strength stat.
        /// </summary>
        [Display(Name = "Strength")]
        Strength,

        /// <summary>
        /// The dexterity stat.
        /// </summary>
        [Display(Name = "Dexterity")]
        Dexterity,

        /// <summary>
        /// The constitution stat.
        /// </summary>
        [Display(Name = "Constitution")]
        Constitution,

        /// <summary>
        /// The intelligence stat.
        /// </summary>
        [Display(Name = "Intelligence")]
        Intelligence,

        /// <summary>
        /// The wisdom stat.
        /// </summary>
        [Display(Name = "Wisdom")]
        Wisdom,

        /// <summary>
        /// The charisma stat.
        /// </summary>
        [Display(Name = "Charisma")]
        Charisma,
    }
}
