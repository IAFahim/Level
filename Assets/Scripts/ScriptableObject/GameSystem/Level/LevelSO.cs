using Class.GameSystem.Currency;
using Class.GameSystem.Goal;
using Class.GameSystem.RewardCurrency;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObject.GameSystem.Level
{
    [CreateAssetMenu(fileName = "Level_", menuName = "GameSystem/Level", order = 0)]
    public class LevelSO : UnityEngine.ScriptableObject 
    {
        public Goal<UnityEngine.ScriptableObject> goal;


    }
}