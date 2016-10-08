using UnityEngine;
using System.Collections;

public class Clothing : MonoBehaviour {

    public Store owner;
    public float knockback;
    public bool isCorrectPosition = true;
    public GameObject home;
    Rigidbody2D rb;
    bool isBeingCarried = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(isBeingCarried)
        {
            this.transform.position = owner.storeOwner.transform.position;
        }
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
            case "Home":
                {
                    if(col.gameObject.GetInstanceID() == home.GetInstanceID())
                    {
                        isCorrectPosition = true;
                        owner.AddAtHome();
                        isBeingCarried = false;
                        transform.position = Vector2.Lerp(transform.position, home.transform.position, 10.0f);
                        owner.storeOwner.isCarrying = false;
                    }
                }
                break;
            case "Player":
                {
                    if(col.gameObject.GetInstanceID() == owner.storeOwner.pickupTrigger.GetInstanceID())
                    {
                        if (owner.storeOwner.isCarrying == false && transform.position != home.transform.position)
                        {
                            isBeingCarried = true;
                            owner.storeOwner.isCarrying = true;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Home":
                {
                    isCorrectPosition = false;
                    owner.RemoveAtHome();
                }
                break;
        }
    }
}
