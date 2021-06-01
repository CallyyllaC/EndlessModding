using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /// <summary>
    /// WIP
    /// </summary>
    interface IModifier
    {
        IProperty TargetProperty { get; set; }
        IModifier Modifier { get; set; }
        Decimal Value { get; set; }
        string Left { get; set; }
        string Right { get; set; }
        string Path { get; set; }
    }
    /// <summary>
    /// WIP
    /// </summary>
    interface IBinaryModifier
    {
        IProperty TargetProperty { get; set; }
        IModifier Modifier { get; set; }
        Decimal Value { get; set; }
        string Path { get; set; }
    }
    interface IProperty
    {
    }
}
