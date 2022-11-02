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
    // private List<TMP_Dropdown.OptionData> optionData;
    private List<Employee> employees;
    // private List<Employee> pastEmployees = new List<Employee>();

    void Start() {
        AvaliableEmployees.ClearOptions();
    }

    // Updates if any new users are added
    void Update() {
        if (gameController.contractController != null) {
            AvaliableEmployees.ClearOptions();
            employees = gameController.contractController.GetAllEmployees();
            // List<Employee> activeEmployees = gameController.contractController.GetActiveEmployees();
            // List<Employee> inactiveEmployees = gameController.contractController.GetInactiveEmployees();


            foreach (Employee item in gameController.contractController.GetActiveEmployees())
            {
                AvaliableEmployees.options.Add(new TMP_Dropdown.OptionData() {text = item.name + "-(busy)"});
            }
            foreach (Employee item in gameController.contractController.GetInactiveEmployees())
            {
                AvaliableEmployees.options.Add(new TMP_Dropdown.OptionData() {text = item.name});
            }
        }
    }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val) {
        Debug.Log(employees[val].name);
        gameController.contractController.AssignEmployee(Id.text, employees[val].GetId());
        // gameController.BroadcastMessage("RefreshContract", Id.text);
        // Debug.Log(employees[val].name);
        // bool tmp = gameController.contractController.AssignEmployee(Id.text, employees[val].GetId());
        // Debug.Log(tmp);
        //TODO: This part
    }

    // public void OnDropdownSelect(TMP_Text id) {
    //     gameController.contractController.AssignEmployee(contractGuid, id)
    // }
}