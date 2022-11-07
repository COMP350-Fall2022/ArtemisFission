using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class StatController 
{
    Dictionary<string, Stat> stats;

    EmployeeController employeeController;

    public StatController(EmployeeController employeeController)
    {
        stats = new Dictionary<string, Stat>();
        this.employeeController = employeeController;
    }

    public Stat CreateNewStat(string name, int salary, int morale, int speed, int tech)
    {
        Stat s = new Stat(name, salary, morale, speed, tech);
        stats.Add(s.GetGuid(), s);
        return s.GetGuid();
    }

    public Stat GetStat(string guid)
    {
        return stats[guid];
    }
}
