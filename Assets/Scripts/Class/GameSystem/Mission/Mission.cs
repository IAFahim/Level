using Class.GameSystem.Objective;
using UnityEngine;

namespace Class.GameSystem.Mission
{
    public class Mission
    {
        public Objective<GameObject> MainObjective;
        public Objective<GameObject> OptionalObjective;
        public bool IsComplete => MainObjective.condition.CheckIf() && OptionalObjective.condition.CheckIf();
        
    }
}