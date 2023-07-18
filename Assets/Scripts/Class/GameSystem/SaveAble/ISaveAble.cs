namespace Class.GameSystem.SaveAble
{
    public interface ISaveAble
    {
        string ToJson();
        void SaveFull();
        void Load();
        void Reset();
    }
}