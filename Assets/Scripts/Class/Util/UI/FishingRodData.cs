using System;
using Class.Info;
using Class.Interaction;
using Class.Stats;
using TriInspector;

namespace Class.Util.UI
{
    [Serializable]
    public class FishingRodData : IKey
    {
        [DisableInEditMode] public string key;
        public Equipped equippedState;
        public Locked<float> priceLocked;

        public string Key => key;

        public virtual void SetAskKey()
        {
        }
    }
}