using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    string oneVsOne = "1v1";
    string MainMenu = "MainMenu";

    public void twoPlayer()
    {
        SceneManager.LoadScene(oneVsOne);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
