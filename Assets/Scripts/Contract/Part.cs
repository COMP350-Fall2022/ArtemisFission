using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class Part
{
    internal string partName;
    private Guid guid;
    public bool isConsumable;

    public Part(string partName, bool isConsumable) {
        this.partName = partName;
        this.isConsumable = isConsumable;
    }
}
