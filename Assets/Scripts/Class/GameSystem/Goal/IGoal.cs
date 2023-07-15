using System;
using Object = UnityEngine.Object;

namespace Class.GameSystem.Goal
{
    public interface IGoal<TO, TComparable> where TO : Object where TComparable : struct, IComparable<TComparable>
    {
        TO Type { get; set; }
        
        GoalType GoalCompareType { get; set; }
        
        TComparable Current { get; set; }
        TComparable RequiredMin { get; set; }
        TComparable RequiredMax { get; set; }
        Func< TComparable, TComparable, TComparable, bool> CustomCheckFunction { get; set; }
        void SetCurrent(TComparable value);
        void SetRange(TComparable lower, TComparable upper);
        bool CheckIfComplete();
    }
}