namespace Class.GameSystem.Satisfiable
{
    public interface ISatisfiable
    {
        Condition Condition { get; set; }
        float CurrentValue { get; set; }
        float MinValue { get; set; }
        float MaxValue { get; set; }
        bool IsSatisfied { set; }
        bool SatisfiesCondition(Condition condition);
        float SatisfactionLevel();
    }
}