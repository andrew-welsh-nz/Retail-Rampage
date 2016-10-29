using UnityEngine;
using System.Collections;

public class SalesFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Store GetStore()
    {
        return transform.parent.GetComponent<Store>();
    }
}
