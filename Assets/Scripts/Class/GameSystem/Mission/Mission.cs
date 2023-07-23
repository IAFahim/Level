using Class.GameSystem.Goal;
using UnityEngine;

namespace Class.GameSystem.Mission
{
    public class Mission
    {
        public Goal<GameObject> mainGoal;
        public Goal<GameObject> optionalGoal;
        public bool IsComplete => mainGoal.condition.CheckIf() && optionalGoal.condition.CheckIf();
        
    }
}