using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

    public Store store1;
    public Store store2;
    public float customerDelay;
    public Customer customerPrefab;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnCustomer", 10, customerDelay);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SpawnCustomer()
    {

        if (store1.numItemsAtHome > store2.numItemsAtHome)
        {
            InstantiateCustomer(store1);
        }
        else if (store1.numItemsAtHome < store2.numItemsAtHome)
        {
            InstantiateCustomer(store2);
        }
        else if (store1.numItemsAtHome == store2.numItemsAtHome)
        {
            if(Random.value > 0.5)
            {
                InstantiateCustomer(store1);
            }
            else
            {
                InstantiateCustomer(store2);
            }
        }
    }

    void InstantiateCustomer(Store _store)
    {
        Customer newCustomer = Instantiate(customerPrefab);
        newCustomer.transform.position = _store.path[0].position;
        newCustomer.path = _store.path;
        newCustomer.store = _store;
    }
}
