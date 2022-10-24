using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeDisplayUI : MonoBehaviour
{
    public Text nameText;
    public Text salaryText;
    public Text moraleText;
    public Text speedText;
    public Text techText; 
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "EmployeeName";
        salaryText.text = "500,000";
        moraleText.text = "5";
        speedText.text = "4";
        techText.text = "3";
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
