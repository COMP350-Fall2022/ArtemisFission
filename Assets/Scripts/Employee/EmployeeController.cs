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

    public List<Employee> GetEmployees() {
        return employees.Values.ToList();
    }

    public List<Employee> GetUnavaliableEmployees() {

        // return employees.Values.Where(employee => employee.isWorking == true) as List<Employee>;
        List<Employee> tmp = new List<Employee>();
        foreach (var e in employees.Values) {
            if (e.isWorking) {
                tmp.Add(e);
            }
        }
        return tmp;
    }

    public List<Employee> GetAvaliableEmployees() {
        List<Employee> tmp = new List<Employee>();
        foreach (var e in employees.Values) {
            if (!e.isWorking) {
                tmp.Add(e);
            }
        }
        return tmp;
        // return employees.Values.Where(employee => employee.isWorking == false) as List<Employee>;
    }

    public Employee GetEmployee(string id) {
        return employees[id];
    }

    public int GetEmployeeCount() {
        return employees.Count;
    }

    public void LogAllEmployees() {
        Debug.Log("Logging (" + employees.Count + ") employees...");

        foreach(KeyValuePair<string, Employee> entry in employees) {
            Debug.Log("    > " + entry.Value.GetName());
        }
    }
}
