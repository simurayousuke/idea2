using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Slider slider;
    private AsyncOperation asyn;
    private float toProgress = 0f;
    private float displayProgress = 0f;
    private static string _scene = "MainTitleScene";
    public static string nextScene
    {
        get { return _scene; }
        set
        {
            if (string.IsNullOrEmpty(value))
                _scene = "MainTitleScene";
            else
                _scene = value;
        }
    }

    IEnumerator BeginLoading()
    {
        asyn = SceneManager.LoadSceneAsync(nextScene);
        asyn.allowSceneActivation = false;
        while (asyn.progress < 0.9f || displayProgress < 0.9f)
        {
            toProgress = asyn.progress;
            while (displayProgress < toProgress)
            {
                displayProgress += 0.01f;
                yield return new WaitForEndOfFrame();

            }
        }
        toProgress = 1f;
        while (displayProgress < toProgress)
        {
            displayProgress += 0.01f;
            yield return new WaitForEndOfFrame();
        }
        displayProgress = 0f;
        asyn.allowSceneActivation = true;
    }

    public static void LoadScene(string scene)
    {
        nextScene = scene;
        SceneManager.LoadScene("LoadingScene");
    }


    public static void LoadSceneDirectly(string scene)
    {
        nextScene = scene;
        SceneManager.LoadScene(nextScene);
    }

    void Start()
    {
        StartCoroutine(BeginLoading());
    }


    void Update()
    {
        slider.value = displayProgress;
    }
}
