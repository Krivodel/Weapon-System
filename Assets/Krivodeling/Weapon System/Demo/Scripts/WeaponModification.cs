using Krivodeling.WeaponSystem.Modifiers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem.Demo
{
    public sealed class WeaponModification : SerializedMonoBehaviour
    {
        [SerializeField] private IWeaponShooting _weaponShooting;
        [SerializeField] private WeaponModuleData[] _modules;

        private void Awake()
        {
            _weaponShooting ??= GetComponentInParent<IWeaponShooting>();
        }

        private void Start()
        {
            Refresh();
        }

        [Button]
        private void Refresh()
        {
            WeaponModifiersController controller = _weaponShooting.ModifiersController;

            controller.RemoveAllModifiers();
            controller.AddWeaponModules(_modules);
            controller.Refresh();
        }
    }
}
