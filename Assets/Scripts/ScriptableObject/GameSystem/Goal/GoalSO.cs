using Class.GameSystem.Goal;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Goal
{
    [CreateAssetMenu(fileName = "Goal", menuName = "GameSystem/Goal", order = 0)]
    public class GoalSO : UnityEngine.ScriptableObject
    {
        public Goal<GameObject, int> goal;
        
        [Button]
        public void Log()
        {
            Debug.Log(goal.CheckIfCompletedInTime());
        }
        
    }
}