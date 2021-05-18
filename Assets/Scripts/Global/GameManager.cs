using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool Init()
    {
        return true;
    }


    public static bool SafeQuit()
    {
        if (!Global.saveData.Export())
            return false;
        Application.Quit();
        return true;
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
