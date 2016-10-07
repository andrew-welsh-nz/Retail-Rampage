using UnityEngine;
using System.Collections;

public class Clothing : MonoBehaviour {

    public float knockback;
    public bool isCorrectPosition = true;
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
        switch(col.gameObject.tag)
        {
            case "Interact":
                {
                    rb.AddForce(new Vector2((transform.position.x - col.gameObject.transform.position.x), (transform.position.y - col.gameObject.transform.position.y)) * knockback * 100, ForceMode2D.Impulse);
                }
                break;
            case "Safe":
                {
                    isCorrectPosition = true;
                }
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Safe":
                {
                    isCorrectPosition = false;
                }
                break;
        }
    }
}
