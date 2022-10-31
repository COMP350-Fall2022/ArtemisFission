using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ContractController
{
    Dictionary<string, Contract> contracts;

    public ContractController()
    {
        contracts = new Dictionary<string, Contract>();
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

    public bool AssignEmployee(string contractGuid, string employeeGuid) {
        Contract c = GetContract(contractGuid);
        if (!c.IsComplete()) {
            // TODO: We want to check with the employee controller if the ID actually exists in the future?
            c.AssignWorker(employeeGuid);
            return true;
        }
        return false;
    }

    public bool RemoveEmployee(string contractGuid, string employeeGuid) {
        Contract c = GetContract(contractGuid);
        if (c.GetAmountOfAssignedWorkers() > 0) {
            return c.UnassignWorker(employeeGuid);
        }
        return false;
    }

    public void LogContract(string guid)
    {
        Contract c = contracts[guid];

        Debug.Log("Contract Name: " + c.GetName());
        Debug.Log("Contract Time to Complete: " + c.GetTotalEffort());
        Debug.Log("Assigned Workers: " + c.GetAssignedWorkers());
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
            Debug.Log("Assigned Workers: " + entry.Value.GetAssignedWorkers());
            Debug.Log("Award: " + entry.Value.GetAward());
            Debug.Log("Contract Type: " + entry.Value.GetContractType());
        }
    }

    public DateTime timeOfLastTick = DateTime.Now;
    public int TICK_THRESHOLD = 100000;

    public void Tick()
    {
        if (DateTime.Now.Ticks - timeOfLastTick.Ticks >= TICK_THRESHOLD) {
            Debug.Log("Ticking");
            foreach (KeyValuePair<string, Contract> entry in contracts) 
            {
                if (entry.Value.IsActive()) {
                    entry.Value.IncrementWork(entry.Value.GetAmountOfAssignedWorkers());
                    // subtract money for every worker we find
                }

                if (entry.Value.IsComplete()) {
                    entry.Value.RemoveWorkers();
                }
            }
            timeOfLastTick = DateTime.Now;
        }
    }
}