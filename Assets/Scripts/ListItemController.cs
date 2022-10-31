using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListItemController : MonoBehaviour
{
    public TMP_Text Name, Id, AssignedEmployees, RequiredParts, ContractProgress;
    public TMP_Dropdown AvaliableEmployees;
    // public TMP_Dropdown AssignedEmployee;
    public GameController gameController;
    private List<TMP_Dropdown.OptionData> optionData;
    private List<Employee> employees;
    private List<Employee> pastEmployees = new List<Employee>();

    void Start() {
        // employees = gameController.employeeController.GetEmployees();
        AvaliableEmployees.ClearOptions();
        // foreach (Employee item in employees)
        // {
        //     AvaliableEmployees.options.Add(new TMP_Dropdown.OptionData() {text = item.GetName()});
        // }
    }

    // Updates if any new users are added
    void Update() {
        if (gameController.employeeController != null) {
            employees = gameController.employeeController.GetAvaliableEmployees();
            Debug.Log("Got " + employees.Count + " Employees");
        }

        if (employees != null && !employees.Equals(pastEmployees)) {
            Debug.Log("Inside the bug boy");
            employees.Clear();
            employees.AddRange(gameController.employeeController.GetEmployees());
            AvaliableEmployees.ClearOptions();
            foreach (Employee item in employees)
            {
                AvaliableEmployees.options.Add(new TMP_Dropdown.OptionData() {text = item.name});
                Debug.Log(item.name);
            }
            pastEmployees = employees;
        }
    }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(val);
        //TODO: This part
    }
}