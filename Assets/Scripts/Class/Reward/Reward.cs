using Class.Interaction;

namespace Class.Reward
{
    public class Reward<T>: ClaimAble
    {
        public T Group { get; set; }
    }
}