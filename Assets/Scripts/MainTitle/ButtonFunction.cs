using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainTitle
{
    public class ButtonFunction : MonoBehaviour
    {
        MainTitle.SoundControl soundControl;

        void Awake()
        {
            soundControl = GetComponentInParent<SoundControl>();
        }

        public void SinglePlay()
        {
            Debug.Log("SinglePlay");
            soundControl.EnabledButtonPressed();
            SceneLoader.LoadSceneDirectly("ChooseLevelScene");
        }

        public void MultiPlay()
        {
            Debug.Log("MultiPlay");
            soundControl.DisabledButtonPressed();
        }

        public void Option()
        {
            Debug.Log("Option");
            soundControl.DisabledButtonPressed();
            SceneLoader.LoadSceneDirectly("OptionScene");
        }

        public void Stuff()
        {
            Debug.Log("Stuff");
            soundControl.DisabledButtonPressed();
            SceneLoader.LoadSceneDirectly("StuffScene");
        }

        public void Exit()
        {
            Debug.Log("Exit");
            GameManager.Quit();
        }
    }
}