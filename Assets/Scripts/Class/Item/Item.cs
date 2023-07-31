using System;
using Class.Info;
using Class.Interaction;
using Class.Stats;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Item
{
    [DeclareHorizontalGroup("buttons")]
    [Serializable]
    public class Item<T, TObject>
    {
        [SerializeField] protected T itemType;
        [SerializeField] protected TObject gameObject;

        public UiInfo uiInfo;
        [FormerlySerializedAs("unlockRequirement")] public Locked<float> locked;
        public Durability durability;
    }
}