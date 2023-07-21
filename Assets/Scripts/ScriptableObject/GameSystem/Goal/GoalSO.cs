using System;
using Class.GameSystem.Goal;
using Class.GameSystem.Satisfiable;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Goal
{
    [CreateAssetMenu(fileName = "Goal", menuName = "GameSystem/Goal", order = 0)]
    public class GoalSO : UnityEngine.ScriptableObject
    {
        public Goal<GameObject, int> goal;
        public Satisfies satisfies;

        [Button]
        public void Log()
        {
            Debug.Log(goal.CheckIfCompletedInTime());
        }

        private void OnEnable()
        {
            satisfies.onSatisfied.AddListener(OnSatisfied);
        }

        private void OnSatisfied(Satisfies arg0)
        {
            Debug.Log("OnSatisfied " + arg0.Condition);
        }
    }
}