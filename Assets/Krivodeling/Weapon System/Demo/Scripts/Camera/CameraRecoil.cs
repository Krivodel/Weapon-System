using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class CameraRecoil : MonoBehaviour
    {
        [SerializeField] private WeaponRecoil _weaponRecoil;
        [SerializeField] private Vector3 _axis = new(-1f, -1f, 1f);
        [SerializeField] private float _intensity = 6f;
        [SerializeField] private float _multiplier = 60f;

        private Vector3 _localEulerAngles;

        private void Awake()
        {
            if (_weaponRecoil == null)
                _weaponRecoil = GetComponentInChildren<WeaponRecoil>();
        }

        private void LateUpdate()
        {
            Vector3 weaponDeviation = _weaponRecoil.TransformRecoil.PositionDeviation;
            Vector3 targetEulerAngles = new Vector3(weaponDeviation.y * _axis.x, weaponDeviation.x * _axis.y, 0f) * _multiplier;
            float smoothingFactor = 1f - Mathf.Exp(-_intensity * Time.deltaTime);

            _localEulerAngles = Vector3.Lerp(_localEulerAngles, targetEulerAngles, smoothingFactor);

            transform.localRotation = Quaternion.Euler(_localEulerAngles);
        }
    }
}
