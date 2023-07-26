using System;
using System.Collections.Generic;
using Class.Info;
using Class.State;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.Interaction
{
    [Serializable]
    public class Collector<T, TCountAbleObject> : SaveAble, IKey where TCountAbleObject : ICountAbleObject, new()
    {
        [Required][DisableInEditMode] [SerializeField] public string key;
        public string Key { get; }
        public virtual void SetAskKey()
        {
        }


        public TextInfo textInfo;

        [FormerlySerializedAs("collectionList")]
        [ListDrawerSettings(Draggable = true,
            HideAddButton = false,
            HideRemoveButton = false,
            AlwaysExpanded = true)]
        public List<TCountAbleObject> list;

        public List<TCountAbleObject> List
        {
            get => list;
            set => list = value;
        }

        public void Increment<T>(CollectAble<T> item)
        {
            for (var index = 0; index < List.Count; index++)
            {
                TCountAbleObject tuple = list[index];
                if (tuple.Key == item.Key)
                {
                    tuple.Count++;
                    return;
                }
            }

            list.Add(new TCountAbleObject
            {
                Count = 1
            });
        }

        public void Decrement<T>(CollectAble<T> item)
        {
            for (var index = 0; index < List.Count; index++)
            {
                var tuple = list[index];
                if (tuple.Key == item.Key)
                {
                    tuple.Count--;
                    if (tuple.Count == -1)
                        list.RemoveAt(index);
                    return;
                }
            }
        }

        public override void Reset()
        {
            list.Clear();
        }

        public override string ToJson()
        {
            return JsonUtility.ToJson(list);
        }


        public override void SaveFull()
        {
            PlayerPrefs.SetString(key, ToJson());
        }

        public override void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), list);
        }
    }
}