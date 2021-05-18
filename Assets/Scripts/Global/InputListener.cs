using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    void Awake()
    {
        if (!Global.initialized)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);
    }

    bool GetControllerInput()
    {
        return Input.GetAxisRaw("Pitch") != 0
            || Input.GetAxisRaw("Roll") != 0
            || Input.GetAxis("Horizontal") != 0
            || Input.GetAxis("Vertical") != 0
            || Input.GetKeyDown("joystick button 0")
            || Input.GetKeyDown("joystick button 1")
            || Input.GetKeyDown("joystick button 2")
            || Input.GetKeyDown("joystick button 3")
            || Input.GetKeyDown("joystick button 4")
            || Input.GetKeyDown("joystick button 5")
            || Input.GetKeyDown("joystick button 6")
            || Input.GetKeyDown("joystick button 7")
            || Input.GetKeyDown("joystick button 8")
            || Input.GetKeyDown("joystick button 9");
            /*|| Input.GetKeyDown("joystick button 10")
            || Input.GetKeyDown("joystick button 11")
            || Input.GetKeyDown("joystick button 12")
            || Input.GetKeyDown("joystick button 13");*/
    }

    bool GetKeybordInput()
    {
        return Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.P)
            || Input.GetKeyDown(KeyCode.Escape);
    }

    bool GetMouseInput()
    {
        return Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonDown(1);
    }


    void Update()
    {
        if (GetControllerInput())
        {
            Global.inputType = InputType.Controller;
        }
        else if (GetKeybordInput() || GetMouseInput())
        {
            Global.inputType = InputType.KeyMouse;
        }
    }
}
