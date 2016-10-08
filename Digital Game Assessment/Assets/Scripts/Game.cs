using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

    public Store store1;
    public Store store2;
    public Text winningText;

	// Use this for initialization
	void Start () {
        SetText("Draw!");
	}
	
	// Update is called once per frame
	void Update () {
	    if(store1.itemsAtHome >  store2.itemsAtHome)
        {
            SetText("Left Team");
        }
        else if(store1.itemsAtHome < store2.itemsAtHome)
        {
            SetText("Right Team");
        }
        else if(store1.itemsAtHome == store2.itemsAtHome)
        {
            SetText("Draw!");
        }
	}

    void SetText(string winningTeam)
    {
        winningText.text = "Winning Team: " + winningTeam;
    }
}
