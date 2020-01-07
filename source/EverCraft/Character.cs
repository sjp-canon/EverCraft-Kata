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
    using System.Text;

    /// <summary>
    /// Defines a character in the world.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        public Character(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the character.
        /// </summary>
        public string Name { get; }
    }
}
