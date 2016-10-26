using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStart : MonoBehaviour {

    [SerializeField]
    bool POneReady;
    [SerializeField]
    bool PTwoReady;

    string onevsone = "1v1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(POneReady && PTwoReady)
        {
            StartCoroutine(WaitAndStart(2.5f));
        }
	}

    public void ReadyP1()
    {
        POneReady = true;
    }

    public void UnReadyP1()
    {
        POneReady = false;
    }

    public void ReadyP2()
    {
        PTwoReady = true;
    }

    public void UnReadyP2()
    {
        PTwoReady = false;
    }

    IEnumerator WaitAndStart(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        if (POneReady && PTwoReady)
        {
            SceneManager.LoadScene(onevsone);
        }
    }
}
