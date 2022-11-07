using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuTitleReaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.instance.PlaySound("TitleKnock");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
