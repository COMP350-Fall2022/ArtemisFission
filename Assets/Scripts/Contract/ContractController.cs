using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ContractController
{
    Dictionary<string, Contract> contracts;

    EmployeeController employeeController;

    public ContractController(EmployeeController employeeController)
    {
        contracts = new Dictionary<string, Contract>();
        this.employeeController = employeeController;
    }

    public string CreateNewContract(string contractName, float totalEffort, int amountAwarded, int contractType)
    {
        Contract c = new Contract(contractName, totalEffort, amountAwarded, contractType);
        contracts.Add(c.GetGuid(), c);
        return c.GetGuid();
    }

    public void RemoveContract(string guid)
    {
        contracts.Remove(guid);
    }

    public Contract GetContract(string guid)
    {
        return contracts[guid];
    }

    public List<Contract> GetAllContracts()
    {
        return contracts.Values.ToList();
    }

    public int GetContractCount()
    {
        return contracts.Count;
    }

    public void AssignEmployee(string contractGuid, string employeeGuid) {
        Contract c = GetContract(contractGuid);
        c.AssignEmployee(employeeGuid);
        employeeController.AssignEmployee(employeeGuid);

    }

    public void UnassignEmployee(string contractGuid, string employeeGuid) {
        Contract c = GetContract(contractGuid);
        c.UnassignEmployee(employeeGuid);
        employeeController.UnassignEmployee(employeeGuid);
    }

    public List<string> GetContractEmployees(string contractGuid) {
        Contract c = GetContract(contractGuid);
        return c.GetAssignedEmployees();
    }

    public List<Contract> GetActiveContracts() {
        return contracts.Values.ToList().FindAll(c => c.GetAssignedEmployees().Count > 0);
    }

    public List<Contract> GetInactiveContracts() {
        return contracts.Values.ToList().FindAll(c => c.GetAssignedEmployees().Count == 0);
    }

    public void LogContract(string guid)
    {
        Contract c = contracts[guid];

        Debug.Log("Contract Name: " + c.GetName());
        Debug.Log("Contract Time to Complete: " + c.GetTotalEffort());
        Debug.Log("Assigned Employees: " + c.GetAssignedEmployees());
        Debug.Log("Award: " + c.GetAward());
        Debug.Log("Contract Type: " + c.GetContractType());
    }

    //Prints all contracts to console
    public void LogAllContracts()
    {
        foreach(KeyValuePair<string, Contract> entry in contracts)
        {
            Debug.Log("Contract Name: " + entry.Value.GetName());
            Debug.Log("Contract Time to Complete: " + entry.Value.GetTotalEffort());
            Debug.Log("Assigned Employees: " + entry.Value.GetAssignedEmployees());
            Debug.Log("Award: " + entry.Value.GetAward());
            Debug.Log("Contract Type: " + entry.Value.GetContractType());
        }
    }

    // -----------------------------------------------------------------------------------------------------
    public List<Employee> GetAllEmployees() {
        return employeeController.GetEmployees();
    }

    public List<Employee> GetInactiveEmployees() {
        return employeeController.GetInactiveEmployees();
    }

    public List<Employee> GetActiveEmployees() {
        return employeeController.GetActiveEmployees();
    }

    public DateTime timeOfLastTick = DateTime.Now;
    public int TICK_THRESHOLD = 100000;

    public void Tick()
    {
        if (DateTime.Now.Ticks - timeOfLastTick.Ticks >= TICK_THRESHOLD) {
            // Debug.Log("Ticking");
            foreach (KeyValuePair<string, Contract> entry in contracts) 
            {
                // if (entry.Value.IsActive()) {
                //     entry.Value.IncrementWork(entry.Value.GetAmountOfAssignedWorkers());
                //     // subtract money for every worker we find
                // }

                // if (entry.Value.IsComplete()) {
                //     entry.Value.RemoveWorkers();
                // }
            }
            timeOfLastTick = DateTime.Now;
        }
    }
}