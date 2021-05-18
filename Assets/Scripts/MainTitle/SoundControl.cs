using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainTitle
{
    public class SoundControl : MonoBehaviour
    {
        public AudioClip focusMoved;
        public AudioClip enabledButtonPressed;
        public AudioClip disabledButtonPressed;
        private AudioSource audioSource;

        void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void FocusMoved()
        {
            audioSource.clip = focusMoved;
            audioSource.Play();
        }

        public void EnabledButtonPressed()
        {
            audioSource.clip = enabledButtonPressed;
            audioSource.Play();
        }

        public void DisabledButtonPressed()
        {
            audioSource.clip = disabledButtonPressed;
            audioSource.Play();
        }
    }
}