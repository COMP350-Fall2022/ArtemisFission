using UnityEngine;

public class ContractButton : MonoBehaviour
{
    ContractController controller = new ContractController();

    public void NewContract()
    {
        Debug.Log("Contract coming up");
        int contractType = Random.Range(0, 3);

        Contract c = controller.CreateNewContract("Contract " + Random.Range(0, 11), Random.Range(100.0f, 1000.0f), 0, Random.Range(100,1001), contractType);

        Debug.Log("Contract Name: " + c.GetName());
        Debug.Log("Time To Complete: " + c.GetTime());
        Debug.Log("Assigned Workers: " + c.GetAssignedWorkers());
        Debug.Log("Amount Awarded: " + c.GetAward());
        Debug.Log("Contract Type: " + c.GetContractType());
    }

    void Start()
    {
        NewContract();
    }

    void Update()
    {
        
    }
}