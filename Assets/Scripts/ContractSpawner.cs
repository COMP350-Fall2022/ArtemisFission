using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractSpawner : MonoBehaviour
{
    public GameObject prefab;
    // public ContractController cc;
    // Start is called before the first frame update
    private List<Contract> contracts = new List<Contract>();
    void Start()
    {
        // contracts = cc.GetAllContracts;
        Debug.Log("Spawner Started");
        contracts.Add(new Contract("contract1", 19, 100, 0));
        var newTransform = transform;
        
        GameObject contract = Instantiate(prefab, newTransform.position, Quaternion.identity);
    }

}
