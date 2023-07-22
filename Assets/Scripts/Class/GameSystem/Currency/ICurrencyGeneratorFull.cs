using System;

namespace Class.GameSystem.Currency
{
    public interface ICurrencyGeneratorFull<TEnum, TComparable> where TEnum : System.Enum
        where TComparable : struct, IComparable<TComparable>
    {
        CurrencyGenerator<TEnum, TComparable> Get(object type);
        void Set(object type, TComparable value);
        int GetLength();
        string ToString();
    }
}