using System;
using Class.Info;
using Class.Stats;
using TriInspector;

namespace Class.Util.UI
{
    [Serializable]
    public class FishingRodUIModelBase : IKey
    {
        [DisableInEditMode] public string key;
        public Durability durability;
        public bool isEquipped;
        public bool isUnlocked;

        public string Key => key;
        
        public virtual void SetAskKey()
        {
            
        }
    }
}