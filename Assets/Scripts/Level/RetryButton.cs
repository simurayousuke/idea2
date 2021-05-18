using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }


    void OnClick()
    {
        UEventDispatcher.dispatchEvent(MyEvent.RESUME, null);
        SceneLoader.LoadScene(SceneManager.GetActiveScene().name);
    }

}
