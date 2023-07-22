namespace Class.GameSystem.Satisfiable
{
    public enum ConditionCheckEnumType
    {
        InRange,        // Value is within a specific range.
        OutOfRange,     // Value is outside a specific range.
        Exact,          // Value is an exact match to a specific target value.
        LessThan,       // Value is less than a given threshold.
        GreaterThan,    // Value is greater than a given threshold.
        AtLeast,        // Value is equal to or greater than a given threshold.
        AtMost,         // Value is equal to or less than a given threshold.
        DifferentThan,  // Value is not the same as a specific target value.
        Custom         // Condition is satisfied by a custom function.
    }
}