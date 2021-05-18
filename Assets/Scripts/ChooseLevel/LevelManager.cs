using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private void LoadLevel()
    {
        for (int i = 0; i < transform.childCount; ++i)
            transform.GetChild(i).GetComponent<LevelItem>().Init(i + 1, i + 1 > Global.saveData.level);
    }

    void Start()
    {
        LoadLevel();
    }

}
