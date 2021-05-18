using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToLevelChoose : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        UEventDispatcher.dispatchEvent(MyEvent.RESUME, null);
        SceneLoader.LoadSceneDirectly("ChooseLevelScene");
    }
}
