using System.Collections.Generic;
using Class.GameSystem.Item;
using Class.GameSystem.SaveAble;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Item
{
    [CreateAssetMenu(fileName = "SelectedItem", menuName = "GameSystem/Item/SelectedItem", order = 0)]
    public class SelectedItemSO : UnityEngine.ScriptableObject, ISaveAble
    {
        public int index;
        public Item<ItemClassEnum, GameObject> selectedItem;
        public List<Item<ItemClassEnum, GameObject>> itemList;
        
        
        [Title("Debug")]
        
        [Button]
        void SetByIndex(int indexNumber)
        {
            selectedItem = itemList[this.index = indexNumber];
        }

        [Button]
        public void SetByString(string itemName)
        {
            for (var i = 0; i < itemList.Count; i++)
            {
                string str = itemList[i].textInfo.Name.Substring(0, itemName.Length);
                if (str == itemName)
                {
                    selectedItem = itemList[i];
                    index = i;
                    break;
                }
            }
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void SaveFull()
        {
            PlayerPrefs.SetString(name, ToJson());
        }

        public void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(name), this);
        }

        public void Reset()
        {
            PlayerPrefs.SetString(name, "");
            index = 0;
            selectedItem = itemList[index];
        }
    }
}