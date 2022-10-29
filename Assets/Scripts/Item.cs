using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee
{
    public EmployeeStat Morale;
    public EmployeeStat Speed;
    public EmployeeStat Tech;
}

public class Item : MonoBehaviour
{
    EmployeeStatModifier mod1, mod2;

    public void Equip(Employee e)
    {
        mod1 = new EmployeeStatModifier(10, StatModType.Flat);
        mod2 = new EmployeeStatModifier(0.1, StatModType.Percent);
        e.Strength.AddModifier(new EmployeeStatModifier(10, StatModType.Flat, this));
        e.Strength.AddModifier(new EmployeeStatModifier(0.1, StatModType.Percent, this));
    }

    public void Unequip(Employee e)
    {
        e.Strength.RemoveAllModifiersFromSource(this);
    }
}
