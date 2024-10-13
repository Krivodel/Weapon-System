using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem.Demo
{
    public sealed class CameraAxisController : MonoBehaviour
    {
        [SerializeField] private Vector3 _axis;
        [SerializeField] private bool _clamped;
        [SerializeField, ShowIf(nameof(_clamped))] private float _clampMin = -89f;
        [SerializeField, ShowIf(nameof(_clamped))] private float _clampMax = 89f;
        [SerializeField] private float _currentRotation;

        public void ManualUpdate(float additionalRotation)
        {
            _currentRotation += additionalRotation;

            if (_clamped)
                _currentRotation = Mathf.Clamp(_currentRotation, _clampMin, _clampMax);

            if (_currentRotation >= 180f)
                _currentRotation -= 360f;
            else if (_currentRotation <= -180f)
                _currentRotation += 360f;

            Vector3 eulerAngles = transform.localEulerAngles;

            eulerAngles.x = _axis.x * _currentRotation;
            eulerAngles.y = _axis.y * _currentRotation;
            eulerAngles.z = _axis.z * _currentRotation;

            transform.localRotation = Quaternion.Euler(eulerAngles);
        }
    }
}
