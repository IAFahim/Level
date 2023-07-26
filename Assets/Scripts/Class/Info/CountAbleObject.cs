using System;
using TriInspector;

namespace Class.Info
{
    [Serializable]
    public class CountAbleObject : ICountAbleObject
    {
        [DisableInEditMode] public string key;
        public int count;

        public string Key => key;

        public virtual void SetAskKey()
        {
        }

        public CountAbleObject()
        {
        }

        public CountAbleObject(int count)
        {
            this.count = count;
        }

        public int Count
        {
            get => count;
            set => count = value;
        }
    }
}