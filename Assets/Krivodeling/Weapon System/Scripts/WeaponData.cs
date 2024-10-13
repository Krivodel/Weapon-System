using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    [CreateAssetMenu(menuName = Paths.Weapons + "Weapon")]
    public sealed class WeaponData : ScriptableObject, IWeaponDataReadOnly
    {
        [field: SerializeField] public int ShotsPerMinute { get; set; } = 600;
        [field: SerializeField] public RecoilData Recoil { get; set; }
        [field: SerializeField] public AudioData Audio { get; set; }

        IRecoilDataReadOnly IWeaponDataReadOnly.Recoil => Recoil;
        IAudioDataReadOnly IWeaponDataReadOnly.Audio => Audio;

        public WeaponData DeepCopy()
        {
            WeaponData weaponData = CreateInstance<WeaponData>();

            weaponData.ShotsPerMinute = ShotsPerMinute;
            weaponData.Recoil = Recoil.DeepCopy();
            weaponData.Audio = Audio.DeepCopy();

#if UNITY_EDITOR
            weaponData.name = $"(modified) {name}";
#endif

            return weaponData;
        }
    }
}
