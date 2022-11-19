using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayMoney;
    public TextMeshProUGUI displayMorale;
    public TextMeshProUGUI displayParts;

    private Resources GameResources;

    // Start is called before the first frame update
    void Start()
    {

        GameResources.SetMoney(500000f);
        GameResources.SetPartAmount("Tools", 0);
        displayMorale.text = "Morale: " + FormatValue(GetMorale(GameResources.GetAllEmployeesMorale()));
    }

    // Update is called once per frame
    void Update()
    {
        displayMoney.text = "Money: $" + FormatValue(GameResources.GetMoney());
        displayMorale.text = "Morale: " + FormatValue(GetMorale(GameResources.GetAllEmployeesMorale()));
        displayParts.text = "Parts: " + FormatValue(GameResources.GetPartAmount("Tools"));
    }

    string FormatValue (float value){
        return value.ToString ();
    }

    float GetMorale (Dictionary<string, float> moraleInput){
        Dictionary<string, float>.ValueCollection moraleDict = moraleInput.Values;
        float totalMorale = 0f;
        foreach(float val in moraleDict){
            totalMorale += val;
        }
        return totalMorale;
    }
}
