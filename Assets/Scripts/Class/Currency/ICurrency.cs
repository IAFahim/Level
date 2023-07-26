using System;

namespace Class.Currency
{
    public interface ICurrency<T, TComparable> 
        where TComparable : struct, IComparable<TComparable>
    {
        public T Target { get; set; }
        TComparable Value { get; set; }
    }
}