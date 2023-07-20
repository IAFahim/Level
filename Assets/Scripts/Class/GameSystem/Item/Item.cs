using System;
using Class.GameSystem.Info;
using Class.GameSystem.Interaction;
using Class.GameSystem.Stats;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Item
{
    [DeclareHorizontalGroup("buttons")]
    [Serializable]
    public class Item<T, TObject>
    {
        [SerializeField] protected T itemType;
        [SerializeField] protected TObject gameObject;

        public UiInfo uiInfo;
        public UnlockRequirement<float> unlockRequirement;
        public Durability durability;
    }
}