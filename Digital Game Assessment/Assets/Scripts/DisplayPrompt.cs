using UnityEngine;
using System.Collections;

public class DisplayPrompt : MonoBehaviour {

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "ButtonPrompt":
                {
                    //sprite.gameObject.SetActive(true);
                    sprite.enabled = true;
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
                    sprite.enabled = false;
                }
                break;

            default:
                break;
        }
    }
}
