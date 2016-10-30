﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private string playerPrefix;
    [SerializeField]
    private Store store;
    [SerializeField]
    private float maxSpeed;
    public GameObject interactObject;
    public bool isCarrying = false;
    [SerializeField]
    private ScreenShake screenShakeCam;
    [SerializeField]
    private float shakeSize;
    public GameObject pickupTrigger;
    [SerializeField]
    private float stunLength;
    [SerializeField]
    private float invulnLength;
    [SerializeField]
    private ParticleSystem dust;

    AudioSource hitSound;
    bool stunned = false;
    bool invuln = false;
    Rigidbody2D rb;
    Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < store.items.Length; ++i)
        {
            Physics2D.IgnoreCollision(this.GetComponent<PolygonCollider2D>(), store.items[i].GetComponent<Collider2D>());
        }

        hitSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        if (!stunned)
        {
            rb.velocity = new Vector2(Input.GetAxis(playerPrefix + "Horizontal") * maxSpeed, Input.GetAxis(playerPrefix + "Vertical") * maxSpeed);
            if (Input.GetAxis(playerPrefix + "Horizontal") < 0)
            {
                if (!dust.isPlaying)
                {
                    dust.Play();
                }
                anim.SetInteger("Facing", 1);
                dust.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
            }
            else if (Input.GetAxis(playerPrefix + "Horizontal") > 0)
            {
                if (!dust.isPlaying)
                {
                    dust.Play();
                }
                anim.SetInteger("Facing", 2);
                dust.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
            }
            else if (Input.GetAxis(playerPrefix + "Vertical") > 0)
            {
                if (!dust.isPlaying)
                {
                    dust.Play();
                }
                anim.SetInteger("Facing", 1);
                dust.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                dust.transform.rotation = Quaternion.AngleAxis(-90, Vector3.left);
            }
            else if (Input.GetAxis(playerPrefix + "Vertical") < 0)
            {
                if (!dust.isPlaying)
                {
                    dust.Play();
                }
                anim.SetInteger("Facing", 2);
                dust.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                dust.transform.rotation = Quaternion.AngleAxis(90, Vector3.left);
            }
            else if (Input.GetAxis(playerPrefix + "Horizontal") == 0 && Input.GetAxis(playerPrefix + "Vertical") == 0)
            {
                anim.SetInteger("Facing", 0);
                dust.Stop();
            }

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

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interact":
                {
                    if(col.gameObject.GetInstanceID() != interactObject.GetInstanceID() && !stunned && !invuln)
                    {
                        stunned = true;
                        StartCoroutine(Stun(stunLength));
                        rb.AddForce(new Vector2((transform.position.x - col.gameObject.transform.position.x), (transform.position.y - col.gameObject.transform.position.y)) * 1 * 100, ForceMode2D.Impulse);
                        screenShakeCam.Shake(shakeSize);
                        hitSound.Play();
                        invuln = true;
                        StartCoroutine(Invulnerable(invulnLength));
                    }
                }
                break;

            case "GameStart":
                {
                    switch (playerPrefix)
                    {
                        case "P1_":
                            {
                                col.GetComponent<GameStart>().ReadyP1();
                            }
                            break;

                        case "P2_":
                            {
                                col.GetComponent<GameStart>().ReadyP2();
                            }
                            break;

                        default:
                            break;
                    }

                }
                break;

            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "GameStart":
                {
                    switch (playerPrefix)
                    {
                        case "P1_":
                            {
                                col.GetComponent<GameStart>().UnReadyP1();
                            }
                            break;

                        case "P2_":
                            {
                                col.GetComponent<GameStart>().UnReadyP2();
                            }
                            break;

                        default:
                            break;
                    }
                }
                break;
        }
    }

    IEnumerator Stun(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        stunned = false;
    }

    IEnumerator Invulnerable(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        invuln = false;
    }

    public Store GetStore()
    {
        return store;
    }
}
