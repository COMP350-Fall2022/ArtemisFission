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
        if (gameController.employeeController != null && gameController.contractController != null) {
            employees = gameController.employeeController.GetAvaliableEmployees();
            // foreach (var employeeId in gameController.contractController.GetContractEmployees(Id.text))
            // {
            //     employees.Add(gameController.employeeController.GetEmployee(employeeId));
            // }
            // Debug.Log("Got " + employees.Count + " Employees");
        }

        if (employees != null && !employees.Equals(pastEmployees)) {
            // employees.Clear();
            // employees.AddRange(gameController.employeeController.GetEmployees());
            AvaliableEmployees.ClearOptions();
            foreach (Employee item in employees)
            {
                AvaliableEmployees.options.Add(new TMP_Dropdown.OptionData() {text = item.name});
                // TODO: Figure out why this is looping when we set a condition in the begining
                // Debug.Log(item.name);
            }
            pastEmployees = employees;
        }
    }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(val);
        Debug.Log(employees[val].name);
        bool tmp = gameController.contractController.AssignEmployee(Id.text, employees[val].GetId());
        Debug.Log(tmp);
        //TODO: This part
    }
}