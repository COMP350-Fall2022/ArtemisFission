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
    List<string> assignedEmployees = new List<string>();
    int amountAwarded;
    int contractType;
    List<Part> requiredParts = new List<Part>();
    List<Part> awardedParts = new List<Part>();
    private Guid guid;

<<<<<<< HEAD
    public Contract(string contractName, float totalEffort, int amountAwarded, int contractType)
=======
    public Contract(string contractName, float totalEffort, int amountAwarded, int contractType, List<Part> requiredParts, List<Part> awardedParts)
>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
    {
        this.contractName = contractName;
        this.totalEffort = totalEffort;
        this.amountAwarded = amountAwarded;
        this.contractType = contractType;
        this.guid = Guid.NewGuid();
        this.requiredParts = requiredParts;
        this.awardedParts = awardedParts;

        if (requiredParts != null) {
            this.requiredParts = requiredParts;
        }

        if (awardedParts != null) {
            this.awardedParts = awardedParts;
        }
    }

    public void SetName(string newName)
    {
        this.contractName = newName;
    }

    public string GetName()
    {
        return this.contractName;
    }

    public float GetTotalEffort()
    {
        return this.totalEffort;
    }

    public float GetCompletedWork() {
        return this.completedWork;
    }

    public int GetAward()
    {
        return this.amountAwarded;
    }

    public int GetContractType()
    {
        return this.contractType;
    }

    public string GetGuid()
    {
        return this.guid.ToString();
    }

<<<<<<< HEAD
=======
    public List<Part> GetRequiredParts() {
        return this.requiredParts;
    }

    public bool HasRequiredParts() {
        if (this.requiredParts != null && this.requiredParts.Count > 0) {
            return true;
        } else {
            return false;
        }
    }

    public List<Part> GetAwardedParts() {
        return this.awardedParts;
    }

>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
    public List<string> GetAssignedEmployees() {
        return assignedEmployees;
    }

    public bool AssignEmployee(string e) {
        if (!assignedEmployees.Contains(e)) {
            assignedEmployees.Add(e);
            return true;

        } else {
            return false;
        }
    }

    public bool UnassignEmployee(string e) {
        if (assignedEmployees.Contains(e)) {
            assignedEmployees.Remove(e);
            Debug.Log("Unassigned " + e + " from " + contractName);
            return true;
        } else {
            Debug.Log(e + " NOT IN " + contractName);
            return false;
        }
    }

    public void UnassignAllEmployees() {
        assignedEmployees.Clear();
    }

    public void IncrementWork(float work)
<<<<<<< HEAD
    {
        completedWork += work;
=======
    {        
        if (completedWork + work >= totalEffort) {
            completedWork = totalEffort;
        } else {
            completedWork += work;
        }
>>>>>>> 354c3481a3e0e547ccce215bd079a68d7db0436b
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

