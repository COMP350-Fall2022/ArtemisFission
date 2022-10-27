using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources
{
    float money;
    float workingHours;
    Dictionary<string, int> parts = new Dictionary<string, int>();
    float time;
    float morale;

    public Resources(float money, float workingHours, Dictionary<string, int> parts, float time, float morale)
    {
        this.money = money;
        this.workingHours = workingHours;
        this.parts = parts;
        this.time = time;
        this.morale = morale;
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

    public void SetMorale(float newMorale)
    {
        this.morale = newMorale;
    }

    public float GetMorale()
    {
        return this.morale;
    }
}
