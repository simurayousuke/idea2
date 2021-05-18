using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainTitle
{
    public class ArrowControl : MonoBehaviour
    {

        [SerializeField] float topY;
        [SerializeField] float bottomY;
        [SerializeField] float distance;
        [SerializeField] GameObject parent;
        ButtonFunction buttonFunction;
        SoundControl soundControl;

        void Awake()
        {
            buttonFunction = GetComponentInParent<ButtonFunction>();
            soundControl = GetComponentInParent<SoundControl>();
        }


        void Update()
        {
            if (Global.isController)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    soundControl.FocusMoved();
                    transform.Translate(parent.transform.TransformVector(0, parent.transform.InverseTransformPoint(transform.position).y + distance > topY ? bottomY - topY : distance, 0), Space.Self);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    soundControl.FocusMoved();
                    transform.Translate(parent.transform.TransformVector(0, parent.transform.InverseTransformPoint(transform.position).y - distance < bottomY ? topY - bottomY : -distance, 0), Space.Self);
                }
                else if (Input.GetKeyDown(KeyCode.Return))
                {
                    int target = (int)((parent.transform.InverseTransformPoint(transform.position).y - 20) / distance);
                    switch (target)
                    {
                        case 0:
                            buttonFunction.SinglePlay();
                            break;
                        case -1:
                            buttonFunction.MultiPlay();
                            break;
                        case -2:
                            buttonFunction.Option();
                            break;
                        case -3:
                            buttonFunction.Stuff();
                            break;
                        case -4:
                            buttonFunction.Exit();
                            break;
                    }
                }
            }
        }
    }
}