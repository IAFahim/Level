using System;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("claim")]
    [DeclareHorizontalGroup("buttons")]
    [DeclareTabGroup("tabs")]
    [Serializable]
    public class Reward<T, TComparable> : IReward<TComparable> where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField] [Group("tabs"), Tab("Info")] [DisableInEditMode]
        protected string key;

        [SerializeField] [Group("tabs"), Tab("Info")]
        protected string name;

        [SerializeField] [Group("tabs"), Tab("Info")] [Multiline(3)]
        protected string description;

        [SerializeField] [Group("tabs"), Tab("Info")]
        protected TComparable objectCount;

        [OnValueChanged(nameof(SetTypeAsKey))] [SerializeField] [Group("tabs"), Tab("Info")]
        protected T type;

        [SerializeField] [Group("tabs"), Tab("Claim")]
        protected int claimCount;

        [SerializeField] [Group("tabs"), Tab("Claim")]
        protected int maxClaimCount;

        public Reward(T type, TComparable count, int maxClaimCount = 1)
        {
            this.type = type;
            objectCount = count;
            this.maxClaimCount = maxClaimCount;
        }

        public string Key
        {
            get => key;
            set
            {
                var trim = value.Trim();
                if (trim.Length > 0)
                {
                    key = trim;
                }
            }
        }

        public string Name
        {
            get => name;
            set => name = value;
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
            key = type.ToString();
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

        [Group("buttons")]
        [Button]
        public void SaveFull()
        {
            PlayerPrefs.SetString(key, ToJson());
        }

        [Group("buttons")]
        [Button]
        public void Load()
        {
            var str = PlayerPrefs.GetString(key);
            JsonUtility.FromJsonOverwrite(str, this);
        }

        [Group("buttons")]
        [Button]
        public void Reset()
        {
            objectCount = default;
            claimCount = 0;
            PlayerPrefs.SetString(key, "");
        }
    }
}