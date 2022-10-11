using System.Collections.Generic;
using UnityEngine;

//Contract controller
public class ContractController
{
    Dictionary<string, Contract> contracts;

    public ContractController()
    {
        contracts = new Dictionary<string, Contract>();
    }

    //Creates a contract and return string id
    public string CreateNewContract(string contractName, float timeToComplete, int amountAwarded, int contractType)
    {
        Contract c = new Contract(contractName, timeToComplete, amountAwarded, contractType);
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

    // public List<Contract> GetAllContracts()
    // {
    //     return contracts.Values;
    // }

    //Prints a contract to console
    public void LogContract(string guid)
    {
        Contract c = contracts[guid];

        Debug.Log("Contract Name: " + c.GetName());
        Debug.Log("Contract Time: " + c.GetTime());
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
            Debug.Log("Contract Time: " + entry.Value.GetTime());
            Debug.Log("Assigned Workers: " + entry.Value.GetAssignedWorkers());
            Debug.Log("Award: " + entry.Value.GetAward());
            Debug.Log("Contract Type: " + entry.Value.GetContractType());
        }
    }
}