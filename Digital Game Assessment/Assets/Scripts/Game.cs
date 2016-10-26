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
    private float gameTimeMins;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnCustomer", 10, customerDelay);
        Invoke("GameOver", gameTimeMins * 60);
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

    void GameOver()
    {
        if(store1.GetSales() > store2.GetSales())
        {
            // Go to Blue Wins screen
            SceneManager.LoadScene("BlueWin");
        }
        else if(store1.GetSales() < store2.GetSales())
        {
            // Go to Red Wins screen
            SceneManager.LoadScene("RedWin");
        }
        else if(store1.GetSales() == store2.GetSales())
        {
            // Go to Draw screen
            SceneManager.LoadScene("Draw");
        }
    }
}
