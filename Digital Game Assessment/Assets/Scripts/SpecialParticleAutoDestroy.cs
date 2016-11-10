using UnityEngine;
using System.Collections;

public class SpecialParticleAutoDestroy : MonoBehaviour
{

    ParticleSystem particle;

    AudioSource sound;

    int SalesLeft = 3;

    // Use this for initialization
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();

        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle && !transform.parent)
        {
            if (!particle.IsAlive())
            {
                SalesLeft -= 1;
                if (SalesLeft <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (transform.parent)
        {
            transform.position = transform.parent.position;
        }
    }
}
