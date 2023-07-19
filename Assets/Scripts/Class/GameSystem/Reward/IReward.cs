using System;
using Class.GameSystem.Info;
using Class.GameSystem.Interaction;
using Class.GameSystem.SaveAble;

namespace Class.GameSystem.Reward
{
    public interface IReward<out TComparable> : ITextInfo, ISaveAble, IClaimAble
        where TComparable : struct, IComparable<TComparable>
    {
        TComparable ObjectCount { get; }
        public void SetTypeAsKey();
    }
}