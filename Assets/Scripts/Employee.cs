using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

// Enum object of the different skills an employee can take
public enum EmployeeSkill {
    Skill1,
    Skill2,
    Skill3

}
// Employee object.
public class Employee
{
    internal string name;
    int salary;
    EmployeeSkill[] skills;
    private Guid id;

    public Employee(string name, int salary, EmployeeSkill[] skills) {
        this.name = name;
        this.salary = salary;
        this.skills = skills;
        this.id = System.Guid.NewGuid();
    }

    public void setName(string newName) {
        // Preform any checks we need to on the name.
        this.name = newName;
    }

    public string getName() {
        return this.name;
    }

    public string getId() {
        return this.id.ToString();
    }

    public EmployeeSkill[] getSkills() {
        return this.skills;
    }

    public int getSalary() {
        return this.salary;
    }
}

