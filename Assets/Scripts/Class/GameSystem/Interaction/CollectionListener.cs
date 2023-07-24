using System;
using System.Collections.Generic;
using Class.GameSystem.Info;
using Class.GameSystem.State;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    [Serializable]
    public class CollectionListener<T> : SaveAble
    {
        public TextInfo textInfo;
        public List<NameCount> collectionNames;

        public List<NameCount> CollectionNames
        {
            get => collectionNames;
            set => collectionNames = value;
        }
        
        public void Increment<T>(CollectAble<T> item)
        {
            for (var index = 0; index < CollectionNames.Count; index++)
            {
                var tuple = collectionNames[index];
                if (tuple.name == item.TextInfo.Name)
                {
                    tuple.count += item.ItemCount.CurrentValue;
                    return;
                }
            }

            collectionNames.Add(new NameCount(item.TextInfo.Name, item.ItemCount.CurrentValue));
        }

        public void Decrement<T>(CollectAble<T> item)
        {
            for (var index = 0; index < CollectionNames.Count; index++)
            {
                var tuple = collectionNames[index];
                if (tuple.name == item.TextInfo.Name)
                {
                    tuple.count -= item.ItemCount.CurrentValue;
                    return;
                }
            }
        }

        private void SetNameAsKey()
        {
            textInfo.Key = textInfo.Name;
        }

        public override void Reset()
        {
            collectionNames.Clear();
        }

        public override string ToJson()
        {
            return JsonUtility.ToJson(collectionNames);
        }


        public override void SaveFull()
        {
            PlayerPrefs.SetString(textInfo.Key, ToJson());
        }

        public override void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(textInfo.Key), collectionNames);
        }
    }
}