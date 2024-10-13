using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class WeaponRecoil : SerializedMonoBehaviour
    {
        [field: SerializeField] public IWeaponShooting WeaponShooting { get; set; }

        public TransformRecoil TransformRecoil { get; private set; }

        private void Awake()
        {
            WeaponShooting ??= GetComponentInParent<IWeaponShooting>();

            TransformRecoil = new(transform, WeaponShooting);
        }

        private void Update()
        {
            TransformRecoil.Update();
        }
    }
}
