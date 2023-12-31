﻿using System;
using Class.Info;
using Class.Mission;
using Class.Satisfiable;
using TriInspector;
using UnityEngine;

namespace Class.Interaction
{
    [Serializable]
    public class CollectAble<T> : ICollectAble<T>
    {
        [SerializeField] [DisableInEditMode] protected string key;
        [SerializeField] private CollectionListenerSo collectorSo;
        [OnValueChanged(nameof(SetTargetNameAsKeySetItemTarget))]public T target;
        public TextInfo textInfo;
        public VariableCondition<T> itemCount;
        

        public T Target
        {
            get => target;
            set => target = value;
        }
        
        public string Key => key;
        
        public void SetAskKey()
        {
            this.key = target.ToString();
        }
        
        private void SetTargetNameAsKeySetItemTarget()
        {
            SetAskKey();
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
            collectorSo.collector?.Increment(this);
            itemCount.CurrentValue++;
        }
    }
}