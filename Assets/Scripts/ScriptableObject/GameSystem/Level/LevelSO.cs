using Class.GameSystem.Currency;
using Class.GameSystem.Objective;
using Class.GameSystem.RewardCurrency;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObject.GameSystem.Level
{
    [CreateAssetMenu(fileName = "Level_", menuName = "GameSystem/Level", order = 0)]
    public class LevelSO : UnityEngine.ScriptableObject 
    {
        [FormerlySerializedAs("goal")] public Objective<UnityEngine.ScriptableObject> objective;


    }
}