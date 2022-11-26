using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Controller for all employees in the game. Keeps track of all active employees.
public class EmployeeController
{
    private Dictionary<Employee, bool> employees = new Dictionary<Employee, bool>();
    int maxEmployees;
    public EmployeeController(int maxEmployees) {
        this.maxEmployees = maxEmployees;
    }

    // Creates an employee and returns the ID for it.
    public Employee CreateNewEmployee(string name, int salary, EmployeeSkill[] skills, bool hired) {
        Employee e = new Employee(name, salary, skills, hired);
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
        List<Employee> tmp = new List<Employee>();
        foreach(KeyValuePair<Employee, bool> kv in employees) {
            if (kv.Value == true) {
                tmp.Add(kv.Key);
            }
        }
        return tmp;
    }

    public List<Employee> GetInactiveEmployees() {
        List<Employee> tmp = new List<Employee>();
        foreach(KeyValuePair<Employee, bool> kv in employees) {
            if (kv.Value == false) {
                tmp.Add(kv.Key);
            }
        }
        return tmp;
    }

    public void UnassignEmployee(Employee e) {
        employees[e] = false;
    }

    public Employee GetEmployeeFromId(string id) {
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
        Debug.Log("Got " + e.name);
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

    public void HireEmployee(string id)
    {
        Employee e = GetEmployeeFromId(id);
        e.SetHired();
    }

    public void CheckHired()
    {
        List<Employee> tmp = new List<Employee>(GetEmployees());
                
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    tmp[0].SetHired();
                    string id = tmp[0].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    tmp[1].SetHired();
                    string id = tmp[1].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    tmp[2].SetHired();
                    string id = tmp[2].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    tmp[3].SetHired();
                    string id = tmp[3].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    tmp[4].SetHired();
                    string id = tmp[4].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    tmp[5].SetHired();
                    string id = tmp[5].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    tmp[6].SetHired();
                    string id = tmp[6].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    tmp[7].SetHired();
                    string id = tmp[7].GetId();
                    HireEmployee(id);
                }

                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    tmp[8].SetHired();
                    string id = tmp[8].GetId();
                    HireEmployee(id);
                }
    }
}
