using System;
using Class.Info;
using Class.Interaction;
using Class.Stats;
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