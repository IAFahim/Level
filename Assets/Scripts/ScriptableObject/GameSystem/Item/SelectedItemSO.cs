using System.Collections.Generic;
using Class.GameSystem.Item;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Item
{
    [CreateAssetMenu(fileName = "SelectedItem", menuName = "GameSystem/Item/SelectedItem", order = 0)]
    public class SelectedItemSO : UnityEngine.ScriptableObject
    {
        public List<ItemSO> itemList;
        public ItemSO selectedItem;
        public int index;
        
        [Button]
        void SetByIndex(int index)
        {
            this.index = index;
            selectedItem = itemList[index];
        }

        [Button]
        public void SetByString(string itemName)
        {
            for (var i = 0; i < itemList.Count; i++)
            {
                string str= itemList[i].item.Name.Substring(0, itemName.Length);
                Debug.Log(str);
                
                Debug.Log(itemName);

                if (str == itemName)
                {
                    selectedItem = itemList[i];
                    index = i;
                    break;
                }
            }
        }
    }
}