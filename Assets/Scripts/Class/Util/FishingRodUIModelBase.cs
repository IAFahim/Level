using System;
using Class.GameSystem.Info;
using Class.GameSystem.Stats;
using TriInspector;

namespace Class.Util
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