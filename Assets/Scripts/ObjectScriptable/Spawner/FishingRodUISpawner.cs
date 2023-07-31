using System.Collections.Generic;
using BehaviourMono;
using Class.Util.UI;
using UnityEngine;

namespace ObjectScriptable.Spawner
{
    [CreateAssetMenu(fileName = "FishingRodUISpawner", menuName = "ScriptableObjects/Spawner/FishingRodUISpawner")]
    public class FishingRodUISpawner : ScriptableObject
    {
        public List<FishingRodData> list;
        public GameObject prefab;
        public RectTransform parent;

        public void Spawn()
        {
            foreach (var data in list)
            {
                var gameObject = Instantiate(prefab, parent);
                var model = gameObject.GetComponent<FishingRodUIModel>();
                model.Data = data;
            }
        }
    }
}