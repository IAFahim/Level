namespace Class.GameSystem.Satisfiable
{
    public interface IVariableCondition<T>
    {
        ConditionCheckEnumType ConditionCheckEnumType { get; set; }
        T TargetType { get; set; }
        float CurrentValue { get; set; }
        float MinValue { get; set; }
        float MaxValue { get; set; }
        bool IsSatisfied { set; }
        bool CheckIf(bool invokeEvents = true);
        float GetSatisfactionLevel();
    }
}