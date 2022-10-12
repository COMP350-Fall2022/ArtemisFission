using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for all employees in the game. Keeps track of all active employees.
public class EmployeeController
{
    Dictionary<string, Employee> employees;
    int maxEmployees;

    // Constructor.
    public EmployeeController(int maxEmployees) {
        employees = new Dictionary<string, Employee>();
        this.maxEmployees = maxEmployees;
    }

    // Creates an employee and returns the ID for it.
    public string CreateNewEmployee(string name, int salary, EmployeeSkill[] skills) {
        Employee e = new Employee(name, salary, skills);
        string id = e.GetId();
        employees.Add(id, e);
        return id;
    }

    // Deletes or "fires" an employee
    public bool FireEmployee(string id) {
        return employees.Remove(id);
    }

    // Print out all employees to the log. For convience purposes.
    public void LogAllEmployees() {
        Debug.Log("Logging (" + employees.Count + ") employees...");

        foreach(KeyValuePair<string, Employee> entry in employees) {
            Debug.Log("    > " + entry.Value.GetName());
        }
    }
}
