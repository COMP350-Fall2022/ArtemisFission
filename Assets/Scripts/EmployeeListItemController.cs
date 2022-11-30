using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class EmployeeListItemController : MonoBehaviour
{
    public TMP_Text Name, Id, AssignedContracts;
    public GameController gameController;
    private List<Employee> employees;
    public Employee employee = null;
    void Start() {
        // EmployeeSelectDropdown.value = -1;
    }

    // Updates if any new users are added
    void Update() {
        if (gameController.contractController != null) {
            if (employee != null) {

            }
        }
    }
}