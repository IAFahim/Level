using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Class.GameSystem.Satisfiable
{
    [Serializable]
    public class Satisfies
    {
        [SerializeField][OnValueChanged(nameof(Check))] private Condition condition;
        [SerializeField][OnValueChanged(nameof(Check))] private float currentValue;
        [SerializeField][OnValueChanged(nameof(Check))] private float minValue;
        [SerializeField][OnValueChanged(nameof(Check))] private float maxValue;
        [SerializeField][OnValueChanged(nameof(Check))] private bool isSatisfied;

        public UnityEvent<Satisfies> onSatisfied;
        public UnityEvent<Satisfies> onUnSatisfied;
        public UnityEvent<Satisfies> onValueChanged;
        public UnityEvent<Satisfies> onConditionTypeChanged;

        public Func<float, float, float, bool> customCheckFunction;


        public Satisfies(Condition condition, float currentValue, float minValue, float maxValue, Func<float, float, float, bool> customCheckFunction = null)
        {
            onSatisfied = new UnityEvent<Satisfies>();
            onValueChanged = new UnityEvent<Satisfies>();
            onConditionTypeChanged = new UnityEvent<Satisfies>();

            this.condition = condition;
            this.currentValue = currentValue;
            this.maxValue = minValue;
            this.maxValue = maxValue;
            this.customCheckFunction = customCheckFunction;
        }
        
        public void Check()
        {
            CheckIf();
        }

        public Condition Condition
        {
            get => condition;
            set
            {
                condition = value;
                onConditionTypeChanged?.Invoke(this);
            }
        }

        public float CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                onValueChanged?.Invoke(this);
            }
        }

        public float MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                onValueChanged?.Invoke(this);
            }
        }

        public float MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                onValueChanged?.Invoke(this);
            }
        }

        public bool IsSatisfied
        {
            set
            {
                isSatisfied = value;
                if (isSatisfied)
                {
                    onSatisfied?.Invoke(this);
                }else
                {
                    onUnSatisfied?.Invoke(this);
                }
            }
        }


        public bool CheckIf(bool invokeEvents = true)
        {
            return CheckIf(Condition, invokeEvents);
        }


        private bool CheckIf(Condition tempCondition, bool invokeEvents = true)
        {
            bool satisfied;
            switch (tempCondition)
            {
                case Condition.InRange:
                    satisfied = CurrentValue >= MinValue && CurrentValue <= MaxValue;
                    break;
                case Condition.OutOfRange:
                    satisfied = CurrentValue < MinValue || CurrentValue > MaxValue;
                    break;
                case Condition.Exact:
                    satisfied = Math.Abs(CurrentValue - MinValue) < 0.0001f;
                    break;
                case Condition.LessThan:
                    satisfied = CurrentValue < MinValue;
                    break;
                case Condition.GreaterThan:
                    satisfied = CurrentValue > MaxValue;
                    break;
                case Condition.AtLeast:
                    satisfied = CurrentValue >= MinValue;
                    break;
                case Condition.AtMost:
                    satisfied = CurrentValue <= MaxValue;
                    break;
                case Condition.DifferentThan:
                    satisfied = Math.Abs(CurrentValue - MinValue) >= 0.0001f;
                    break;
                case Condition.Custom:
                    satisfied = customCheckFunction?.Invoke(CurrentValue, MinValue, MaxValue) ?? false;
                    break;
                default:
                    throw new NotImplementedException("Condition not implemented.");
            }

            if (isSatisfied != satisfied && invokeEvents)
            {
                IsSatisfied = satisfied;
            }
            else
            {
                isSatisfied = satisfied;
            }

            return satisfied;
        }

        public float GetSatisfactionLevel()
        {
            if (CheckIf(Condition.InRange, false))
            {
                float range = maxValue - minValue;
                float distanceFromMin = currentValue - minValue;
                return distanceFromMin / range;
            }

            if (CheckIf(Condition.LessThan, false))
            {
                return (currentValue - minValue) / minValue;
            }

            if (CheckIf(Condition.GreaterThan, false))
            {
                return (currentValue - maxValue) / maxValue;
            }

            return 0.0f;
        }

        public override string ToString()
        {
            return
                $"Condition: {condition}, CurrentValue: {currentValue}, MinValue: {minValue}, MaxValue: {maxValue}, IsSatisfied: {isSatisfied}";
        }
    }
}