using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    
    void Start()
    {
        Global.Init();
        GameManager.Init();
        string[] args = System.Environment.GetCommandLineArgs();
        foreach(string arg in args)
        {
            if (string.Equals(arg, "debug", System.StringComparison.OrdinalIgnoreCase))
                Global.debug = true;
            else if (string.Equals(arg, "ezmode", System.StringComparison.OrdinalIgnoreCase))
                Global.ezMode = true;
            else if (string.Equals(arg, "godmode", System.StringComparison.OrdinalIgnoreCase))
                Global.godMode = true;
            else if (string.Equals(arg, "friendlybullet", System.StringComparison.OrdinalIgnoreCase))
                Global.friendlyBullet = true;
            else if (string.Equals(arg, "unlock", System.StringComparison.OrdinalIgnoreCase))
                Global.saveData.level = Global.maxLevel;
        }
    }

}
