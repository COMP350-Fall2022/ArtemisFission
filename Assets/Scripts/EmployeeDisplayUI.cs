using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeDisplayUI : MonoBehaviour
{
    public Text nameText = "EmployeeName";
    public Text salaryText = "500,000";
    public Text moraleText = "5";
    public Text speedText "4";
    public Text techText "3"; 
    // Start is called before the first frame update
    void Start()
    {
        //nameText.text = "EmployeeName";
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = "Charon";
        salaryText.text = "200,000";
        moraleText.text = "7";
        speedText.text = "6";
        techText.text =  "5";
    }
}
