using System;
using System.Linq;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    [Serializable]
    public sealed class AudioData : IAudioDataReadOnly
    {
        [field: SerializeField] public AudioClip[] Shots { get; set; }

        public AudioData DeepCopy()
        {
            AudioData audioData = new()
            {
                Shots = Shots.ToArray()
            };

            return audioData;
        }
    }
}
