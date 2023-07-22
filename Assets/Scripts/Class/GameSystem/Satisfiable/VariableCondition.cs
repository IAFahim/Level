using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Class.GameSystem.Satisfiable
{
    [Serializable]
    public class VariableCondition<T> : IVariableCondition<T>
    {
        [SerializeField] [OnValueChanged(nameof(Check))]
        private ConditionCheckEnumType conditionCheckEnumType;

        [SerializeField] [OnValueChanged(nameof(Check))]
        T targetType;

        [SerializeField] [OnValueChanged(nameof(Check))]
        private float currentValue;

        [SerializeField] [OnValueChanged(nameof(Check))]
        private float minValue;

        [SerializeField] [OnValueChanged(nameof(Check))]
        private float maxValue;

        [SerializeField] [OnValueChanged(nameof(Check))]
        private bool isSatisfied;

        public UnityEvent<VariableCondition<T>> onSatisfied;
        public UnityEvent<VariableCondition<T>> onUnSatisfied;
        public UnityEvent<VariableCondition<T>> onTargetChanged;
        public UnityEvent<VariableCondition<T>> onValueChanged;
        public UnityEvent<VariableCondition<T>> onConditionTypeChanged;

        public Func<float, float, float, bool> customCheckFunction;


        public VariableCondition(ConditionCheckEnumType conditionCheckEnumType, float currentValue, float minValue,
            float maxValue, Func<float, float, float, bool> customCheckFunction = null)
        {
            onSatisfied = new UnityEvent<VariableCondition<T>>();
            onUnSatisfied = new UnityEvent<VariableCondition<T>>();
            onTargetChanged = new UnityEvent<VariableCondition<T>>();
            onValueChanged = new UnityEvent<VariableCondition<T>>();
            onConditionTypeChanged = new UnityEvent<VariableCondition<T>>();

            this.conditionCheckEnumType = conditionCheckEnumType;
            this.currentValue = currentValue;
            this.maxValue = minValue;
            this.maxValue = maxValue;
            this.customCheckFunction = customCheckFunction;
        }

        public void Check()
        {
            CheckIf();
        }

        public ConditionCheckEnumType ConditionCheckEnumType
        {
            get => conditionCheckEnumType;
            set
            {
                conditionCheckEnumType = value;
                onConditionTypeChanged?.Invoke(this);
            }
        }

        public T TargetType
        {
            get => targetType;
            set
            {
                targetType = value;
                onValueChanged?.Invoke(this);
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
                }
                else
                {
                    onUnSatisfied?.Invoke(this);
                }
            }
        }


        public bool CheckIf(bool invokeEvents = true)
        {
            return CheckIf(ConditionCheckEnumType, invokeEvents);
        }


        private bool CheckIf(ConditionCheckEnumType tempConditionCheckEnumType, bool invokeEvents = true)
        {
            bool satisfied;
            switch (tempConditionCheckEnumType)
            {
                case ConditionCheckEnumType.InRange:
                    satisfied = CurrentValue >= MinValue && CurrentValue <= MaxValue;
                    break;
                case ConditionCheckEnumType.OutOfRange:
                    satisfied = CurrentValue < MinValue || CurrentValue > MaxValue;
                    break;
                case ConditionCheckEnumType.Exact:
                    satisfied = Math.Abs(CurrentValue - MinValue) < 0.0001f;
                    break;
                case ConditionCheckEnumType.LessThan:
                    satisfied = CurrentValue < MinValue;
                    break;
                case ConditionCheckEnumType.GreaterThan:
                    satisfied = CurrentValue > MaxValue;
                    break;
                case ConditionCheckEnumType.AtLeast:
                    satisfied = CurrentValue >= MinValue;
                    break;
                case ConditionCheckEnumType.AtMost:
                    satisfied = CurrentValue <= MaxValue;
                    break;
                case ConditionCheckEnumType.DifferentThan:
                    satisfied = Math.Abs(CurrentValue - MinValue) >= 0.0001f;
                    break;
                case ConditionCheckEnumType.Custom:
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
            if (CheckIf(ConditionCheckEnumType.InRange, false))
            {
                float range = maxValue - minValue;
                float distanceFromMin = currentValue - minValue;
                return distanceFromMin / range;
            }

            if (CheckIf(ConditionCheckEnumType.LessThan, false))
            {
                return (currentValue - minValue) / minValue;
            }

            if (CheckIf(ConditionCheckEnumType.GreaterThan, false))
            {
                return (currentValue - maxValue) / maxValue;
            }

            return 0.0f;
        }

        public override string ToString()
        {
            return
                $"Condition: {conditionCheckEnumType}, CurrentValue: {currentValue}, MinValue: {minValue}, MaxValue: {maxValue}, IsSatisfied: {isSatisfied}";
        }
    }
}