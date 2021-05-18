using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    KeyMouse,
    Controller
}

public static class Global
{
    public const int maxLevel = 4;

    public const int version1 = 1;
    public const int version2 = 0;
    public const int version3 = 0;
    public const int version4 = 2;
    public static readonly string version = version1 + "." + version2 + "." + version3 + "." + version4;

    public static bool initialized = false;

    public static bool debug = false;
    public static bool godMode = false;
    public static bool ezMode = false;
    public static bool friendlyBullet = false;

    public static SaveData saveData = new SaveData();
    public static bool isPause = false;
    public static InputType inputType = InputType.KeyMouse;
    public static int currentLevel = 0;

    public static bool isKeyMouse { get { return inputType == InputType.KeyMouse; } }
    public static bool isController { get { return inputType == InputType.Controller; } }


    public static bool Init()
    {
        initialized = true;
        return true;
    }

}