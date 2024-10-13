using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public interface IAudioDataReadOnly
    {
        AudioClip[] Shots { get; }
    }
}
