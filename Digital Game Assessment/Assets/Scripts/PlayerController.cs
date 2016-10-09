using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public string playerPrefix;
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
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis(playerPrefix + "Horizontal") * maxSpeed, Input.GetAxis(playerPrefix + "Vertical") * maxSpeed);

        if (Input.GetAxis(playerPrefix + "Interact") == 1)
        {
            Physics2D.IgnoreCollision(interactObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            interactObject.transform.position = transform.position;
            interactObject.SetActive(true);
        }
    }
}
