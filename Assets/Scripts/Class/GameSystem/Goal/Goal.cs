using System;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Goal
{
    [DeclareHorizontalGroup("vars")]
    [DeclareHorizontalGroup("time")]
    [Serializable]
    public class Goal<TO, TComparable> : IGoal<TO, TComparable> where TComparable : struct, IComparable<TComparable>
        where TO : UnityEngine.Object
    {
        private const float Epsilon = 1e-5f; // Choose an appropriate epsilon value for comparisons

        public TO type;
        public GoalType goalCompareType;
        
        [Header("Value Range")]
        public TComparable current;
        [Group("vars")] public TComparable rangeMin;
        [Group("vars")] public TComparable rangeMax;
        
        [Header("Time Range")]
        public float time;
        [Group("time")] public float startTime;
        [Group("time")] public float endTime;
        public Func< IGoal<TO, TComparable>, bool> CustomCheckFunction  { get; set; }

        public TO Type
        {
            get => type;
            set => type = value;
        }

        public GoalType GoalCompareType
        {
            get => goalCompareType;
            set => goalCompareType = value;
        }

        public TComparable Current
        {
            get => current;
            set => current = value;
        }

        public TComparable RequiredMin
        {
            get => rangeMin;
            set => rangeMin = value;
        }

        public TComparable RequiredMax
        {
            get => rangeMax;
            set => rangeMax = value;
        }

        public Goal(TO type, TComparable requiredMin)
        {
            Type = type;
            RequiredMin = requiredMin;
            RequiredMax = default;
        }

        public Goal(TO type, TComparable requiredMin, TComparable requiredMax)
        {
            Type = type;
            RequiredMin = requiredMin;
            RequiredMax = requiredMax;
        }

        public Goal(TO type, TComparable requiredMin, TComparable requiredMax, GoalType goalCompareType)
        {
            Type = type;
            RequiredMin = requiredMin;
            RequiredMax = requiredMax;
            GoalCompareType = goalCompareType;
        }

        public Goal(TO type, TComparable requiredMin, TComparable requiredMax, GoalType goalCompareType,
            Func< IGoal<TO, TComparable>, bool> checkFunction )
        {
            Type = type;
            RequiredMin = requiredMin;
            RequiredMax = requiredMax;
            GoalCompareType = goalCompareType;
            CustomCheckFunction = checkFunction;
        }

        public void SetCurrent(TComparable value)
        {
            Current = value;
        }

        public void SetRange(TComparable lower, TComparable upper)
        {
            RequiredMin = lower;
            RequiredMax = upper;
        }

        public bool CheckIfComplete()
        {
            if (GoalCompareType == GoalType.TargetExact)
                // Handle target exact logic
                return Current.CompareTo(RequiredMin) == 0 ||
                       Math.Abs(Current.CompareTo(RequiredMin) - RequiredMax.CompareTo(Current)) < Epsilon;
            if (GoalCompareType == GoalType.TargetInRange)
                // Handle target in range logic
                // You can customize this based on your game's logic for range-based goals
                return Current.CompareTo(RequiredMin) >= 0 - Epsilon &&
                       Current.CompareTo(RequiredMax) <= 0 + Epsilon;
            if (GoalCompareType == GoalType.Custom)
                // Handle custom logic (if applicable)
                // You can set a custom check function for this GoalType
                // Placeholder; modify based on your custom logic
                return CustomCheckFunction(this);
            return false;
        }

        public bool CheckIfCompletedInTime()
        {
            bool isCompleted = CheckIfComplete();
            if (isCompleted && time >= startTime - Epsilon && time <= endTime + Epsilon)
            {
                return true;
            }

            return false;
        }

        public static implicit operator bool(Goal<TO, TComparable> goal)
        {
            return goal.CheckIfComplete();
        }

        public override string ToString()
        {
            string requiredMaxStr = RequiredMax.Equals(default(TComparable)) ? "N/A" : RequiredMax.ToString();
            return $"{Type} have {Current} with required {RequiredMin} to {requiredMaxStr}";
        }
    }
}