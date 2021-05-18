using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainTitle
{
    public class ButtonControl : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] GameObject arrow;
        MainTitle.SoundControl soundControl;

        void Awake()
        {
            soundControl = GetComponentInParent<SoundControl>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            soundControl.FocusMoved();
            arrow.transform.Translate(0, transform.position.y - arrow.transform.position.y, 0);
        }
    }
}