using System;
using Class.GameSystem.Equip;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Item
{
    [DeclareHorizontalGroup("buttons")]
    [Serializable]
    public class Item<T, TObject> : IItem<TObject>
    {
        [SerializeField] protected T itemType;
        [FormerlySerializedAs("itemName")] [SerializeField] protected string name;

        [SerializeField] [OnValueChanged(nameof(SetItemObjectNameAsKey))]
        protected TObject itemObject;

        [SerializeField] protected EquipLimitation equipLimitation;

        [Header("Status")] [SerializeField] protected bool isUnlocked;
        [SerializeField] protected bool isEquipped;

        [SerializeField] protected float price;
        [SerializeField] protected Sprite itemSprite;

        public T ItemType
        {
            get => itemType;
            set => itemType = value;
        }

        public TObject ItemObject
        {
            get => itemObject;
            set => itemObject = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public EquipLimitation EquipLimitation
        {
            get => equipLimitation;
            set => equipLimitation = value;
        }

        public void SetItemObjectNameAsKey()
        {
            name = itemObject.ToString();
        }

        public bool IsUnlocked
        {
            get => isUnlocked;
            set => isUnlocked = value;
        }

        public bool IsEquipped
        {
            get => isEquipped;
            set => isEquipped = value;
        }

        public float Price
        {
            get => price;
            set => price = value;
        }

        public Sprite ItemSprite
        {
            get => itemSprite;
            set => itemSprite = value;
        }
        
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
        
        [Group("buttons")][Button]
        public void SaveFull()
        {
            PlayerPrefs.SetString(name, ToJson());
        }

        [Group("buttons")][Button]
        public void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(name), this);
        }

        [Group("buttons")][Button]
        public void Reset()
        {
            isUnlocked = false;
            isEquipped = false;
            PlayerPrefs.SetString(name, "");
        }
    }
}