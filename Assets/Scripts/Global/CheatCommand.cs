using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCommand : MonoBehaviour
{
    string command;
    [SerializeField] Text leftBottom;
    float time;
    string ui;

    void Awake()
    {
        if (!Global.initialized)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        command = "";
        RefreshUI();
    }

    void OnGUI()
    {
        GUILayout.Label(ui);
    }

    void RefreshUI()
    {
        time = 0f;
        ui = "";
        if (Global.debug)
            ui += "| Debug ";
        if (Global.godMode)
            ui += "| God ";
        if (Global.ezMode)
            ui += "| Easy ";
        if (Global.friendlyBullet)
            ui += "| FB ";
        if (ui != "")
            ui += "|";
        //leftBottom.text = ui;
    }

    void Check()
    {
        if (command == "godmode")
        {
            Global.godMode = !Global.godMode;
        }
        else if (command == "ezmode")
        {
            Global.ezMode = !Global.ezMode;
        }
        else if (command == "debug")
        {
            Global.debug = !Global.debug;
        }
        else if (command == "friendlybullet")
        {
            Global.friendlyBullet = !Global.friendlyBullet;
        }
        else if (command == "unlock")
        {
            Global.saveData.level = Global.maxLevel;
        }
        else
        {
            return;
        }
        command = "";
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f)
            RefreshUI();
        if (command.Length > 32)
            command = "";
        if (Input.GetKeyDown(KeyCode.BackQuote))
            command = "";
        if (Input.GetKeyDown(KeyCode.A))
            command += "a";
        else if (Input.GetKeyDown(KeyCode.B))
            command += "b";
        else if (Input.GetKeyDown(KeyCode.C))
            command += "c";
        else if (Input.GetKeyDown(KeyCode.D))
            command += "d";
        else if (Input.GetKeyDown(KeyCode.E))
            command += "e";
        else if (Input.GetKeyDown(KeyCode.F))
            command += "f";
        else if (Input.GetKeyDown(KeyCode.G))
            command += "g";
        else if (Input.GetKeyDown(KeyCode.H))
            command += "h";
        else if (Input.GetKeyDown(KeyCode.I))
            command += "i";
        else if (Input.GetKeyDown(KeyCode.J))
            command += "j";
        else if (Input.GetKeyDown(KeyCode.K))
            command += "k";
        else if (Input.GetKeyDown(KeyCode.L))
            command += "l";
        else if (Input.GetKeyDown(KeyCode.M))
            command += "m";
        else if (Input.GetKeyDown(KeyCode.N))
            command += "n";
        else if (Input.GetKeyDown(KeyCode.O))
            command += "o";
        else if (Input.GetKeyDown(KeyCode.P))
            command += "p";
        else if (Input.GetKeyDown(KeyCode.Q))
            command += "q";
        else if (Input.GetKeyDown(KeyCode.R))
            command += "r";
        else if (Input.GetKeyDown(KeyCode.S))
            command += "s";
        else if (Input.GetKeyDown(KeyCode.T))
            command += "t";
        else if (Input.GetKeyDown(KeyCode.U))
            command += "u";
        else if (Input.GetKeyDown(KeyCode.V))
            command += "v";
        else if (Input.GetKeyDown(KeyCode.W))
            command += "w";
        else if (Input.GetKeyDown(KeyCode.X))
            command += "x";
        else if (Input.GetKeyDown(KeyCode.Y))
            command += "y";
        else if (Input.GetKeyDown(KeyCode.Z))
            command += "z";
        Check();
    }
}
