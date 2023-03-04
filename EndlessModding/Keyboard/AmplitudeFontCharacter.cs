using System;

namespace EndlessModding.Keyboard
{
    public class AmplitudeFontCharacter
    {
        public int Key
        {
            get;
        }
        public string Character
        {
            get => $"{Convert.ToChar(Key)}";
        }

        public AmplitudeFontCharacter(int key)
        {
            Key = key;
        }
    }
}