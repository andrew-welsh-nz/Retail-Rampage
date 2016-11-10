using UnityEngine;
using System.Collections;

public class Clothing : MonoBehaviour {

    [SerializeField]
    private Store owner;
    [SerializeField]
    private float knockback;
    public bool isCorrectPosition = true;
    [SerializeField]
    private GameObject home;
    [SerializeField]
    private ScreenShake screenShakeCam;
    [SerializeField]
    private float shakeSize;

    AudioSource hitSound;
    Rigidbody2D rb;
    bool isBeingCarried = false;
    Quaternion startRotation;

    SpriteRenderer spriteRender;

    [SerializeField]
    Sprite spriteNormal;
    [SerializeField]
    Sprite spriteOffPosition;

    // Use this for initialization
    void Start () {
        Vector3 scale = new Vector3(0.1f, 0.1f, 1f);

        transform.localScale = scale;

        rb = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
        startRotation = transform.rotation;
        spriteRender = GetComponent <SpriteRenderer>();

        spriteRender.sprite = spriteNormal;
    }
	
	// Update is called once per frame
	void Update () {


        if (isBeingCarried)
        {
            spriteRender.sprite = spriteNormal;
            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt((transform.position.y * 100f) - 50) * -1;
            this.transform.position = owner.storeOwner.transform.position;
        }
        else
        {
            if(!isCorrectPosition)
            {
                spriteRender.sprite = spriteOffPosition;
            }
            else
            {
                spriteRender.sprite = spriteNormal;
            }
            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
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
                        StartCoroutine(FreezeGame(0.025f));
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

    IEnumerator FreezeGame(float _delay)
    {
        Time.timeScale = 0.0f;
        float pauseEndTime = Time.realtimeSinceStartup + _delay;
        while(Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1.0f;
    }
}
