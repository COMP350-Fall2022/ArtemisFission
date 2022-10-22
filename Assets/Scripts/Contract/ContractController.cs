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
    public string CreateNewContract(string contractName, float timeToComplete, List<string> assignedWorkers, int amountAwarded, int contractType, float elapsedTime)
    {
        Contract c = new Contract(contractName, timeToComplete, assignedWorkers, amountAwarded, contractType, elapsedTime);
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
        Debug.Log("Contract Time to Complete: " + c.GetTimeToComplete());
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
            Debug.Log("Contract Time to Complete: " + entry.Value.GetTimeToComplete());
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
            c.SetElapsedTime();
            Debug.Log("progressing" + c.GetElapsedTime());
        }
    }

    //check for contract completion
    public void ContractCompletion(string guid)
    {
        Contract c = contracts[guid];

        if (c.GetTimeToComplete() <= c.GetElapsedTime())
        {
            c.RemoveWorkers();
            Debug.Log("Complete");
        }
    }
}