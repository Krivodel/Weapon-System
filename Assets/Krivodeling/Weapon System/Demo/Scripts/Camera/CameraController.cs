using UnityEngine;

namespace Krivodeling.WeaponSystem.Demo
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraAxisController _xAxisController;
        [SerializeField] private CameraAxisController _yAxisController;
        [SerializeField] private Vector2 _sensitivity = new(1f, 1f);

        private void Update()
        {
            _xAxisController.ManualUpdate(Input.GetAxis("Mouse Y") * _sensitivity.y);
            _yAxisController.ManualUpdate(Input.GetAxis("Mouse X") * _sensitivity.x);
        }
    }
}
