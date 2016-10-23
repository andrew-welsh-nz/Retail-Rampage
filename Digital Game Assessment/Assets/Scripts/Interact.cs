using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    [SerializeField]
    private float delay;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.activeSelf == true)
        {
            StartCoroutine(WaitAndHide(delay));
        }
	}

    IEnumerator WaitAndHide(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
