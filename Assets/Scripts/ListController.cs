using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ListController : MonoBehaviour
{

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    public GameController gameController;
    private List<Contract> prevContracts = new List<Contract>();
    private List<Contract> contracts = null;
    private Dictionary<string, GameObject> contractObjects = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        if (gameController.contractController != null) {
            contracts = gameController.contractController.GetAllContracts();
            // foreach (var item in gameController.employeeController.GetAvaliableEmployees())
            // {
            //     Debug.Log(item.name);
            // }
            // Debug.Log(string.Join("\n", gameController.employeeController.GetAvaliableEmployees()));
        }

        // compare
        if (contracts != null && !contracts.Equals(prevContracts)) {
            foreach (Contract contract in contracts) {
                if (!prevContracts.Contains(contract)) {
                    GameObject newContract = Instantiate(ListItemPrefab) as GameObject;
                    contractObjects.Add(contract.GetGuid(), newContract);
                    ListItemController controller = newContract.GetComponent<ListItemController>();
                    controller.Name.text = contract.GetName();
                    controller.Id.text = contract.GetGuid();
                    controller.AssignedEmployees.text = string.Join("\n", contract.GetAssignedEmployees());
                    controller.ContractProgress.text = contract.GetCompletedWork() + " / " + contract.GetTotalEffort();
                    controller.RequiredParts.text = "Placeholder";
                    newContract.transform.SetParent(ContentPanel.transform, false);
                    // Debug.Log(gameController.employeeController.GetEmployeeCount());
                    // TODO: ensure that we use this instead of the other method. We don't need to expost the game controller to the list display component
                    // controller.employees = gameController.employeeController.GetAvaliableEmployees();
                }
            }
            foreach(Contract p in prevContracts) {
                if(!contracts.Contains(p)) {
                    contractObjects.Remove(p.GetGuid());
                }
            }
            prevContracts = contracts;
        }
    }
}
