using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait(3));
	}

    IEnumerator Wait(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene("MainMenu");
    }
}
