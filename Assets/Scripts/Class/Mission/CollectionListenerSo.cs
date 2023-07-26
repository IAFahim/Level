using Class.Info;
using Class.Interaction;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.Mission
{
    [CreateAssetMenu(fileName = "LevelCollectionListenerSo", menuName = "GameSystem/Level/Listener", order = 0)]
    public class CollectionListenerSo: UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("collectionListener")] public Collector<GameObject, CountAbleObject> collector;
    }
}