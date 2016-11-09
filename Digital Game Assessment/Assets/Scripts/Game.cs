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
    private Customer customerPrefabMale;
    [SerializeField]
    private Customer customerPrefabFemale;
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

    [SerializeField]
    private AudioSource sound;

    public SpecialCustomer currentSpecialCustomer;

    public ScreenTransition fade;

    bool GameOver = false;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnCustomer", 10, customerDelay);
        InvokeRepeating("SpawnSpecialCustomer", specialCustomerDelay, specialCustomerDelay);
    }

    void Update()
    {
        if(store1.GetSales() >= salesTarget || store2.GetSales() >= salesTarget)
        {
            GameOver = true;
        }

        if(store1.GetSales() >= salesTarget && GameOver == true)
        {
            winners.gameObject.transform.position = new Vector2(0, 0);
            winners.ShowBlue();
            Time.timeScale = 0.5f;
            if (sound.pitch > 0.0f)
            {
                sound.pitch -= 0.5f * Time.deltaTime;
                if(sound.pitch < 0.0f)
                {
                    sound.pitch = 0.0f;
                }
            }

            fade.fadeOut = true;
            fade.alpha = 0.0f;

            StartCoroutine(WaitAndLeave(2));
        }
        else if(store2.GetSales() >= salesTarget && GameOver == true)
        {
            winners.gameObject.transform.position = new Vector2(0, 0);
            winners.ShowRed();
            Time.timeScale = 0.5f;
            if (sound.pitch > 0.0f)
            {
                sound.pitch -= 0.5f * Time.deltaTime;
                if (sound.pitch < 0.0f)
                {
                    sound.pitch = 0.0f;
                }
            }

            fade.fadeOut = true;
            fade.alpha = 0.0f;

            StartCoroutine(WaitAndLeave(2));
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
        Customer newCustomer;

        if (Random.value > 0.5)
        {
            newCustomer = Instantiate(customerPrefabMale);
        }
        else
        {
            newCustomer = Instantiate(customerPrefabFemale);
        }
        
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
        sound.Stop();
        sound.pitch = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
