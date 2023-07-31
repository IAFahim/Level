using Class.Interaction;

namespace Class.Stats
{
    public interface IDurability: ICheckAble
    {
        public float CurrentDurability { get; set; }
        public float MaxDurability { get; set; }
    }
}