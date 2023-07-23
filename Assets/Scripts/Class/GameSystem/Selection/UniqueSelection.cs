using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Class.GameSystem.Selection
{
    [Serializable]
    public class UniqueSelection<T> : IUniqueSelectable<T>
    {
        [Header("Current")] [SerializeField] [Range(0, 20)] [OnValueChanged(nameof(SetByCurrentIndex))]
        protected int index;

        [SerializeField] protected T current;
        [SerializeField] public UnityEvent<T> onCurrentChanged;
        [Title("List")] [SerializeField] protected List<T> list;

        public List<T> List
        {
            get => list;
            set => list = value;
        }

        public int Index
        {
            get => index;
            set => index = value;
        }

        public T Current
        {
            get => current;
            set
            {
                current = value;
                onCurrentChanged?.Invoke(current);
            }
        }

        private void SetByCurrentIndex()
        {
            if (index < list.Count)
            {
                Current = list[index];
            }
            else
            {
                if (list != null)
                {
                    index = list.Count - 1;
                }
                else
                {
                    index = 0;
                }
            }
        }

        public void SetCurrent(T target)
        {
            list[index] = Current = target;
        }

        [Button]
        public void SetCurrent(int index)
        {
            this.index = index;
            Current = list[index];
        }

        public T GetCurrent()
        {
            return current;
        }
    }
}