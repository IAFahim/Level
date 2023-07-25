using Class.GameSystem.Info;
using Class.GameSystem.Interaction;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Mission
{
    [CreateAssetMenu(fileName = "LevelCollectionListenerSo", menuName = "GameSystem/Level/Listener", order = 0)]
    public class CollectionListenerSo: UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("collectionListener")] public Collector<GameObject, CountAbleObject> collector;
    }
}