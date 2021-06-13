using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class Modifier : IModifier
    {
        public IProperty TargetProperty { get; set; }
        public decimal Value { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string Path { get; set; }
        IModifier IModifier.Modifier { get; set; }
    }
    class BinaryModifier : IBinaryModifier
    {
        public IProperty TargetProperty { get; set; }
        public IModifier Modifier { get; set; }
        public decimal Value { get; set; }
        public string Path { get; set; }
    }
    class Property : IProperty
    {
    }
}
