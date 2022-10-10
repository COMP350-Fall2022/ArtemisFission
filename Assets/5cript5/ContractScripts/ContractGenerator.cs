using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    ContractController controller = new ContractController();
    Contract c;
    string guid;
    float elapsedTime = 0;
    
    //Generate a contract
    public void NewContract()
    {
        Debug.Log("Contract coming up");

        guid = controller.CreateNewContract("Contract " + Random.Range(0, 11), Random.Range(100.0f, 200.0f), 0, Random.Range(100,1001), Random.Range(0, 3));
    }

    //Progress contract once an employee is assigned and once complete give award and destroy object
    public void ContractProgression(Contract c)
    {
        if (c.GetAssignedWorkers() > 0)
        {
            Debug.Log("Contract Progressing");
            Debug.Log("Elapsed Time: " + elapsedTime);
            elapsedTime +=  10 * Time.deltaTime;

            if (c.GetTime() <= elapsedTime)
            {
                Debug.Log("CONGRATULATIONS! Awarded: " + guid.ElementAt(4));
                Destroy(this);
            }
        }

        if (c.GetAssignedWorkers() <= 0)
        {
            Debug.Log("No Progress");
        }
    }

    void Start()
    {
        NewContract();
        controller.LogContract(guid);
        c = controller.GetContract(guid);
    }

    void Update()
    {
        //Add employee to contract when left mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            c.AddAssignedWorkers();
            Debug.Log("Assigned Workers: " + c.GetAssignedWorkers());
        }

        //Remove employee from contract when right mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            c.RemoveAssignedWorkers();
            Debug.Log("Assigned Workers: " + c.GetAssignedWorkers());
        }

        //Check if conract needs to be progressed
        ContractProgression(c);
    }
}