using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class EmployeeListController : MonoBehaviour
{

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    public GameController gameController;
    private List<Employee> prevEmployees = new List<Employee>();
    private List<Employee> employees = null;
    private Dictionary<string, GameObject> contractObjects = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        if (gameController.contractController != null) {
            // contracts = gameController.contractController.GetAllContracts();
            employees = gameController.contractController.GetAllEmployees();
            // employees = gameController.
        }

        if (employees != null && !employees.Equals(prevEmployees)) {
            foreach (Employee employee in employees) {
                if (!prevEmployees.Contains(employee)) {
                    GameObject newContract = Instantiate(ListItemPrefab) as GameObject;
                    // contractObjects.Add(employee.GetGuid(), newContract);
                    ListItemController controller = newContract.GetComponent<ListItemController>();
                    controller.Name.text = employee.GetName();
                    controller.Id.text = employee.GetId();
                    // controller.AssignedEmployees.text = string.Join("\n", employee.GetAssignedEmployees());
                    // controller.ContractProgress.text = employee.GetCompletedWork() + " / " + employee.GetTotalEffort();
                    // controller.RequiredParts.text = "...";
                    // controller.contract = contract;
                    newContract.transform.SetParent(ContentPanel.transform, false);
                }
            }
            foreach(Employee p in prevEmployees) {
                if(!employees.Contains(p)) {
                    contractObjects.Remove(p.GetId());
                }
            }
            prevEmployees = employees;
        }
    }
}
