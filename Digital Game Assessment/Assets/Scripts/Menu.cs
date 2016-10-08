using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    public string oneVsOne;

    public void twoPlayer()
    {
        SceneManager.LoadScene(oneVsOne);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
