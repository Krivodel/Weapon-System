# Weapon System
Система отдачи и модификации оружия, вдохновлённая игрой EFT. Поощрает одиночный режим и короткий зажим, трудно контролировать при автоматической стрельбе.

https://github.com/user-attachments/assets/bc35a681-43ea-49d8-b600-f7a78ae7a9d4

Гибкая настройка отдачи. Можно имитировать отдачу автоматов, пистолетов, снайперок, дробовиков, гранатомётов и т. д.

![image](https://github.com/user-attachments/assets/19e4ce14-98ca-4200-ba24-02e51d03c4cc)
![image](https://github.com/user-attachments/assets/da7bff05-d1d3-459e-a7ae-1a52bd30e608)

Модификация оружия, которую можно использовать для оружейных модулей, навыков персонажа и т. д.

![image](https://github.com/user-attachments/assets/8dc243fd-5100-4668-b392-64e097cab97a)

Можно писать собственные модификаторы. Для этого достаточно наследоваться от **WeaponModifier**

```
public class ExampleModifier : WeaponModifier
{
    [field: SerializeField] public float CompensationPercent { get; private set; } = 30f;

    protected override void OnApply(in IWeaponDataReadOnly original, WeaponData modifiable)
    {
        float change = original.Recoil.VerticalPattern.MultiplierIncreasing.TakePercent(CompensationPercent);

    }
}
```

И модификатор уже появится в списке для применения

![image](https://github.com/user-attachments/assets/8a0fb88c-2751-4da7-a4c6-d1741167e41c)

# Как установить
2 варианта:
1) Перенести папку **Krivodeling** в папку **Assets**
2) Импортировать **.unitypackage**: https://github.com/Krivodel/Weapon-System/releases/
# Зависимости
- Global Extensions: https://github.com/Krivodel/Global-Extensions/releases
- DOTween Pro
- Odin Inspector and Serializer
