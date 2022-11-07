using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class StatItemController : MonoBehaviour
{

    public TMP_Text nameText, salaryText, moraleText, speedText, techText;
    public TMP_Dropdown EmployeeSelectDropdown;
    public GameController gameController;
    private List<Stat> stats;
    // Start is called before the first frame update
    void Start()
    {
        EmployeeSelectDropdown.ClearOptions();
    }

    // Called whenever an option is selected
    public void HandleDropdownSelect(int val)
    {
        //Debug.Log(stats[val - 1].name);
        //gameController.contractController.AssignEmployee(contract.GetGuid(), stats[val - 1].GetId());
        EmployeeSelectDropdown.value = val - 1;
    }
}
