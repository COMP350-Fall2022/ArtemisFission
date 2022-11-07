using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

// Enum object of the different skills an employee can take

public class Stat 
{
    internal string name;
    int salary;
    int morale;
    int speed;
    int tech;

    public Stat(string name, int salary, int morale, int speed, int tech)
    {
        this.name = name;
        this.salary = salary;
        this.morale = morale;
        this.speed = speed;
        this.tech = tech;
    }

    public void SetName(string newName)
    {
        // Preform any checks we need to on the name.
        this.name = newName;
    }

    public string GetName()
    {
        return this.name;
    }

    public int GetSalary()
    {
        return this.salary;
    }

    public int GetMorale()
    {
        return this.morale;
    }

    public int GetSpeed()
    {
        return this.speed;
    }

    public int GetTech()
    {
        return this.tech;
    }
}
