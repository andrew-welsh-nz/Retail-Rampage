using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour {
    public bool fadeIn = true;
    public bool fadeOut = false;

    [SerializeField]
    Texture2D fadeTexture;
    float fadeSpeed = 0.75f;
    int fadeDepth = -1000;

    public float alpha = 1.0f;

    void Start()
    {
        fadeIn = true;
    }

    void Update()
    {
        if(fadeIn)
        {
            alpha -= fadeSpeed * Time.deltaTime;

            //GUI.color = new Color(0, 0, 0, alpha);

            //GUI.depth = fadeDepth;

            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

            if(alpha <= 0)
            {
                fadeIn = false;
            }
        }
        else if(fadeOut)
        {
            alpha += fadeSpeed * Time.deltaTime;

            

            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

            if (alpha >= 1)
            {
                fadeOut = false;
            }
        }
    }

    void OnGUI()
    {
        GUI.color = new Color(0, 0, 0, alpha);

        GUI.depth = fadeDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
    
}
