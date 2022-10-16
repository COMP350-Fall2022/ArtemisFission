using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    //TODO: Go back and adjust to system where we only return active employees
    public List<Employee> GetEmployees() {
        return employees.Values.ToList();
    }

    // Returns the number of employees
    public int GetEmployeeCount() {
        return employees.Count;
    }

    // Print out all employees to the log. For convience purposes.
    public void LogAllEmployees() {
        Debug.Log("Logging (" + employees.Count + ") employees...");

        foreach(KeyValuePair<string, Employee> entry in employees) {
            Debug.Log("    > " + entry.Value.GetName());
        }
    }
}
