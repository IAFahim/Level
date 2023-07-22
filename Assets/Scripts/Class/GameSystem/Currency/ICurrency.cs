using System;
using Class.GameSystem.Info;

namespace Class.GameSystem.Currency
{
    public interface ICurrency<T, out TComparable> 
        where TComparable : struct, IComparable<TComparable>
    {
        public T Target { get; set; }
        TComparable Count { get; }
    }
}