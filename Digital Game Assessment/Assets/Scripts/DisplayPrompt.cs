using UnityEngine;
using System.Collections;

public class DisplayPrompt : MonoBehaviour {

    [SerializeField]
    private GameObject sprite;

    private bool inArea = false;
    private bool showPrompt = false;

    [SerializeField]
    Sprite arrow;
    [SerializeField]
    Sprite prompt;

    SpriteRenderer spriteRender;

    private GameObject other;

	// Use this for initialization
	void Start () {
        spriteRender = sprite.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(inArea)
        {
            StartCoroutine(Wait(2.0f));
        }

        if (showPrompt && other != null)
        {
            sprite.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            spriteRender.sprite = prompt;
        }
        else
        {
            sprite.transform.localScale = new Vector3(1, 1, 1);
            spriteRender.sprite = arrow;
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
