namespace Class.Satisfiable
{
    public interface IVariableCondition<T>
    {
        ConditionCheckEnumType ConditionCheckEnumType { get; set; }
        T Target { get; set; }
        float CurrentValue { get; set; }
        float MinValue { get; set; }
        float MaxValue { get; set; }
        bool IsSatisfied { set; }
        bool CheckIf(bool invokeEvents = true);
        float GetSatisfactionLevel();
    }
}