namespace Class.Interaction
{
    public interface IInRange<TComparable> : IRange<TComparable> where TComparable : struct, System.IComparable<TComparable>
    {
        InRangeCompareType InRangeCompareType { get; set; }
        bool IsInRange(TComparable value);
    }
}