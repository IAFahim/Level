using System;
using System.Collections.Generic;
using Class.GameSystem.Currency;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Currency
{
    [Serializable]
    public class CurrencyGeneratorFull<T, TComparable> : ICurrencyGeneratorFull<T, TComparable>
        where T : System.Enum where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField] private List<CurrencyGenerator<T, TComparable>> currency;

        public CurrencyGeneratorFull()
        {
            Array enumType = System.Enum.GetValues(typeof(T));
            var enumSize = enumType.Length;
            currency = new(enumSize);
            for (int i = 0; i < enumSize; i++)
            {
                currency.Add(new CurrencyGenerator<T, TComparable>((T)enumType.GetValue(i), default));
            }
        }

        public CurrencyGenerator<T, TComparable> Get(object type)
        {
            int index = (int)type;
            if (index < currency.Count) return currency[index];
            return default;
        }


        public void Set(object type, TComparable value)
        {
            int index = (int)type;
            if (index < currency.Count) currency[index].Value = value;
        }

        public int GetLength()
        {
            return currency.Count;
        }

        public static implicit operator int(CurrencyGeneratorFull<T, TComparable> v)
        {
            return v.currency.Count;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var r in currency)
            {
                s += r.ToString() + "\n";
            }

            return s;
        }
    }
}