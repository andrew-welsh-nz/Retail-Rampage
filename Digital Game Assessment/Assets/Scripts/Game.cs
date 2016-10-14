using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour {

    public Store store1;
    public Store store2;
    public float customerDelay;
    public Customer customerPrefab;
    public float gameTimeMins;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnCustomer", 10, customerDelay);
        Invoke("GameOver", 60);
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

    void GameOver()
    {
        if(store1.sales > store2.sales)
        {
            // Go to Blue Wins screen
            SceneManager.LoadScene("BlueWin");
        }
        else if(store1.sales < store2.sales)
        {
            // Go to Red Wins screen
            SceneManager.LoadScene("RedWin");
        }
        else if(store1.sales == store2.sales)
        {
            // Go to Draw screen
            SceneManager.LoadScene("Draw");
        }
    }
}
