using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int playerNumber;
    public Store store;
    public float maxSpeed;
    public GameObject interactObject;
    public bool isCarrying = false;
    public GameObject pickupTrigger;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < store.items.Length; ++i)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), store.items[i].GetComponent<Collider2D>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (playerNumber)
        {
            case 1:
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, Input.GetAxis("Vertical") * maxSpeed);

                    if (Input.GetAxis("Interact") == 1)
                    {
                        Physics2D.IgnoreCollision(interactObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                        interactObject.transform.position = transform.position;
                        interactObject.SetActive(true);
                    }
                }
                break;
            case 2:
                {
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal2") * maxSpeed, Input.GetAxis("Vertical2") * maxSpeed);

                    if (Input.GetAxis("Interact2") == 1)
                    {
                        Physics2D.IgnoreCollision(interactObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                        interactObject.transform.position = transform.position;
                        interactObject.SetActive(true);
                    }
                }
                break;
            default:
                break;
        }
	}
}
