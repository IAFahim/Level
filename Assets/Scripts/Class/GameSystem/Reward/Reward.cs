using System;
using TriInspector;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("vars")]
    [Serializable]
    public class Reward<T, V> where V : struct
    {
        [Group("vars")] public T type;
        [Group("vars")] public V value;

        public override string ToString()
        {
            return $"{{\"Type\":\"{type}\", \"Value\":\"{value}\"}}";
        }
    }
}