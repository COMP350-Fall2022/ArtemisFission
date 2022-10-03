using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for all employees in the game. Keeps track of all active employees.
public class EmployeeController
{
    List<Employee> employees;

    public EmployeeController() {
        this.employees = new List<Employee>();
    }

    // Creates an employee and returns a pointer to it
    public Employee createNewEmployee(string name, int salary, EmployeeSkill[] skills) {
        Employee e = new Employee(name, salary, skills);
        employees.Add(e);
        return e;
    }

    public void logAllEmployees() {
        Debug.Log(employees.Count);
        for (int i = 0; i < employees.Count; i++) {
            Debug.Log(employees[i].employeeName);
        }
    }
}
