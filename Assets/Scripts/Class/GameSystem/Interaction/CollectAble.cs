using System;
using Class.GameSystem.Info;
using Class.GameSystem.Mission;
using Class.GameSystem.Satisfiable;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    [Serializable]
    public class CollectAble<T> : ICollectAble<T>
    {
        [SerializeField] private TempCollectionListenerSo listener;
        [OnValueChanged(nameof(SetTargetNameAsKeySetItemTarget))]public T target;
        public TextInfo textInfo;
        public VariableCondition<T> itemCount;

        public T Target
        {
            get => target;
            set => target = value;
        }
        
        private void SetTargetNameAsKeySetItemTarget()
        {
            textInfo.Key = target.ToString();
            itemCount.Target = target;
            
        }

        public TextInfo TextInfo
        {
            get => textInfo;
            set => textInfo = value;
        }

        public VariableCondition<T> ItemCount
        {
            get => itemCount;
            set => itemCount = value;
        }
        

        [Button]
        public void Collect()
        {
            listener.collectionListener?.Increment(this);
            itemCount.CurrentValue++;
        }
    }
}