using UnityEngine.Events;

namespace Class.GameSystem.Stats
{
    public interface IDurability
    {
        public float CurrentDurability { get; set; }
        public float MaxDurability { get; set; }
    }
}