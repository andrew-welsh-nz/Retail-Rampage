using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public string playerPrefix;
    public Store store;
    public float maxSpeed;
    public GameObject interactObject;
    public bool isCarrying = false;
    public GameObject pickupTrigger;
    bool stunned = false;
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
        if(!stunned)
        {
            rb.velocity = new Vector2(Input.GetAxis(playerPrefix + "Horizontal") * maxSpeed, Input.GetAxis(playerPrefix + "Vertical") * maxSpeed);

            if (Input.GetAxis(playerPrefix + "Interact") == 1)
            {
                Physics2D.IgnoreCollision(interactObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                interactObject.transform.position = transform.position;
                interactObject.SetActive(true);
            }

            if (isCarrying)
            {
                pickupTrigger.SetActive(false);
            }
            else
            {
                pickupTrigger.SetActive(true);
            }
        }
    }

    // STUN STUFF HAPPENS BELOW HERE
    // CAN BE REMOVED IF WE DON'T LIKE IT

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interact":
                {
                    if (!stunned)
                    {
                        stunned = true;
                        StartCoroutine(Stun(0.5f));
                        rb.AddForce(new Vector2((transform.position.x - col.gameObject.transform.position.x), (transform.position.y - col.gameObject.transform.position.y)) * 1 * 100, ForceMode2D.Impulse);
                    }
                }
                break;
            default:
                break;
        }
    }

    IEnumerator Stun(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        stunned = false;
    }
}
