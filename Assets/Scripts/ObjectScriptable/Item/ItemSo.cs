using Class.GameSystem.Item;
using UnityEngine;

namespace ObjectScriptable.Item
{
    [CreateAssetMenu(fileName = "Item", menuName = "GameSystem/Item/Item", order = 0)]
    public class ItemSo : UnityEngine.ScriptableObject
    {
        public Item<ItemClassEnum, GameObject> item;
    }
}