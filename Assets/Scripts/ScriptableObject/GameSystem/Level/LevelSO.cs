using Class.GameSystem.Goal;
using Class.GameSystem.Reward;
using UnityEngine;

namespace ScriptableObject.GameSystem.Level
{
    [CreateAssetMenu(fileName = "Level_", menuName = "GameSystem/Level", order = 0)]
    public class LevelSO : UnityEngine.ScriptableObject 
    {
        public Goal<UnityEngine.ScriptableObject, int> goal;
        public Reward<GameObject, int> reward;


    }
}