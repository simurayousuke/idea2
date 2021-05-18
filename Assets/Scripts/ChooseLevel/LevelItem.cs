using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] AudioClip focus;
    private int levelId;
    private Button button;
    private AudioSource audioSource;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        audioSource = gameObject.GetComponentInParent<AudioSource>();
    }

    public void Init(int id, bool isLock)
    {
        levelId = id;
        if (isLock)
            button.interactable = false;
        else
            button.interactable = true;
        GetComponentInChildren<Text>().text = levelId.ToString();
    }

    void OnClick()
    {
        Global.currentLevel = levelId;
        SceneLoader.LoadScene("Level" + levelId);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        /*audioSource.clip = focus;
        audioSource.Play();*/
    }
}
