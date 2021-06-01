using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    interface IMasteryLevelDefinition
    {
        /// <summary>
        /// Where this comes under in the skill tree
        /// </summary>
        string HeroMasteryDefinition { get; set; }
        /// <summary>
        /// The skill level
        /// </summary>
        int Levels { get; set; }
    }
}
