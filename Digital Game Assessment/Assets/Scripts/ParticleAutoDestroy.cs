using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy : MonoBehaviour {

    ParticleSystem particle;

	// Use this for initialization
	void Start () {
        particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(particle)
        {
            if(!particle.IsAlive())
            {
                Destroy(gameObject);
            }
        }
	}
}
