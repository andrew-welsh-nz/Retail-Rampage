using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy : MonoBehaviour {

    ParticleSystem particle;

    AudioSource sound;

	// Use this for initialization
	void Start () {
        particle = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();

        sound.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    if(particle && !transform.parent)
        {
            if(!particle.IsAlive())
            {
                Destroy(gameObject);
            }
        }

        if(transform.parent)
        {
            transform.position = transform.parent.position;
        }
	}
}
