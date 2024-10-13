using Krivodeling.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class WeaponAudioSource : SerializedMonoBehaviour
    {
        [SerializeField] private IWeaponShooting _weaponShooting;

        private AudioSource[] _audioSources;
        private int _audioSourceIndex = -1;

        private void Awake()
        {
            _weaponShooting ??= GetComponentInParent<IWeaponShooting>();
            _audioSources = GetComponentsInChildren<AudioSource>();

            _weaponShooting.Shoted += OnShoted;
        }

        private void OnDestroy()
        {
            _weaponShooting.Shoted -= OnShoted;
        }

        private void OnShoted()
        {
            AudioClip sound = _weaponShooting.ModifiableWeapon.Audio.Shots.GetRandomElement();

            NextAudioSource().PlayOneShot(sound);
        }

        private AudioSource NextAudioSource()
        {
            _audioSourceIndex++;

            if (_audioSourceIndex == _audioSources.Length)
                _audioSourceIndex = 0;

            return _audioSources[_audioSourceIndex];
        }
    }
}
