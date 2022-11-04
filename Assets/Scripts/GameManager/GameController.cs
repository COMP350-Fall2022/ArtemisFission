using UnityEngine;
using System;

// A class to control and coordinate events between controllers and the UI
public class GameController : MonoBehaviour
{
    public EmployeeController employeeController = new EmployeeController(10);
    public ContractController contractController = new ContractController();
    public DateTime globalTime = new DateTime();
    public bool paused = false;

    void Start() {
        contractController.CreateNewContract("Contract1", 100, 10, 1);
        contractController.CreateNewContract("Contract2", 100, 10, 1);
        contractController.CreateNewContract("Contract3", 100, 10, 1);
        contractController.CreateNewContract("Contract4", 100, 10, 1);
        contractController.CreateNewContract("Contract5", 100, 10, 1);
        contractController.CreateNewContract("Contract6", 100, 10, 1);
        contractController.CreateNewContract("Contract7", 100, 10, 1);
        contractController.CreateNewContract("Contract8", 100, 10, 1);
        contractController.CreateNewContract("Contract9", 100, 10, 1);

        employeeController.CreateNewEmployee("Andrew Graves", 10000, null);
        employeeController.CreateNewEmployee("Andrew Graves2", 10000, null);
        employeeController.CreateNewEmployee("Andrew Graves3", 10000, null);
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
    }

    bool PausePressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("paused");
            paused = !paused;
        }

        Debug.Log("paused = " + paused);
        return paused;
    }
}
