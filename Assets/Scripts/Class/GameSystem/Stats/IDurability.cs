namespace Class.GameSystem.Stats
{
    public interface IDurability
    {
        bool HasDurability { get; set; }
        int CurrentDurability { get; set; }
        int MaxDurability { get; set; }
    }
}