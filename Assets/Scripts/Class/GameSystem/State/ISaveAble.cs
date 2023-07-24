using TriInspector;
using UnityEngine;

namespace Class.GameSystem.State
{
    public interface ISaveAble : IResetAble
    {
        string ToJson();
        void SaveFull();
        void Load();
    }

    public abstract class SaveAble : ISaveAble
    {
        [Title("Debug")]
        [Button]
        public abstract void Reset();

        [Button]
        public abstract string ToJson();

        [Button]
        public abstract void SaveFull();

        [Button]
        public abstract void Load();
    }
}