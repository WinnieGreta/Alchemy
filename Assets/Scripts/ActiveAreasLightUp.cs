using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveAreasLightUp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Sprites To Change")]
    [SerializeField]
    private Sprite passiveSprite;
    [SerializeField]
    private Sprite activeSprite;

    public event Action objectClicked;

    public void OnMouseEnter()
    {
        //Debug.Log("Enter");
        spriteRenderer.sprite = activeSprite;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(name + " clicked");
            if(objectClicked != null)
            {
                objectClicked();
            }
        }
    }

    public void OnMouseExit()
    {
        //Debug.Log("Exit");
        spriteRenderer.sprite = passiveSprite;
    }
    
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
