using Class.Objective;
using UnityEngine;
using UnityEngine.Serialization;

namespace ObjectScriptable.Level
{
    [CreateAssetMenu(fileName = "Level_", menuName = "GameSystem/Level", order = 0)]
    public class LevelSo : UnityEngine.ScriptableObject 
    {
        [FormerlySerializedAs("goal")] public Objective<UnityEngine.ScriptableObject> objective;


    }
}