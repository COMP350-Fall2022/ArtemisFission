using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Controller for all employees in the game. Keeps track of all active employees.
public class EmployeeController
{
    // Dictionary<Employee, Contract> activeEmployees = new Dictionary<Employee, Contract>();
    // List<Employee> inactiveEmployees = new List<Employee>();
    private Dictionary<Employee, bool> employees = new Dictionary<Employee, bool>();
    // Dictionary<string, Contract> activeEmployees;
    int maxEmployees;

    // Constructor.
    public EmployeeController(int maxEmployees) {
        this.maxEmployees = maxEmployees;
    }

    // Creates an employee and returns the ID for it.
    public Employee CreateNewEmployee(string name, int salary, EmployeeSkill[] skills) {
        Employee e = new Employee(name, salary, skills);
        employees.Add(e, false);
        return e;
    }

    // Deletes or "fires" an employee
    public bool DeleteEmployee(Employee e) {
        return employees.Remove(e);
    }

    public List<Employee> GetEmployees() {
        return employees.Keys.ToList();
    }

    public List<Employee> GetActiveEmployees() {
        List<Employee> tmp = employees.Where(e => e.Value == true) as List<Employee>;
        if (tmp == null) {
            return new List<Employee>();
        } else {
            return tmp;
        }
    }

    public List<Employee> GetInactiveEmployees() {
        List<Employee> tmp = employees.Where(e => e.Value == false) as List<Employee>;
        if (tmp == null) {
            return new List<Employee>();
        } else {
            return tmp;
        }    }

    public void UnassignEmployee(Employee e) {
        employees[e] = false;
    }

    private Employee GetEmployeeFromId(string id) {
        return employees.Keys.ToList().Find(e => e.GetId() == id);
    }

    public void UnassignEmployee(string id) {
        Employee e = GetEmployeeFromId(id);
        UnassignEmployee(e);
    }

    public bool AssignEmployee(Employee e) {
        if (employees[e] == true) {
            return false;
        } else {
            employees[e] = true;
            return true;
        }
    }

    public bool AssignEmployee(string id) {
        Employee e = GetEmployeeFromId(id);
        return AssignEmployee(e);
    }

    public int GetEmployeeCount() {
        return employees.Count;
    }

    public void LogAllEmployees() {
        Debug.Log("Logging (" + GetEmployeeCount() + ") employees...");

        foreach(KeyValuePair<Employee, bool> entry in employees) {
            Debug.Log("    > " + entry.Key.name);
        }
    }
}
