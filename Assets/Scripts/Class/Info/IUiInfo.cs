using UnityEngine;

namespace Class.Info
{
    public interface IUiInfo : ITextInfo
    {
        Sprite Icon { get; set; }
    }
}