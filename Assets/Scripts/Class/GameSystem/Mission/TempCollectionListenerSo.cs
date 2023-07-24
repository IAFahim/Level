using Class.GameSystem.Interaction;
using UnityEngine;

namespace Class.GameSystem.Mission
{
    [CreateAssetMenu(fileName = "LevelCollectionListenerSo", menuName = "GameSystem/Level/Listener", order = 0)]
    public class TempCollectionListenerSo: UnityEngine.ScriptableObject
    {
        public CollectionListener<GameObject> collectionListener;
    }
}