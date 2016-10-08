using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

    public PlayerController storeOwner;
    public GameObject[] items = new GameObject[4];
    public int itemsAtHome;

    public void AddAtHome()
    {
        itemsAtHome++;
    }

    public void RemoveAtHome()
    {
        itemsAtHome--;
    }
}
