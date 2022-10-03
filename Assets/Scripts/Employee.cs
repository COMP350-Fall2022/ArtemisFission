using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum object of the different skills an employee can take
public enum EmployeeSkill {
    Skill1,
    Skill2,
    Skill3

}
// Employee object.
public class Employee
{
    internal string employeeName;
    int salary;
    EmployeeSkill[] skills;

    public Employee(string name, int salary, EmployeeSkill[] skills) {
        this.employeeName = name;
        this.salary = salary;
        this.skills = skills;
    }

    public void changeName(string newName) {
        employeeName = newName;
    }

    public string getName() {
        return employeeName;
    }
}

