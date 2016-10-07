using UnityEngine;
using System.Collections;

public class Clothing : MonoBehaviour {

    public float knockback;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Interact")
        {
            rb.AddForce(new Vector2((transform.position.x - col.gameObject.transform.position.x), (transform.position.y - col.gameObject.transform.position.y)) * knockback * 100, ForceMode2D.Impulse);
        }
    }
}
