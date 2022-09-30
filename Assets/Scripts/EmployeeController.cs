using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour
{
    // Start is called before the first frame update

    List<Employee> employees = new List<Employee>();

    public void createNewEmployee() {
        employees.Add(new Employee());
    }

    public void logAllEmployees() {
        Debug.Log(employees.Count);
        for (int i = 0; i < employees.Count; i++) {
            Debug.Log(employees[i].employeeName);
        }
    }
}
