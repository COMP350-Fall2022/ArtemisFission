using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI salaryText;
    public TextMeshProUGUI moraleText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI techText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "Charon";
        salaryText.text = "500,000";
        moraleText.text = "5";
        speedText.text = "4";
        techText.text = "3";
    }
}
