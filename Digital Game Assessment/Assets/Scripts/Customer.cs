using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

    [SerializeField]
    private ParticleSystem particles;
    public Transform[] path;
    [SerializeField]
    private int currentPathPosition = 0;
    [SerializeField]
    private float customerSpeed;
    public Store store;

    [SerializeField]
    private Store currentStore;

    public ScreenShake screenShakeCam;
    public float shakeSize;

    Transform target;
    bool canMove = true;

    Animator anim;
	
    void Start()
    {
        particles.gameObject.SetActive(false);

        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        if (currentPathPosition < this.path.Length)
        {
            if(target == null)
            {
                target = path[currentPathPosition];
            }

            MoveToPosition();
        }
        else
        {
            anim.SetBool("HasMoved", true);
        }
	}

    void MoveToPosition()
    {
        if(canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, customerSpeed * Time.deltaTime);
            if (transform.position == target.position)
            {
                ++currentPathPosition;
                if (currentPathPosition < path.Length)
                {
                    target = path[currentPathPosition];
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Interact" && currentStore != null)
        {
            if(col.gameObject.GetInstanceID() == currentStore.storeOwner.interactObject.GetInstanceID())
            {
                particles.gameObject.SetActive(true);

                particles.Emit(5);

                particles.transform.parent = null;

                screenShakeCam.Shake(shakeSize);

                currentStore.AddSale();
                Destroy(this.gameObject);
            }
        }

        if(col.gameObject.tag == "SalesFloor")
        {
            currentStore = col.GetComponent<SalesFloor>().GetStore();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "SalesFloor")
        {
            currentStore = null;
        }
    }
}
