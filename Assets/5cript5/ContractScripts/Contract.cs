//Contract Object
using System;

public class Contract
{
    internal string contractName;
    float timeToComplete;
    int assignedWorkers;
    int amountAwarded;
    int contractType;
    private Guid guid;

    public Contract(string contractName, float timeToComplete, int assignedWorkers, int amountAwarded, int contractType)
    {
        this.contractName = contractName;
        this.timeToComplete = timeToComplete;
        this.assignedWorkers = assignedWorkers;
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

    //add assigned workers
    public void AddAssignedWorkers()
    {
        this.assignedWorkers += 1;
    }

    //remove assigned workers
    public void RemoveAssignedWorkers()
    {
        this.assignedWorkers -= 1;
    }

    //get assigned workers
    public int GetAssignedWorkers()
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

