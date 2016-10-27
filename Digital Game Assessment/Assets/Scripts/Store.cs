using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Store : MonoBehaviour {

    public PlayerController storeOwner;
    public Clothing[] items = new Clothing[4];
    public Transform[] path;

    private int sales = 0;

    private int numItemsAtHome = 0;

    [SerializeField]
    Text scoreText;

    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = "Sales: " + sales.ToString();
        }
    }

    void Update()
    {
        numItemsAtHome = 0;

        for (int i = 0; i < items.Length; ++i)
        {
            if(items[i].isCorrectPosition)
            {
                ++numItemsAtHome;
            }
        }
    }

    public int GetSales()
    {
        return sales;
    }

    public void AddSale()
    {
        sales++;
        if(scoreText != null)
        {
            scoreText.text = "Sales: " + sales.ToString();
        }
    }

    public int GetItemsAtHome()
    {
        return numItemsAtHome;
    }
        
}
