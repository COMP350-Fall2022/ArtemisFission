using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

// A class to control and coordinate events between controllers and the UI
public class GameController : MonoBehaviour
{
    private EmployeeController employeeController = new EmployeeController(10);
    public ContractController contractController;
    public DateTime globalTime = new DateTime();
    public bool paused = false;
    public bool storeOpened = false;

    public GameObject popupPrefab;

    void Start() {
        contractController = new ContractController(employeeController);

        Part tier2Part = contractController.CreatePart("Tier 2", false);
        Part tier3Part = contractController.CreatePart("Tier 3", false);

        contractController.CreateNewContract("Thruster", 500, 10, 1, null, new List<Part>{tier2Part});
        contractController.CreateNewContract("R&D", 500, 10, 1, new List<Part>{tier2Part}, new List<Part>{tier3Part});
        contractController.CreateNewContract("MatSci", 100, 10, 1, new List<Part>{tier3Part}, null);
        contractController.CreateNewContract("4", 100, 10, 1);
        contractController.CreateNewContract("5", 100, 10, 1);
        contractController.CreateNewContract("6", 100, 10, 1);
        contractController.CreateNewContract("7", 100, 10, 1);
        contractController.CreateNewContract("8", 100, 10, 1);
        contractController.CreateNewContract("9", 100, 10, 1);

        employeeController.CreateNewEmployee("Andrew", 10000, null);
        employeeController.CreateNewEmployee("Frances", 10000, null);
        employeeController.CreateNewEmployee("Alex", 10000, null);
        employeeController.CreateNewEmployee("John", 10000, null);
    }

    // Update is called once per frame
    void Update()
    {
        // handle tick behavior right here
        this.globalTime = this.globalTime.AddTicks(1000);
        
        if (!PausePressed())
        {
            contractController.Tick();
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            storeOpened = !storeOpened;
        }

        if (storeOpened) {
            Debug.Log("Store Opened");
            popupPrefab.SetActive(true);
        } else {
            Debug.Log("Store Closed");
            popupPrefab.SetActive(false);
        }
    }

    bool PausePressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("paused");
            paused = !paused;
        }

        // Debug.Log("paused = " + paused);
        return paused;
    }
}
