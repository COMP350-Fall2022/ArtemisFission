using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class EmployeeStatController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI salaryText;
    public TextMeshProUGUI moraleText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI techText;

    // Start is called before the first frame update
    void Start()
    {
      
        nameText.text = "Frances";
        salaryText.text = "500,000";
        moraleText.text = "5";
        speedText.text = "4";
        techText.text = "3";
    }
}
