using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;
[Serializable]

public class EmployeeStat : MonoBehaviour
{
    public float BaseValue;

    public float Value
    {
        get
        {
            if (isCrooked || lastBaseValue != BaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isCrooked = false;
            }
            return _value;
        }
    }

    protected readonly List<EmployeeStatModifier> statModifiers;
    public readonly ReadOnlyCollection<EmployeeStatModifier> EmployeeStatModifiers;

    protected bool isCrooked = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;
    //public virtual float Value { }

    public EmployeeStat(float baseValue) : this()
    {
        BaseValue = baseValue;
        statModifiers = new List<EmployeeStatModifier>();
        EmployeeStatModifiers = statModifiers.AsReadOnly();

    }

    public virtual void AddModifier(EmployeeStatModifier mod)
    {
        isCrooked = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public virtual bool RemoveModifier(EmployeeStatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            isCrooked = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                isCrooked = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        
        return didRemove;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            EmployeeStatModifier mod = statModifiers[i]; 

            if(mod.Type == EmployStatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == EmployStatModType.Percent)
            {
                sumPercentAdd += mod.Value;
                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != EmployStatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == EmployStatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
            
        }

        return (float) Math.Round(finalValue, 4);
    }

    protected virtual int CompareModifierOrder(EmployeeStatModifier a, EmployeeStatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }
}
