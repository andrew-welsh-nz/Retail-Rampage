using UnityEngine;
using System.Collections;

public class DisplayPrompt : MonoBehaviour {

    private SpriteRenderer sprite;

    private bool showPrompt = false;

    private GameObject other;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(showPrompt && !other)
        {
            sprite.enabled = false;
        }
        else if (showPrompt && other)
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "ButtonPrompt":
                {
                    showPrompt = true;

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

                    other = null;
                }
                break;

            default:
                break;
        }
    }
}
