using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour {

    public static ScreenTransition instance;

    public float fadeTime = 1.0f;

    public bool fadeIn;
    public bool fadeOut;

    public Image fadeImage;

    float time = 0.0f;

    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
            if(fadeIn)
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1.0f);
            }
            else
            {
                Destroy(transform.gameObject);
            }
        }
    }

    void OnEnable()
    {
        if(fadeIn)
        {
            StartCoroutine(StartScene());
        }
    }

    public void LoadScene(string level)
    {
        StartCoroutine(EndScene(level));
    }

    IEnumerator StartScene()
    {
        time = 1.0f;
        yield return null;
        while (time >= 0.0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, time);
            time -= Time.deltaTime * (1.0f / fadeTime);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }

    IEnumerator EndScene(string level)
    {
        fadeImage.gameObject.SetActive(true);
        time = 0.0f;
        yield return null;
        while(time <= 1.0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, time);
            time += Time.deltaTime * (1.0f / fadeTime);
            yield return null;
        }
        SceneManager.LoadScene(level, LoadSceneMode.Single);
        StartCoroutine(StartScene());
    }
}
