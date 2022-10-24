using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Contract controller
public class ContractController
{
    Dictionary<string, Contract> contracts;

    public ContractController()
    {
        contracts = new Dictionary<string, Contract>();
    }

    //Creates a contract and return string id
    public string CreateNewContract(string contractName, float totalEffort, List<string> assignedWorkers, int amountAwarded, int contractType)
    {
        Contract c = new Contract(contractName, totalEffort, assignedWorkers, amountAwarded, contractType);
        contracts.Add(c.GetGuid(), c);
        return c.GetGuid();
    }

    //Removes a contract
    public void RemoveContract(string guid)
    {
        contracts.Remove(guid);
    }

    //Return a contract
    public Contract GetContract(string guid)
    {
        return contracts[guid];
    }

    //Return all contracts as a list
    public List<Contract> GetAllContracts()
    {
        return contracts.Values.ToList();
    }

    //Return contract count
    public int GetContractCount()
    {
        return contracts.Count;
    }

    //Prints a contract to console
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

    //progress contract if workers are assigned
    public void ContractProgression(string guid)
    {
        Contract c = contracts[guid];

        if (c.GetAssignedWorkers() != null)
        {
            float effort = 1 * (c.GetAmountOfAssignedWorkers());
            c.SetTotalEffort(effort);
            Debug.Log("progressing" + c.GetTotalEffort());
        }
    }

    //check for contract completion
    public void ContractCompletion(string guid)
    {
        Contract c = contracts[guid];

        if (c.GetTotalEffort() <= 0)
        {
            c.RemoveWorkers();
            Debug.Log("Complete");
        }
    }
}