using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour {

    [SerializeField]
    private Store store1;
    [SerializeField]
    private Store store2;
    [SerializeField]
    private float customerDelay;
    [SerializeField]
    private Customer customerPrefab;
    [SerializeField]
    private int salesTarget;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnCustomer", 10, customerDelay);
    }

    void Update()
    {
        if(store1.GetSales() == salesTarget)
        {
            SceneManager.LoadScene("BlueWin");
        }
        else if(store2.GetSales() == salesTarget)
        {
            SceneManager.LoadScene("RedWin");
        }
    }

    void SpawnCustomer()
    {

        if (store1.GetItemsAtHome() > store2.GetItemsAtHome())
        {
            InstantiateCustomer(store1);
        }
        else if (store1.GetItemsAtHome() < store2.GetItemsAtHome())
        {
            InstantiateCustomer(store2);
        }
        else if (store1.GetItemsAtHome() == store2.GetItemsAtHome())
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
