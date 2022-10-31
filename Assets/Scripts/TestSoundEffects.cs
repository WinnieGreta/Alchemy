using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestSoundEffects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //to test volume of sound effects after it had been changed
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.instance.PlaySound("SoundCheck");
    }
}
