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
    }

    // Updates if any new users are added
    void Update() {
        if (gameController.contractController != null) {
            AssignedEmployees.text = "";
            if (Id.text != null && Id.text != "Id Field") {
                List<string> contractEmployeeIds = gameController.contractController.GetContractEmployees(Id.text);
                foreach (var e in contractEmployeeIds) {
                    AssignedEmployees.text += ( gameController.contractController.GetEmployeeFromId(e).name + "\n" );
                }
            }

            if (contract != null) {
                ContractProgress.text = contract.GetCompletedWork() + " / " + contract.GetTotalEffort();
            }

            EmployeeSelectDropdown.ClearOptions();
            employees = gameController.contractController.GetAllEmployees();
            List<string> dropdownItems = new List<string>();
            foreach (var item in employees)
            {
                dropdownItems.Add(item.name);
            }
            List<Employee> activeEmployees = gameController.contractController.GetActiveEmployees();

            foreach (var e in employees)
            {
                if (activeEmployees.Contains(e)) {
                    EmployeeSelectDropdown.options.Add(new TMP_Dropdown.OptionData() {text = e.name + " (busy)"});
                } else {
                    EmployeeSelectDropdown.options.Add(new TMP_Dropdown.OptionData() {text = e.name});
                }
            }

            // EmployeeSelectDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(EmployeeSelectDropdown);});
        }
    }

    // public void DropdownItemSelected(TMP_Dropdown dropdown) {
    //     int index = dropdown.value;
    //     Debug.Log("SELECT:" + dropdown.options[index].text);

    //     EmployeeSelectLabel.text = dropdown.options[index].text;
    // }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(employees[val].name);
        gameController.contractController.AssignEmployee(Id.text, employees[val].GetId());
        EmployeeSelectDropdown.value = val;
        // EmployeeSelectLabel.text = employees[val].name;
        
        // gameController.BroadcastMessage("RefreshContract", Id.text);
    }

    // public void OnDropdownSelect(TMP_Text id) {
    //     gameController.contractController.AssignEmployee(contractGuid, id)
    // }
}