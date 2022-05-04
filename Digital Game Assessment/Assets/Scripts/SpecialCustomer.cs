using UnityEngine;
using System.Collections;

public class SpecialCustomer : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private float salesDelay;

    [SerializeField]
    private GameObject loading;

    [SerializeField]
    RuntimeAnimatorController Michael;
    [SerializeField]
    RuntimeAnimatorController Lucy;

    private int totalsales = 3;

    private bool canBuy = true;

    public ScreenShake screenShakeCam;
    public float shakeSize;

    public Game game;

    Animator anim;
    SpriteRenderer spriteRenderer;

    public static bool isLucy;

    void Start()
    {
        loading.SetActive(false);

        particles.gameObject.SetActive(false);

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(isLucy)
        {
            anim.runtimeAnimatorController = Lucy;
            Debug.Log("Lucy");
            isLucy = false;
        }
        else
        {
            anim.runtimeAnimatorController = Michael;
            Debug.Log("Michael");
            isLucy = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        if(totalsales <= 0)
        {
            game.currentSpecialCustomer = null;

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
            loading.SetActive(true);
            StartCoroutine(Wait(salesDelay));        
        }
    }

    IEnumerator Wait(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        if(!canBuy)
        {
            canBuy = true;
            loading.SetActive(false);
        }
    }
}

