using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("condition")]
    [Serializable]
    public class Reward<T, TComparable> : IReward<TComparable> where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField] protected string title;

        [SerializeField] [Multiline(3)] protected string description;

        [SerializeField] protected TComparable objectCount;
        
        [OnValueChanged(nameof(SetTypeAsKey))]
        [SerializeField] [Group("type")] protected T type;

        [SerializeField] [Group("condition")] protected int claimCount;

        [SerializeField] [Group("condition")] protected int maxClaimCount;

        public Reward(T type, TComparable count , int maxClaimCount = 1)
        {
            this.type = type;
            objectCount = count;
            this.maxClaimCount = maxClaimCount;
        }

        public string Title
        {
            get => title;
            set
            {
                var trim = value.Trim();
                if (trim.Length > 0)
                {
                    title = trim;
                }
            }
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public TComparable ObjectCount
        {
            get => objectCount;
            set => objectCount = value;
        }

        public void SetTypeAsKey()
        {
            title = type.ToString();
        }

        public T Type
        {
            get => type;
            set => type = value;
        }

        public int ClaimCount
        {
            get => claimCount;
            set => claimCount = value;
        }

        public int MaxClaimCount
        {
            get => maxClaimCount;
            set => maxClaimCount = value;
        }

        public void IncrementClaimCount()
        {
            claimCount++;
        }

        public bool IsClaimable()
        {
            return claimCount < maxClaimCount;
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void Save()
        {
            PlayerPrefs.SetString(title, ToJson());
        }

        public void Load()
        {
            var str = PlayerPrefs.GetString(title);
            JsonUtility.FromJsonOverwrite(str, this);
        }

        public void Reset()
        {
            objectCount = default;
            claimCount = 0;
            PlayerPrefs.SetString(title, "");
        }
    }
}