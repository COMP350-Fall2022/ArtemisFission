using System.Collections.Generic;
using UnityEngine;

//Contract controller
public class ContractController
{
    List<Contract> contracts;

    public ContractController()
    {
        this.contracts = new List<Contract>();
    }

    // Creates a contract and returns a pointer to it
    public Contract CreateNewContract(string contractName, float timeToComplete, int amountAwarded, int contractType)
    {
        Contract c = new Contract(contractName, timeToComplete, amountAwarded, contractType);
        contracts.Add(c); 
        return c;
    }

    public void LogAllContracts()
    {
        Debug.Log(contracts.Count);
        for (int i = 0; i < contracts.Count; i++)
        {
            Debug.Log(contracts[i].contractName);
        }
    }
}