using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuButtonsTouch : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("The cursor entered UI element.");
        if (GetComponent<Button>().interactable)
        {
            AudioManager.instance.PlaySound("ButtonTouch");
            //Debug.Log("Active button touch");
        } 
        else
        {
            Debug.Log("Not active button touched");
        }
    }
}
