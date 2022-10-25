using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ListController : MonoBehaviour
{

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    public GameController gameController;
    private List<Contract> prevContracts;
    private List<Contract> contracts;

    // Start is called before the first frame update
    void Start()
    {

        Thread.Sleep(1000);

        contracts = gameController.contractController.GetAllContracts();
        foreach (Contract contract in contracts)
        {
            GameObject newContract = Instantiate(ListItemPrefab) as GameObject;
            ListItemController controller = newContract.GetComponent<ListItemController>();
            controller.Name.text = contract.GetName();
            controller.Description.text = contract.GetGuid();
            newContract.transform.parent = ContentPanel.transform;
        }
    }

    void Update() {
        // compare
        if (contracts.Count != gameController.contractController.GetContractCount()) {
            prevContracts = contracts;
            contracts = gameController.contractController.GetAllContracts();
            foreach (Contract contract in contracts) {
                if (!prevContracts.Contains(contract)) {
                    GameObject newContract = Instantiate(ListItemPrefab) as GameObject;
                    ListItemController controller = newContract.GetComponent<ListItemController>();
                    controller.Name.text = contract.GetName();
                    controller.Description.text = contract.GetGuid();
                    newContract.transform.parent = ContentPanel.transform;
                }
            }
        }
    }
}
