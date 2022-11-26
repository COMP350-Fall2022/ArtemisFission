using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ContractController
{
    Dictionary<string, Contract> contracts;

    List<Part> unownedParts = new List<Part>();
    List<Part> ownedParts = new List<Part>();

    EmployeeController employeeController;

    public ContractController(EmployeeController employeeController)
    {
        contracts = new Dictionary<string, Contract>();
        this.employeeController = employeeController;
    }

    // --------------------------------
    // Contract Functions
    // --------------------------------
    public string CreateNewContract(string contractName, float totalEffort, int amountAwarded, int contractType, List<Part> requiredParts = null, List<Part> awardedParts = null)
    {
        Contract c = new Contract(contractName, totalEffort, amountAwarded, contractType, requiredParts, awardedParts);
        contracts.Add(c.GetGuid(), c);
        return c.GetGuid();
    }

    public void RemoveContract(string guid)
    {
        contracts.Remove(guid);
    }

    public Contract GetContract(string guid)
    {
        return contracts[guid];
    }

    public List<Contract> GetAllContracts()
    {
        return contracts.Values.ToList();
    }

    public int GetContractCount()
    {
        return contracts.Count;
    }

    public List<Contract> GetActiveContracts() {
        return contracts.Values.ToList().FindAll(c => c.GetAssignedEmployees().Count > 0);
    }

    public List<Contract> GetInactiveContracts() {
        return contracts.Values.ToList().FindAll(c => c.GetAssignedEmployees().Count == 0);
    }

    public void LogContract(string guid)
    {
        Contract c = contracts[guid];

        Debug.Log("Contract Name: " + c.GetName());
        Debug.Log("Contract Time to Complete: " + c.GetTotalEffort());
        Debug.Log("Assigned Employees: " + c.GetAssignedEmployees());
        Debug.Log("Award: " + c.GetAward());
        Debug.Log("Contract Type: " + c.GetContractType());
    }

    //Prints all contracts to console
    public void LogAllContracts()
    {
        foreach(KeyValuePair<string, Contract> entry in contracts)
        {
            Debug.Log("Contract Name: " + entry.Value.GetName());
            Debug.Log("Contract Time to Complete: " + entry.Value.GetTotalEffort());
            Debug.Log("Assigned Employees: " + entry.Value.GetAssignedEmployees());
            Debug.Log("Award: " + entry.Value.GetAward());
            Debug.Log("Contract Type: " + entry.Value.GetContractType());
        }
    }

    // --------------------------------
    // Employee Functions (Passthrough)
    // --------------------------------

    public void AssignEmployee(string contractGuid, string employeeGuid) {
        Contract c = GetContract(contractGuid);
        UnassignEmployee(employeeGuid);
        c.AssignEmployee(employeeGuid);
        employeeController.AssignEmployee(employeeGuid);
    }

    public void UnassignEmployee(string contractGuid, string employeeGuid) {
        Contract c = GetContract(contractGuid);
        c.UnassignEmployee(employeeGuid);
        employeeController.UnassignEmployee(employeeGuid);
    }

    public void UnassignEmployee(string employeeGuid) {
        foreach (Contract c in contracts.Values) {
            if (c.GetAssignedEmployees().Contains(employeeGuid)) {
                c.UnassignEmployee(employeeGuid);
            }
        }
    }

    public List<string> GetContractEmployees(string contractGuid) {
        Contract c = GetContract(contractGuid);
        return c.GetAssignedEmployees();
    }

    public Employee GetEmployeeFromId(string employeeId) {
        return employeeController.GetEmployeeFromId(employeeId);
    }

    public List<Employee> GetAllEmployees() {
        return employeeController.GetEmployees();
    }

    public List<Employee> GetInactiveEmployees() {
        return employeeController.GetInactiveEmployees();
    }

    public List<Employee> GetActiveEmployees() {
        return employeeController.GetActiveEmployees();
    }

    // --------------------------------
    // Part Functions
    // --------------------------------

    public Part CreatePart(string partName, bool isConsumable) {
        Part newPart = new Part(partName, isConsumable);
        unownedParts.Add(newPart);
        return newPart;
    }

    public bool RemovePart(Part part) {
        if (HasPart(part)) {
            return ownedParts.Remove(part);
        } else {
            return false;
        }
    }

    public List<Part> GetOwnedParts() {
        return this.ownedParts;
    }

    public List<Part> GetUnownedParts() {
        return this.unownedParts;
    }

    public bool HasPart(Part part) {
        if (this.ownedParts.Contains(part)) {
            return true;
        } else {
            return false;
        }
    }

    public bool AquirePart(Part part) {
        if (unownedParts.Contains(part)) {
            ownedParts.Add(part);
            unownedParts.Remove(part);
            return true;
        } else {
            return false;
        }
    }

    public bool AwardParts(Contract contract) {
        if (contract.GetAwardedParts() != null) {
            foreach(Part p in contract.GetAwardedParts()) {
                if (!AquirePart(p)) {
                    return false;
                }
            }
        } else {
            return false;
        }

        return true;
    }

    public DateTime timeOfLastTick = DateTime.Now;
    public int TICK_THRESHOLD = 100000;

    public void Tick()
    {
        if (DateTime.Now.Ticks - timeOfLastTick.Ticks >= TICK_THRESHOLD) {
            // Debug.Log("Ticking");
            foreach (KeyValuePair<string, Contract> entry in contracts) 
            {

                //check for required parts
                if (entry.Value.HasRequiredParts()) {
                    foreach (Part p in entry.Value.GetRequiredParts()) {
                        if (!ownedParts.Contains(p)) {
                            foreach (var eId in entry.Value.GetAssignedEmployees())
                            {
                                employeeController.UnassignEmployee(eId);
                            }

                            entry.Value.UnassignAllEmployees();
                        }
                    }
                }

                entry.Value.IncrementWork(entry.Value.GetAssignedEmployees().Count);

                if (entry.Value.IsComplete()) {
                    foreach (var eId in entry.Value.GetAssignedEmployees())
                    {
                        employeeController.UnassignEmployee(eId);
                    }
                    entry.Value.UnassignAllEmployees();

                    if (entry.Value.HasRequiredParts()) {
                        foreach(Part p in entry.Value.GetRequiredParts()) {
                            if (p.isConsumable) {
                                RemovePart(p);
                            }
                        }
                    }
                    AwardParts(entry.Value);
                }
            }
            timeOfLastTick = DateTime.Now;
        }
    }
}