using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ListItemController : MonoBehaviour
{
    public TMP_Text Name, Id, AssignedEmployees, RequiredParts, ContractProgress, EmployeeSelectLabel;
    public TMP_Dropdown EmployeeSelectDropdown;
    public GameController gameController;
    private List<Employee> employees;
    public Contract contract = null;
    void Start() {
        EmployeeSelectDropdown.ClearOptions();
        // EmployeeSelectDropdown.value = -1;
    }

    // Updates if any new users are added
    void Update() {
        if (gameController.contractController != null) {
            AssignedEmployees.text = "";
            if (contract != null) {
                List<string> contractEmployeeIds = gameController.contractController.GetContractEmployees(contract.GetGuid());
                foreach (var e in contractEmployeeIds) {
                    AssignedEmployees.text += ( gameController.contractController.GetEmployeeFromId(e).name + "\n" );
                }
            }

            if (contract != null) {
                ContractProgress.text = contract.GetCompletedWork() + " / " + contract.GetTotalEffort();
            }

            // TODO: Remove this later when we go back after this sprint
            if (EmployeeSelectDropdown != null) {
                EmployeeSelectDropdown.ClearOptions();
                employees = gameController.contractController.GetAllEmployees();
                List<Employee> activeEmployees = gameController.contractController.GetActiveEmployees();

                EmployeeSelectDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "- select an employee -"});
                foreach (var e in employees)
                {
                    if (activeEmployees.Contains(e)) {
                        EmployeeSelectDropdown.options.Add(new TMP_Dropdown.OptionData() {text = e.name + " (busy)"});
                    } else {
                        EmployeeSelectDropdown.options.Add(new TMP_Dropdown.OptionData() {text = e.name});
                    }
                }
                EmployeeSelectDropdown.RefreshShownValue();
            }
        }
    }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(employees[val-1].name);
        gameController.contractController.AssignEmployee(contract.GetGuid(), employees[val-1].GetId());
        EmployeeSelectDropdown.value = val-1;
    }
}