namespace Krivodeling.WeaponSystem.Modifiers
{
    public static class WeaponModifiersControllerExtensions
    {
        public static void AddWeaponModule(this WeaponModifiersController controller, WeaponModuleData module)
        {
            controller.AddModifiers(module.Modifiers);
        }

        public static void RemoveWeaponModule(this WeaponModifiersController controller, WeaponModuleData module)
        {
            controller.RemoveModifiers(module.Modifiers);
        }

        public static void AddWeaponModules(this WeaponModifiersController controller, params WeaponModuleData[] modules)
        {
            for (int i = 0; i < modules.Length; i++)
                controller.AddWeaponModule(modules[i]);
        }

        public static void RemoveWeaponModules(this WeaponModifiersController controller, params WeaponModuleData[] modules)
        {
            for (int i = 0; i < modules.Length; i++)
                controller.RemoveWeaponModule(modules[i]);
        }
    }
}
