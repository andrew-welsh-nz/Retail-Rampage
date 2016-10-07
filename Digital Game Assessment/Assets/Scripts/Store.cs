using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

    public GameObject[] items = new GameObject[4];
    public int itemsAtHome;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void AddAtHome()
    {
        itemsAtHome++;
    }

    public void RemoveAtHome()
    {
        itemsAtHome--;
    }
}
