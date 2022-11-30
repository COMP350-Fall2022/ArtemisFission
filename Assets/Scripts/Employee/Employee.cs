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
    bool hired;
    private Guid id;
    public Employee(string name, int salary, EmployeeSkill[] skills, bool hired) {
        this.name = name;
        this.salary = salary;
        this.skills = skills;
        this.hired = hired;
        this.id = System.Guid.NewGuid();
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

    public bool GetHired() {
        return this.hired;
    }

    public void SetHired() {
        this.hired = true;
    }

    public void UnsetHired() {
        this.hired = false;
    }
}

