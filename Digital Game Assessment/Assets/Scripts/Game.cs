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
    private float specialCustomerDelay;
    [SerializeField]
    private Transform specialCustomerSpawn;
    [SerializeField]
    private Customer customerPrefab;
    [SerializeField]
    private SpecialCustomer specialCustomerPrefab;
    [SerializeField]
    private int salesTarget;
    [SerializeField]
    private WinManager winners;

    [SerializeField]
    private ScreenShake screenShakeCam;
    [SerializeField]
    private float shakeSize;

    public SpecialCustomer currentSpecialCustomer;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnCustomer", 10, customerDelay);
        InvokeRepeating("SpawnSpecialCustomer", specialCustomerDelay, specialCustomerDelay);
    }

    void Update()
    {
        if(store1.GetSales() >= salesTarget)
        {
            winners.gameObject.transform.position = new Vector2(0, 0);
            winners.ShowBlue();
            Time.timeScale = 0.5f;

            StartCoroutine(WaitAndLeave(2));
            //SceneManager.LoadScene("BlueWin");
        }
        else if(store2.GetSales() >= salesTarget)
        {
            winners.gameObject.transform.position = new Vector2(0, 0);
            winners.ShowRed();
            Time.timeScale = 0.5f;

            StartCoroutine(WaitAndLeave(2));
            //SceneManager.LoadScene("RedWin");
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

    void SpawnSpecialCustomer()
    {
        if (currentSpecialCustomer == null)
        {
            SpecialCustomer newSpecialCustomer = Instantiate(specialCustomerPrefab);
            newSpecialCustomer.transform.position = specialCustomerSpawn.transform.position;
            newSpecialCustomer.screenShakeCam = screenShakeCam;
            newSpecialCustomer.shakeSize = shakeSize;

            currentSpecialCustomer = newSpecialCustomer;
            currentSpecialCustomer.game = this;
        }
    }

    void InstantiateCustomer(Store _store)
    {
        Customer newCustomer = Instantiate(customerPrefab);
        newCustomer.transform.position = _store.path[0].position;
        newCustomer.path = _store.path;
        newCustomer.store = _store;
        newCustomer.screenShakeCam = screenShakeCam;
        newCustomer.shakeSize = shakeSize;
    }

    IEnumerator WaitAndLeave(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
