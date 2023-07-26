namespace Class.Mission
{
    public interface IMission
    {
        
        bool IsComplete { get; }
        void Check();
    }
}