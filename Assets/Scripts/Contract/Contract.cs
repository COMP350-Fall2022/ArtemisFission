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
    float elapsedTime;

    private Guid guid;

    public Contract(string contractName, float timeToComplete, List<string> assignedWorkers, int amountAwarded, int contractType, float elapsedTime)
    {
        this.contractName = contractName;
        this.timeToComplete = timeToComplete;
        this.assignedWorkers = assignedWorkers;
        this.amountAwarded = amountAwarded;
        this.contractType = contractType;
        this.elapsedTime = elapsedTime;
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
    public float GetTimeToComplete()
    {
        return this.timeToComplete;
    }

    // Assign workers
    public void AssignWorker(string workerId) {
        this.assignedWorkers.Add(workerId);
    }

    // Remove workers from being assigned
    public bool UnassignWorker(string workerId) {
        return this.assignedWorkers.Remove(workerId);

    }

    //Remove all workers from contract
    public void RemoveWorkers()
    {
        this.assignedWorkers.Clear();
    }

    //get assigned workers
    public List<string> GetAssignedWorkers()
    {
        return this.assignedWorkers;
    }

    //get amount of assigned workers
    public int GetAmountOfAssignedWorkers()
    {
        return this.assignedWorkers.Count;
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

    //set elapsed time
    public void SetElapsedTime()
    {
        this.elapsedTime = elapsedTime + (Time.deltaTime * assignedWorkers.Count);
    }

    //get elapsed time
    public float GetElapsedTime()
    {
        return this.elapsedTime;
    }
}

