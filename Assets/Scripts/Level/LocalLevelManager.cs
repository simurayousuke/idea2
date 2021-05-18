using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLevelManager : MonoBehaviour
{
    [SerializeField] GameObject clearPanel;
    [SerializeField] GameObject overPanel;
    [SerializeField] GameObject pausePanel;

    

    void Awake()
    {
        UEventDispatcher.addEventListener(MyEvent.PAUSE, OnPause);
        UEventDispatcher.addEventListener(MyEvent.RESUME, OnResume);
        UEventDispatcher.addEventListener(MyEvent.LEVEL_CLEAR, OnClear);
        UEventDispatcher.addEventListener(MyEvent.PLAYER_DEATH, OnOver);
    }

    void OnOver(UEvent e)
    {
        Time.timeScale = 0f;
        overPanel.SetActive(true);
    }

    void OnClear(UEvent e)
    {
        Time.timeScale = 0f;
        clearPanel.SetActive(true);
        Global.saveData.ClearLevel(Global.currentLevel);
    }

    void OnPause(UEvent e)
    {
        Time.timeScale = 0f;
        Global.isPause = true;
        pausePanel.SetActive(true);
    }

    void OnResume(UEvent e)
    {
        Time.timeScale = 1f;
        Global.isPause = false;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Global.isPause)
                UEventDispatcher.dispatchEvent(MyEvent.RESUME, this);
            else
                UEventDispatcher.dispatchEvent(MyEvent.PAUSE, this);
        }
    }

    void OnDestroy()
    {
        UEventDispatcher.removeEventListener(MyEvent.RESUME, OnResume);
        UEventDispatcher.removeEventListener(MyEvent.PAUSE, OnPause);
        UEventDispatcher.removeEventListener(MyEvent.LEVEL_CLEAR, OnClear);
        UEventDispatcher.removeEventListener(MyEvent.PLAYER_DEATH, OnOver);
    }
    
}
