using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStart : MonoBehaviour {

    [SerializeField]
    bool POneReady;
    [SerializeField]
    bool PTwoReady;

    [SerializeField]
    string Destination = "1v1";

    public ScreenTransition fade;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(POneReady && PTwoReady)
        {
            StartCoroutine(WaitAndStart(0.5f));
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
            fade.fadeOut = true;

            StartCoroutine(WaitForFade(1.2f));

            
        }
    }

    IEnumerator WaitForFade(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        if (Destination == "QUIT")
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(Destination);
        }

    }
}
