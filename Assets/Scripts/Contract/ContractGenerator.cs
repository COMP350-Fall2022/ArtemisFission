using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ContractGenerator : MonoBehaviour
{
    ContractController controller = new ContractController();
    string guid;
    List<string> workers = new List<string>()
    {
        "Alex",
        "Andrew",
        "Frances",
        "John"
    };


    //Generate a contract
    public void NewContract()
    {
        Debug.Log("Contract coming up");
        guid = controller.CreateNewContract("Contract " + Random.Range(0, 11), Random.Range(100.0f, 200.0f), workers, 0, Random.Range(0, 3));
        controller.LogContract(guid);
    }

    void Start()
    {
        NewContract();
    }
    void Update()
    {
        controller.ContractProgression(guid);
        controller.ContractCompletion(guid);
    }
}