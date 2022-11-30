using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

// A class to control and coordinate events between controllers and the UI
public class GameController : MonoBehaviour
{
    private EmployeeController employeeController = new EmployeeController(10);
    public ContractController contractController;
    public DateTime globalTime = new DateTime();
    public bool paused = false;
    public TextMeshProUGUI displayMoney;

    private Resources GameResources = new Resources();
    private int TicCount = 0;
    private float GameMoney = 0;
    public bool storeOpened = false;
    public bool speed = false;

    public GameObject popupPrefab;

    void Start() {
        contractController = new ContractController(employeeController);

        Part tier2Part = contractController.CreatePart("Tier 2", false);
        Part tier3Part = contractController.CreatePart("Tier 3", false);

        contractController.CreateNewContract("Thruster", 500, 10, 1, null, new List<Part>{tier2Part});
        contractController.CreateNewContract("R&D", 50000, 10, 1, new List<Part>{tier2Part}, new List<Part>{tier3Part});
        contractController.CreateNewContract("MatSci", 100, 10, 1, new List<Part>{tier3Part}, null);
        contractController.CreateNewContract("4", 100, 10, 1);
        contractController.CreateNewContract("5", 100, 10, 1);
        contractController.CreateNewContract("6", 100, 10, 1);
        contractController.CreateNewContract("7", 100, 10, 1);
        contractController.CreateNewContract("8", 100, 10, 1);
        contractController.CreateNewContract("9", 100, 10, 1);

        employeeController.CreateNewEmployee("Andrew", 10000, null, false);
        employeeController.CreateNewEmployee("Frances", 10000, null, false);
        employeeController.CreateNewEmployee("Alex", 10000, null, false);
        employeeController.CreateNewEmployee("John", 10000, null, false);

        GameResources.SetMoney(500000f);
        GameResources.SetPartAmount("Tools", 0);
        
        displayMoney.text = "Resources:\nMoney: $" + FormatValue(GameResources.GetMoney()) +
                            "\nMorale: " + FormatValue (GetTotalMorale(GameResources.GetAllEmployeesMorale())) + 
                            "\nParts: " + FormatValue(GameResources.GetPartAmount("Tools"));
    }

    // Update is called once per frame
    void Update()
    {
        // handle tick behavior right here
        if(Input.GetKeyDown(KeyCode.C))
        {
            speed = !speed;
        }

        if (speed)
        {
            Debug.Log("Change Speed");
            {
                this.globalTime = this.globalTime.AddDays(0.002);
            }
        } else {
            this.globalTime = this.globalTime.AddTicks(1000);
        }
        
        if (!PausePressed())
        {
            contractController.Tick();
            TicCount++;
        }
        if (TicCount % 5000 == 0){
            GameMoney = GameResources.GetMoney();
            GameMoney = GameMoney - GetAllEmployeesSalary(employeeController.GetEmployees());
            GameResources.SetMoney(GameMoney);
            Debug.Log("GameMoney" + GameMoney.ToString() + "TicCount: " + TicCount.ToString());

        }
        displayMoney.text = "Resources:\nMoney: $" + FormatValue(GameResources.GetMoney()) +
                            "\nMorale: " + FormatValue (GetTotalMorale(GameResources.GetAllEmployeesMorale())) + 
                            "\nParts: " + FormatValue(GameResources.GetPartAmount("Tools"));


        if (Input.GetKeyDown(KeyCode.S)) {
            storeOpened = !storeOpened;
        }

        if (storeOpened) {
            Debug.Log("Store Opened");
            popupPrefab.SetActive(true);
            employeeController.HiringSystem();  
        } else {
            Debug.Log("Store Closed");
            popupPrefab.SetActive(false);
        }

        Debug.Log(globalTime);
    }

    bool PausePressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;
        }

        return paused;
    }

    string FormatValue (float value){
        return value.ToString ();
    }

    float GetTotalMorale (Dictionary<string, float> moraleInput){
        if (moraleInput.Count == 0) {
            return 3.6f; //not good not bad either
        }
        Dictionary<string, float>.ValueCollection moraleDict = moraleInput.Values;
        float totalMorale = 0f;
        foreach(float val in moraleDict){
            totalMorale += val;
        }
        return totalMorale;
    }

    float GetAllEmployeesSalary(List <Employee> EmployeeList){
        float TotalSalary = 0;
        foreach (Employee employee in EmployeeList){
            TotalSalary += employee.GetSalary(); 
        }
        Debug.Log(TotalSalary.ToString());
        return TotalSalary;
    }

}
