using DG.Tweening;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class TransformRecoil
    {
        public Transform Transform { get; set; }
        public IWeaponShooting WeaponShooting { get; set; }

        public Vector3 PositionDeviation { get; private set; }
        public Vector3 RotationDeviation { get; private set; }

        public VerticalRecoilCalculator VerticalCalculator { get; }
        public HorizontalRecoilCalculator HorizontalCalculator { get; }

        private Tween _returnTween;
        private float _rotationDeviationZ;

        public TransformRecoil(Transform transform, IWeaponShooting weaponShooting)
        {
            Transform = transform;
            WeaponShooting = weaponShooting;
            VerticalCalculator = new(WeaponShooting);
            HorizontalCalculator = new(WeaponShooting);

            WeaponShooting.Shoted += OnShoted;
        }

        public void Update()
        {
            VerticalCalculator.Update();
            HorizontalCalculator.Update();

            float smoothingFactor = 1f - Mathf.Exp(-WeaponShooting.GlobalSettings.ShootingIntensity * WeaponShooting.ModifiableWeapon.Recoil.ShootingIntensity * Time.deltaTime);
            Vector3 newPosition = Vector3.Lerp(Transform.localPosition, PositionDeviation, smoothingFactor);
            Quaternion newRotation = Quaternion.Lerp(Transform.localRotation, Quaternion.Euler(RotationDeviation), smoothingFactor);

            Transform.SetLocalPositionAndRotation(newPosition, newRotation);
        }

        private void OnShoted()
        {
            var globalSettings = WeaponShooting.GlobalSettings;
            var recoilData = WeaponShooting.ModifiableWeapon.Recoil;
            var recoil = NextRecoil();

            _rotationDeviationZ = Random.Range(0, 2) == 0 ? 1f : -1f;
            PositionDeviation = new(recoil.x * globalSettings.RecoilMultiplier.x, recoil.y * globalSettings.RecoilMultiplier.y, globalSettings.RecoilMultiplier.z);
            RotationDeviation = new Vector3(
                -PositionDeviation.y * globalSettings.RotationMultiplier.x,
                PositionDeviation.x * globalSettings.RotationMultiplier.y,
                _rotationDeviationZ * PositionDeviation.z * globalSettings.RotationMultiplier.z);

            _returnTween?.Kill();

            _returnTween = DOVirtual
                .Vector3(PositionDeviation, Vector3.zero, recoilData.ReturnDuration * globalSettings.ReturnDurationMultiplier, OnReturnTweenUpdate)
                .SetEase(recoilData.OverrideReturnCurve ? recoilData.ReturnCurve : globalSettings.ReturnCurve);
        }

        private void OnReturnTweenUpdate(Vector3 deviation)
        {
            var globalSettings = WeaponShooting.GlobalSettings;

            PositionDeviation = deviation;
            RotationDeviation = new Vector3(
                -deviation.y * globalSettings.RotationMultiplier.x,
                deviation.x * globalSettings.RotationMultiplier.y,
                _rotationDeviationZ * deviation.z * globalSettings.RotationMultiplier.z);
        }

        private Vector2 NextRecoil()
        {
            return new()
            {
                x = HorizontalCalculator.NextRecoil(),
                y = VerticalCalculator.NextRecoil()
            };
        }
    }
}
