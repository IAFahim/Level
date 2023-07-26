using System.Collections.Generic;
using Class.Info;

namespace Class.Interaction
{
    public interface ICollectionListener<T> where T : ICollectAble<T>
    {
        List<CountAbleObject> CollectionNames { get; set; }
        void Add<T>(CollectAble<T> item);
        void Remove<T>(CollectAble<T> item);
    }
}