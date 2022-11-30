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
            employees = gameController.contractController.GetAllEmployees();
        }

        if (employees != null && !employees.Equals(prevEmployees)) {
            foreach (Employee employee in employees) {
                if (!prevEmployees.Contains(employee) && !contractObjects.ContainsKey(employee.GetId())) {
                    GameObject newContract = Instantiate(ListItemPrefab) as GameObject;
                    contractObjects.Add(employee.GetId(), newContract);
                    EmployeeListItemController controller = newContract.GetComponent<EmployeeListItemController>();
                    controller.Name.text = employee.GetName();
                    controller.Id.text = employee.GetId();
                    newContract.transform.SetParent(ContentPanel.transform, false);
                }

                if (contractObjects.ContainsKey(employee.GetId())) {
                    Debug.Log("Contained Key: " + employee.GetName());
                    GameObject employeeCard = contractObjects[employee.GetId()];
                    if (employeeCard != null) {
                        EmployeeListItemController controller = employeeCard.GetComponent<EmployeeListItemController>();
                        string returnString = "";
                        List<Contract> employeeContracts = gameController.contractController.GetEmployeeContracts(employee.GetId());
                        if (employeeContracts.Count > 0) {
                            foreach (Contract c in employeeContracts) {
                                returnString += c.contractName;
                            }
                            Debug.Log("Return String: " + returnString);
                        }
                        controller.AssignedContracts.text = returnString;
                    }
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
