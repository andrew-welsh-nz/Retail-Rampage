using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour {

    [SerializeField]
    private GameObject BlueWin;
    [SerializeField]
    private GameObject RedWin;

	// Use this for initialization
	void Start () {
        BlueWin.SetActive(false);
        RedWin.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowBlue()
    {
        BlueWin.SetActive(true);
    }

    public void ShowRed()
    {
        RedWin.SetActive(true);
    }
}
