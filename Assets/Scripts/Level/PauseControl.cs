using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    private Button button;
    private Image image;
    [SerializeField] Sprite pause;
    [SerializeField] Sprite play;

    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        UEventDispatcher.addEventListener(MyEvent.PAUSE, OnPause);
        UEventDispatcher.addEventListener(MyEvent.RESUME, OnResume);
    }

    void OnPause(UEvent e)
    {

        Debug.Log("Pause");
        image.sprite = play;
    }

    void OnResume(UEvent e)
    {
        image.sprite = pause;
    }

    void OnClick()
    {
        if (Global.isPause)
            UEventDispatcher.dispatchEvent(MyEvent.RESUME, this);
        else
            UEventDispatcher.dispatchEvent(MyEvent.PAUSE, this);
    }

    void OnDestroy()
    {
        UEventDispatcher.removeEventListener(MyEvent.RESUME, OnResume);
        UEventDispatcher.removeEventListener(MyEvent.PAUSE, OnPause);
    }
}
