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

    private bool spriteActive;

    public void OnMouseEnter()
    {
        if (!IsMouseOverUI())
        {
            ChangeToActive();
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            if(objectClicked != null)
            {
                objectClicked();
            }
        }

        if(!IsMouseOverUI() && !spriteActive)
        {
            ChangeToActive();
        }

        if(IsMouseOverUI() && spriteActive)
        {
            ChangeToPassive();
        }
    }

    public void OnMouseExit()
    {
        ChangeToPassive();
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void ChangeToActive()
    {
        spriteRenderer.sprite = activeSprite;
        spriteActive = true;
    }

    private void ChangeToPassive()
    {
        spriteRenderer.sprite = passiveSprite;
        spriteActive = false;
    }
    
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
