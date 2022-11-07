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

   
}
