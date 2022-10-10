using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class to control and coordinate events between controllers and the UI
public class GameController : MonoBehaviour
{
    EmployeeController employeeController = new EmployeeController(10);
    ContractController contractController = new ContractController();

    // Update is called once per frame
    void Update()
    {
        // handle tick behavior right here
    }
}
