using UnityEngine;
using System.Collections;

public class DisplayPrompt : MonoBehaviour {

    [SerializeField]
    private GameObject sprite;

    private bool inArea = false;
    private bool showPrompt = false;

    private GameObject other;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(inArea)
        {
            StartCoroutine(Wait(2.0f));
        }

        if (showPrompt && other != null)
        {
            sprite.SetActive(true);
        }
        else
        {
            sprite.SetActive(false);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "ButtonPrompt":
                {
                    inArea = true;

                    other = col.gameObject;
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
            case "ButtonPrompt":
                {
                    showPrompt = false;

                    inArea = false;

                    other = null;
                }
                break;

            default:
                break;
        }
    }

    IEnumerator Wait(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        if (inArea && other != null)
        {
            showPrompt = true;
        }
    }
}
