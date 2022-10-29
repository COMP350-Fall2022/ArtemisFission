using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmployStatModType
{
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300,
}

public class EmployeeStatModifier : MonoBehaviour
{
    public readonly int Order;
    public readonly float Value;
    public readonly EmployStatModType Type;
    public readonly object Source;

    public EmployeeStatModifier(float value, EmployStatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }

    public EmployeeStatModifier(float value, EmployStatModType type) : this(value, type, (int)type) { }

    public EmployStatModifier(float value, EmployStatModType type, int order) : this(value, type, order, null) { }

    public EmployStatModifier(float value, EmployStatModType type, object source) : this(value, type, (int)type, source) { }
}
