//Contract Object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class Contract
{
    internal string contractName;
    float totalEffort;
    float completedWork;
    List<string> assignedWorkers = new List<string>();
    int amountAwarded;
    int contractType;

    private Guid guid;

    public Contract(string contractName, float totalEffort, List<string> assignedWorkers, int amountAwarded, int contractType)
    {
        this.contractName = contractName;
        this.totalEffort = totalEffort;
        // TODO: This needs to be addressed. Workers will not be assigned to contracts when they are created so we do not need this.
        // if (assignedWorkers != null) {
        //     this.assignedWorkers = new List<string>();
        // }
        // this.assignedWorkers = assignedWorkers;
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

    //Get total effort
    public float GetTotalEffort()
    {
        return this.totalEffort;
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

    public bool IsActive()
    {
        // Debug.Log("Assigned Workers: " + GetAssignedWorkers().ToString());
        return GetAmountOfAssignedWorkers() > 0;
    }

    public void IncrementWork(float work)
    {
        completedWork += work;
    }

    public bool IsComplete()
    {
        if (completedWork >= totalEffort)
        {
            return true;
        } else {
            return false;
        }
    }
}

