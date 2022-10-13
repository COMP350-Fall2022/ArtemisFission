using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    public GameController gc;

    // public ContractController cc;
    private List<Contract> contracts = new List<Contract>();

    // Start is called before the first frame update
    void Start()
    {

        contracts.Add(new Contract("contract1", 19, 100, 0));
        contracts.Add(new Contract("contract2", 20, 100, 0));
        contracts.Add(new Contract("contract3", 22, 100, 0));
        contracts.Add(new Contract("contract4", 15, 100, 0));
        contracts.Add(new Contract("contract5", 15, 100, 0));
        contracts.Add(new Contract("contract6", 15, 100, 0));
        contracts.Add(new Contract("contract7", 15, 100, 0));


        Debug.Log("Contracts added");

        foreach (Contract contract in contracts)
        {
            GameObject newContract = Instantiate(ListItemPrefab) as GameObject;
            ListItemController controller = newContract.GetComponent<ListItemController>();
            controller.Name.text = contract.GetName();
            controller.Description.text = contract.GetGuid();
            newContract.transform.parent = ContentPanel.transform;
            // newContract.transform.localScale = Vector3.one;
        }
    }
}
