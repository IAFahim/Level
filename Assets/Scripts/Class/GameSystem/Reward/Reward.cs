using Class.GameSystem.Interaction;

namespace Class.GameSystem.Reward
{
    public class Reward<T>: ClaimAble
    {
        public T Group { get; set; }
    }
}