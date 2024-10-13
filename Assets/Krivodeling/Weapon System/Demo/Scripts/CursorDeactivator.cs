using UnityEngine;

namespace Krivodeling.WeaponSystem.Demo
{
    public sealed class CursorDeactivator : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
