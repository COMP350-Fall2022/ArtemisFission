//Contract Object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;


public class Contract
{
    internal string contractName;
    float timeToComplete;
    List<string> assignedWorkers;
    int amountAwarded;
    int contractType;

    private Guid guid;
    
    public Contract(string contractName, float timeToComplete, int amountAwarded, int contractType)
    {
        this.contractName = contractName;
        this.timeToComplete = timeToComplete;
        this.amountAwarded = amountAwarded;
        this.contractType = contractType;
        this.guid = Guid.NewGuid();
    }

    //Change name of contract
    public void SetName(string newName)
    {
        this.contractName = newName;
    }

    //Get name of contract
    public string GetName()
    {
        return this.contractName;
    }
  
    //Get time to complete
    public float GetTime()
    {
        return this.timeToComplete;
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
        return this.assignedWorkers;
    }

    //get amount awarded
    public int GetAward()
    {
        return this.amountAwarded;
    }

    //get contract type
    public int GetContractType()
    {
        return this.contractType;
    }

    //get guid as string
    public string GetGuid()
    {
        return this.guid.ToString();
    }
}

