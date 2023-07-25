using System.Collections.Generic;
using Class.GameSystem.Info;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    public interface ICollectionListener<T> where T : ICollectAble<T>
    {
        List<CountAbleObject> CollectionNames { get; set; }
        void Add<T>(CollectAble<T> item);
        void Remove<T>(CollectAble<T> item);
    }
}