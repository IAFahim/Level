using Class.GameSystem.Interaction;
using UnityEngine;

namespace ScriptableObject.GameSystem.Collection
{
    [CreateAssetMenu(fileName = "CollectAble", menuName = "GameSystem/Item/Collection/CollectAble", order = 0)]
    public class CollectAbleSo : UnityEngine.ScriptableObject
    {
        public CollectAble<GameObject> collectAble;
    }
}