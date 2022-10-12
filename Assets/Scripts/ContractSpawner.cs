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


        // foreach (var item in contracts)
        // {
        //     // Create the game object, add to array with the ID
        // }
        //  ThisButton.GetComponentInChildren(Text).text = "testing";

         // When we create buttons, we need to pass them additional information about the context they exist in.
         // They should return the ID of the contract that was clicked
         // Inorder to return this, we need to link the contractID with the data to the actual type
        
    }

    void onContractClick() {

    }
}
