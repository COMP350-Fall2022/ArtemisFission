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
    internal bool isWorking;

    public Employee(string name, int salary, EmployeeSkill[] skills) {
        this.name = name;
        this.salary = salary;
        this.skills = skills;
        this.id = System.Guid.NewGuid();
        this.isWorking = false;
    }

    public void SetName(string newName) {
        // Preform any checks we need to on the name.
        this.name = newName;
    }

    public string GetName() {
        return this.name;
    }

    public string GetId() {
        return this.id.ToString();
    }

    public EmployeeSkill[] GetSkills() {
        return this.skills;
    }

    public int GetSalary() {
        return this.salary;
    }
}

