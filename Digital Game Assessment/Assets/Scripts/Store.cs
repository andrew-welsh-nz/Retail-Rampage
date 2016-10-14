using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

    public PlayerController storeOwner;
    public Clothing[] items = new Clothing[4];
    public Transform[] path;

    public int numItemsAtHome = 0;

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
}
