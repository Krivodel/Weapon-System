using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class HorizontalRecoilCalculator
    {
        public IWeaponShooting WeaponShooting { get; private set; }
        public IHorizontalRecoilPatternReadOnly Pattern => WeaponShooting.ModifiableWeapon.Recoil.HorizontalPattern;
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Multiplier => Pattern.MultiplierCurve.Evaluate(_multiplierTime);

        private float _multiplierTime;

        public HorizontalRecoilCalculator(IWeaponShooting weaponShooting)
        {
            WeaponShooting = weaponShooting;
            Min = Pattern.MinRecoil;
            Max = Pattern.MaxRecoil;
            _multiplierTime = Pattern.StartMultiplierTime;
        }

        public void Update()
        {
            if (WeaponShooting.IsShooting)
                _multiplierTime += Pattern.MultiplierIncreasing * Time.deltaTime;
            else
                _multiplierTime -= Pattern.MultiplierDecreasing * Time.deltaTime;

            if (_multiplierTime < Pattern.StartMultiplierTime)
                _multiplierTime = Pattern.StartMultiplierTime;
            else if (_multiplierTime > 1f)
                _multiplierTime = 1f;
        }

        public float NextRecoil()
        {
            float time = Random.Range(Min, Max) * Multiplier;
            float recoil = Pattern.RecoilCurve.Evaluate(time) * Pattern.RecoilMultiplier;

            if (time < 0f)
                recoil = -recoil;

            return recoil;
        }
    }
}
