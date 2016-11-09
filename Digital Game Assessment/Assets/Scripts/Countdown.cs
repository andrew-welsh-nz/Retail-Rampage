using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

    [SerializeField]
    GameObject wall1;
    [SerializeField]
    GameObject wall2;

    [SerializeField]
    AudioSource GameMusic;

    // Use this for initialization
    void Start () {
        Invoke("StartGame", 2.7f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void StartGame()
    {
        Destroy(wall1);
        Destroy(wall2);
        GameMusic.Play();
    }
}
