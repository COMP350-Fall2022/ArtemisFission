using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ListItemController : MonoBehaviour
{
<<<<<<< HEAD
    public TMP_Text Name, Id, AssignedEmployees, RequiredParts, ContractProgress, EmployeeSelectLabel;
=======
    public TMP_Text Name, Id, AssignedEmployees, RequiredParts, ContractProgress, EmployeeSelectLabel, AwardedParts;
>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
    public TMP_Dropdown EmployeeSelectDropdown;
    public GameController gameController;
    private List<Employee> employees;
    public Contract contract = null;
    void Start() {
        EmployeeSelectDropdown.ClearOptions();
<<<<<<< HEAD
=======

        EmployeeSelectDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(EmployeeSelectDropdown);
        });
>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
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
<<<<<<< HEAD
            }

            if (contract != null) {
                ContractProgress.text = contract.GetCompletedWork() + " / " + contract.GetTotalEffort();
=======

                ContractProgress.text = contract.GetCompletedWork() + " / " + contract.GetTotalEffort();

                if (RequiredParts != null && contract.GetRequiredParts() != null && contract.GetRequiredParts().Count > 0) {
                    RequiredParts.text = "";
                    foreach(Part part in contract.GetRequiredParts()) {
                        if (gameController.contractController.HasPart(part)) {
                            RequiredParts.text += "(Y) - ";
                        } else {
                            RequiredParts.text += "(N) - ";
                        }
                        RequiredParts.text += part.partName + "\n";
                    }
                }

                if (AwardedParts != null && contract.GetAwardedParts() != null && contract.GetAwardedParts().Count > 0) {
                    AwardedParts.text = "";

                    foreach(Part part in contract.GetAwardedParts()) {
                        AwardedParts.text += part.partName + "\n";
                    }
                }
>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
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

<<<<<<< HEAD
    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(employees[val-1].name);
        gameController.contractController.AssignEmployee(contract.GetGuid(), employees[val-1].GetId());
        EmployeeSelectDropdown.value = val-1;
=======
    public void DropdownValueChanged(TMP_Dropdown dropdown) {
        Debug.Log("CALLED: " + dropdown.value + " from " + contract.contractName);
        gameController.contractController.AssignEmployee(contract.GetGuid(), employees[dropdown.value-1].GetId());
        // EmployeeSelectDropdown.value = dropdown.value-1;
>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
    }
}