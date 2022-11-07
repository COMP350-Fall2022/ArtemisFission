using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class StatListController : MonoBehaviour
{

    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    public GameController gameController;
    private List<Stat> prevStats = new List<Stat>();
    private List<Stat> stats = null;
    private Dictionary<string, GameObject> contractObjects = new Dictionary<string, GameObject>();



    // Start is called before the first frame update
   /* void Start()
    {
      
    }*/

    /*void Update()
    {
        if (gameController.contractController != null)
        {
            
        }
    }*/
}
