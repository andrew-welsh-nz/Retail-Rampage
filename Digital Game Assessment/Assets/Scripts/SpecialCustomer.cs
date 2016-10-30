using UnityEngine;
using System.Collections;

public class SpecialCustomer : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private float salesDelay;

    private int totalsales = 3;

    private bool canBuy = true;

    public ScreenShake screenShakeCam;
    public float shakeSize;

    void Start()
    {
        particles.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        if(totalsales <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Interact" && canBuy)
        {
            particles.gameObject.SetActive(true);

            particles.Emit(5);

            particles.transform.parent = null;

            screenShakeCam.Shake(shakeSize);

            col.transform.parent.GetComponent<PlayerController>().GetStore().AddSale();
            totalsales -= 1;

            canBuy = false;
            StartCoroutine(Wait(salesDelay));        
        }
    }

    IEnumerator Wait(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        if(!canBuy)
        {
            canBuy = true;
        }
    }
}

