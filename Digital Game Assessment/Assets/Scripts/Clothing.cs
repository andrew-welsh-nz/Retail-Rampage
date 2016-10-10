using UnityEngine;
using System.Collections;

public class Clothing : MonoBehaviour {

    public Store owner;
    public float knockback;
    public bool isCorrectPosition = true;
    public GameObject home;
    public ScreenShake screenShakeCam;
    public float shakeSize;

    AudioSource hitSound;
    Rigidbody2D rb;
    bool isBeingCarried = false;
    Quaternion startRotation;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
        startRotation = transform.rotation;
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
                    if(!isBeingCarried)
                    {
                        hitSound.Play();
                        rb.AddForce(new Vector2((transform.position.x - col.gameObject.transform.position.x), (transform.position.y - col.gameObject.transform.position.y)) * knockback * 100, ForceMode2D.Impulse);
                        screenShakeCam.Shake(shakeSize);
                    }
                }
                break;
            case "Home":
                {
                    if(col.gameObject.GetInstanceID() == home.GetInstanceID())
                    {
                        isCorrectPosition = true;
                        isBeingCarried = false;
                        transform.position = home.transform.position;
                        transform.rotation = startRotation;
                        owner.storeOwner.isCarrying = false;
                    }
                }
                break;
            case "PickupTrigger":
                {
                    if(col.gameObject.GetInstanceID() == owner.storeOwner.pickupTrigger.GetInstanceID())
                    {
                        if(owner.storeOwner.isCarrying == false)
                        {
                            if (transform.position != home.transform.position)
                            {
                                isBeingCarried = true;
                                owner.storeOwner.isCarrying = true;
                                transform.rotation = startRotation;
                            }
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
                }
                break;
        }
    }
}
