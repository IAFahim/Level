using Class.Interaction;
using UnityEngine;

namespace ObjectScriptable.Collection
{
    [CreateAssetMenu(fileName = "CollectAble", menuName = "GameSystem/Item/Collection/CollectAble", order = 0)]
    public class CollectAbleSo : UnityEngine.ScriptableObject
    {
        public CollectAble<GameObject> collectAble;
    }
}