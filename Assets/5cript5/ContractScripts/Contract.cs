using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contract Object
public class Contract
{
    internal string contractName;
    float timeToComplete;
    int assignedWorkers;
    int amountAwarded;
    int contractType;
    

    public Contract(string contractName, float timeToComplete, int assignedWorkers, int amountAwarded, int contractType)
    {
        this.contractName = contractName;
        this.timeToComplete = timeToComplete;
        this.assignedWorkers = assignedWorkers;
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

    /* //Change time to complete contract
    public void ChangeTime(float newTime)
    {
        timeToComplete = newTime;
    }
    */

    //Get time to complete
    public float GetTime()
    {
        return timeToComplete;
    }

    //Change assigned workers
    public void ChangeAssignedWorkers(int newNumber)
    {
        assignedWorkers = newNumber;
    }

    //get assigned workers
    public int GetAssignedWorkers()
    {
        return assignedWorkers;
    }

    /* //change amount awarded
    public void ChangeAward(int newAward)
    {
        amountAwarded = newAward;
    }
    */

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

