using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contract Object
public class Contract
{
    internal string contractName;
    float timeToComplete;
    List<string> assignedWorkers;
    int amountAwarded;
    int contractType;
    
    public Contract(string contractName, float timeToComplete, int amountAwarded, int contractType)
    {
        this.contractName = contractName;
        this.timeToComplete = timeToComplete;
        this.amountAwarded = amountAwarded;
        this.contractType = contractType;
    }

    //Change name of contract
    public void ChangeName(string newName)
    {
        contractName = newName;
    }

    //Get name of contract
    public string GetName()
    {
        return contractName;
    }
  
    //Get time to complete
    public float GetTime()
    {
        return timeToComplete;
    }

    // Assign workers
    public void AssignWorker(string workerId) {
        assignedWorkers.Add(workerId);
    }

    // Remove workers from being assigned
    public bool UnassignWorker(string workerId) {
        return assignedWorkers.Remove(workerId);
    }

    //get assigned workers
    public List<string> GetAssignedWorkers()
    {
        return assignedWorkers;
    }

    //get amount awarded
    public int GetAward()
    {
        return amountAwarded;
    }

    //get contract type
    public int GetContractType()
    {
        return contractType;
    }
}

