using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    public float shakeSize = 0.25f;
    public float dampingFactor = 2.0f;

    private Camera mainCam;
    private Vector3 camPos;
    private float shake = 0.0f;

	// Use this for initialization
	void Awake () {
        mainCam = Camera.main;

        camPos = mainCam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(shake > 0.0f)
        {
            mainCam.transform.position = new Vector3((Random.insideUnitCircle * shakeSize * shake).x, (Random.insideUnitCircle * shakeSize * shake).y, -10);

            shake -= Time.deltaTime * dampingFactor;

            if(shake <= 0.0f)
            {
                shake = 0;
                mainCam.transform.position = camPos;
            }
        }
	}

    public void Shake(float _size)
    {
        shakeSize = _size;

        if (shake <= 0.0f)
        {
            camPos = mainCam.transform.position;
        }

        shake = 1;
    }
}
