using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class to control and coordinate events between controllers and the UI
public class GameController : MonoBehaviour
{
    public EmployeeController employeeController = new EmployeeController(10);
    public ContractController contractController = new ContractController();

    // start
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
    }


    // Update is called once per frame
    void Update()
    {
        // handle tick behavior right here
    }
}
