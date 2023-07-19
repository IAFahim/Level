using System;
using Class.GameSystem.Info;
using Class.GameSystem.Interaction;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Item
{
    [DeclareHorizontalGroup("buttons")]
    
    [Serializable]
    public class Item<T, TObject>
    {
        [SerializeField]
        protected T itemType;

        [SerializeField] [OnValueChanged(nameof(SetItemObjectNameAsKey))]
        protected TObject gameObject;

        public TextInfo textInfo;
        [FormerlySerializedAs("itemLock")] public LockItem<float> lockItem;

        public void SetItemObjectNameAsKey()
        {
            textInfo.Key = gameObject.ToString();
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        [Group("buttons")]
        [Button]
        public void SaveFull()
        {
            PlayerPrefs.SetString(textInfo.Key, ToJson());
        }

        [Group("buttons")]
        [Button]
        public void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(textInfo.Key), this);
        }

        [Group("buttons")]
        [Button]
        public void Reset()
        {
            PlayerPrefs.SetString(textInfo.Key, "");
        }
    }
}