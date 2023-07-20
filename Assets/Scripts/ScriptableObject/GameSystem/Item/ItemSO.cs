using Class.GameSystem.Item;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Item
{
    [CreateAssetMenu(fileName = "Item", menuName = "GameSystem/Item/Item", order = 0)]
    public class ItemSO : UnityEngine.ScriptableObject
    {
        public Item<ItemClassEnum, GameObject> item;
    }
}