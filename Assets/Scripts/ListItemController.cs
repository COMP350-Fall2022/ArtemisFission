using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListItemController : MonoBehaviour
{
    public TMP_Text Name, Description;
    public TMP_Dropdown AssignedEmployee;
    public GameController gameController;
    private List<TMP_Dropdown.OptionData> optionData;
    private List<Employee> employees;

    void Start() {
        employees = gameController.employeeController.GetEmployees();
        AssignedEmployee.ClearOptions();
        foreach (Employee item in employees)
        {
            AssignedEmployee.options.Add(new TMP_Dropdown.OptionData() {text = item.GetName()});
        }
    }

    // Updates if any new users are added
    void Update() {
        if (employees.Count != gameController.employeeController.GetEmployeeCount()) {
            employees.Clear();
            employees.AddRange(gameController.employeeController.GetEmployees());
            AssignedEmployee.ClearOptions();
            foreach (Employee item in employees)
            {
                AssignedEmployee.options.Add(new TMP_Dropdown.OptionData() {text = item.GetName()});
            }
        }
    }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(val);
    }
}