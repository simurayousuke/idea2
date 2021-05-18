using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Loading
{
    public class LoadingLabel : MonoBehaviour
    {
        private Text text;
        private float time = 0f;
        private string baseStr = "Loading";
        private int dot = 0;
        private string label;

        void Awake()
        {
            text = GetComponent<Text>();
        }


        void Update()
        {
            time += Time.deltaTime;
            if (time > 0.1f)
            {
                if (++dot > 3)
                    dot = 0;
                label = baseStr;
                for (int i = 0; i < dot; ++i)
                    label += ".";
                text.text = label;
                time = 0f;
            }
        }
    }
}