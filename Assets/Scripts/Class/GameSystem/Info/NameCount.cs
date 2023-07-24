using System;

namespace Class.GameSystem.Info
{
    [Serializable]
    public class NameCount
    {
        
        public string name;
        public float count;

        public NameCount(string name, float count)
        {
            this.name = name;
            this.count = count;
        }
    }
}