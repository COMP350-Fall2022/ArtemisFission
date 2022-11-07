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
}
