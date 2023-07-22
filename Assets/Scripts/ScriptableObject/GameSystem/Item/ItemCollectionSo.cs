using System;
using System.Collections.Generic;
using Class.GameSystem.Item;
using Class.GameSystem.State;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;


namespace ScriptableObject.GameSystem.Item
{
    [CreateAssetMenu(fileName = "Collection", menuName = "GameSystem/Item/ItemCollection", order = 0)]
    [DeclareHorizontalGroup("SaveButton")]
    public class ItemCollectionSo : UnityEngine.ScriptableObject, ISaveAble
    {
        public List<Item<ItemClassEnum, GameObject>> itemList;

        [OnValueChanged(nameof(GetAndSetByCurrentIndex))] [Range(0, 1)] [Title("Selected Item")]
        public int index;

        [SerializeField] protected Item<ItemClassEnum, GameObject> selectedItem;

        public Item<ItemClassEnum, GameObject> SelectedItem
        {
            get => selectedItem;
            set => onItemChanged?.Invoke(selectedItem = value);
        }

        private void GetAndSetByCurrentIndex()
        {
            if (itemList.Count > 0)
            {
                SelectedItem = itemList[index];
            }
        }

        [Title("Debug")]
        [Button]
        public void SetByIndex(int indexNumber)
        {
            SelectedItem = itemList[index = indexNumber];
        }

        private void OnEnable()
        {
            if (itemList.Count > 0)
            {
                SelectedItem = itemList[index];
            }
        }

        [Title("Events")] public UnityEvent<Item<ItemClassEnum, GameObject>> onItemChanged;

        public UnityEvent<float> onDurabilityChanged;
        public UnityEvent<float> onMaxDurabilityChanged;
        public UnityEvent<float> onDurabilityMax;
        public UnityEvent<float> onNoDurability;


        public float CurrentDurability
        {
            get => SelectedItem.durability.CurrentDurability;
            set
            {
                if (value <= 0) onNoDurability?.Invoke(value);
                if (value >= MaxDurability) onDurabilityMax?.Invoke(value);
                if (Math.Abs(CurrentDurability - value) > 0.00000005) onDurabilityChanged?.Invoke(value);
                SelectedItem.durability.CurrentDurability = value;
            }
        }

        public float MaxDurability
        {
            get => SelectedItem.durability.MaxDurability;
            set
            {
                if (Math.Abs(MaxDurability - value) > 0.00000005) onMaxDurabilityChanged?.Invoke(value);
                SelectedItem.durability.MaxDurability = value;
            }
        }


        [Group("SaveButton")]
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        [Button]
        [Group("SaveButton")]
        public void SaveFull()
        {
            PlayerPrefs.SetString(name, ToJson());
        }

        [Button]
        [Group("SaveButton")]
        public void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(name), this);
        }

        [Button]
        [Group("SaveButton")]
        public void Reset()
        {
            PlayerPrefs.SetString(name, "");
            index = 0;
            if (itemList.Count > 0)
            {
                SelectedItem = itemList[index];
            }
            else
            {
                selectedItem = null;
            }
        }
    }
}