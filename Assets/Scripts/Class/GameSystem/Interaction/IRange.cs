namespace Class.GameSystem.Interaction
{
    public interface IRange<TComparable> where TComparable : struct, System.IComparable<TComparable>
    {
        TComparable Lower { get; set; }
        TComparable Upper { get; set; }
        void SetRange(TComparable lowerBound, TComparable upperBound);
    }
}