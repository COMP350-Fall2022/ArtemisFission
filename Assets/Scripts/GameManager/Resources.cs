using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources
{
    float money;
    float workingHours;
    Dictionary<string, int> parts = new Dictionary<string, int>();
    float time;
    Dictionary<string, float> morale = new Dictionary<string, float>();

    public Resources()
    {
        this.money = 0;
        this.workingHours = 0;
        this.parts = new Dictionary<string, int>();
        this.time = 0;
        this.morale = new Dictionary<string, float>();
    }

    public Resources CreateResources()
    {
        Resources r = new Resources();
        return r;
    }
    public void SetMoney(float newMoney)
    {
        this.money = newMoney;
    }
    public float GetMoney()
    {
        return this.money;
    }

    public void SetWorkingHours(float newHours)
    {
        this.workingHours = newHours;
    }

    public float GetWorkingHours()
    {
        return this.workingHours;
    }

    public void SetPartAmount(string partName, int partAmount)
    {
        this.parts[partName] = partAmount;
    }

    public int GetPartAmount(string partName)
    {
        return this.parts[partName];
    }

    public void SetTime(float newTime)
    {
        this.time = newTime;
    }

    public float GetTime()
    {
        return this.time;
    }

    public void SetEmployeeMorale(string employeeID, float newMorale)
    {
        this.morale[employeeID] = newMorale;
    }

    public Dictionary<string, float> GetAllEmployeesMorale()
    {
        return this.morale;
    }
}
