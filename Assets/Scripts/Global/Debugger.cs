using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    Rect debugRect = new Rect(0, Screen.height - Mathf.Min(Screen.height, 200), Mathf.Min(Screen.width, 200), Mathf.Min(Screen.height, 200));
    string dbgTitle = "Debug Mode: " + Global.version;

    float pUpdate = 0f;
    float pFixedUpdate = 0f;
    int update = 0;
    int fixedupdate = 0;
    float fps = 0f;
    float fixedFps = 0f;

    void Awake()
    {
        if (!Global.initialized)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);
    }


    void Update()
    {
        update++;
        pUpdate += Time.deltaTime;
        if (pUpdate >= 1)
        {
            fps = update / pUpdate;
            pUpdate = 0f;
            update = 0;
        }
    }

    void FixedUpdate()
    {
        fixedupdate++;
        pFixedUpdate += Time.deltaTime;
        if (pFixedUpdate >= 1)
        {
            fixedFps = fixedupdate / pFixedUpdate;
            pFixedUpdate = 0f;
            fixedupdate = 0;
        }
    }

    void WindowDbg(int windowID)
    {
        // GUILayout.BeginScrollView(Vector2.zero, false, true);
        GUILayout.BeginVertical();

        GUILayout.Label("FPS: " + fps);
        GUILayout.Label("Fixed FPS: " + fixedFps);
        GUILayout.Label("Input Mode:" + (Global.inputType.Equals(InputType.KeyMouse) ? "KeyMouse" : "Controller"));

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("God Mode"))
            Global.godMode = !Global.godMode;
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Easy Mode"))
            Global.ezMode = !Global.ezMode;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Friendlly Bullet"))
            Global.friendlyBullet = !Global.friendlyBullet;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();
        //GUILayout.EndScrollView();
    }

    void OnGUI()
    {
        if (Global.debug)
        {
            debugRect = GUI.Window(0, debugRect, WindowDbg, dbgTitle);
        }
    }
}
