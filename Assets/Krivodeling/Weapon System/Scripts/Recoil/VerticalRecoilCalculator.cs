using Krivodeling.Extensions;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class VerticalRecoilCalculator
    {
        public IWeaponShooting WeaponShooting { get; private set; }
        public IVerticalRecoilPatternReadOnly Pattern => WeaponShooting.ModifiableWeapon.Recoil.VerticalPattern;
        public float Min => Max.TakePercent(100f - WeaponShooting.GlobalSettings.VerticalRecoilPercentage);
        public float Max => Pattern.Recoil;
        public float Multiplier { get; private set; }

        public VerticalRecoilCalculator(IWeaponShooting weaponShooting)
        {
            WeaponShooting = weaponShooting;
            Multiplier = Pattern.StartMultiplier;
        }

        public void Update()
        {
            if (WeaponShooting.IsShooting)
                Multiplier += Pattern.MultiplierIncreasing * Time.deltaTime;
            else
                Multiplier -= Pattern.MultiplierDecreasing * Time.deltaTime;

            if (Multiplier < Pattern.StartMultiplier)
                Multiplier = Pattern.StartMultiplier;
            else if (Multiplier > 1f)
                Multiplier = 1f;
        }

        public float NextRecoil()
        {
            float recoil = Random.Range(Min, Max) * Multiplier;

            return recoil;
        }
    }
}
