using System.Collections;
using System.Collections.Generic;
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

    public void OnMouseEnter()
    {
        //Debug.Log("Enter");
        spriteRenderer.sprite = activeSprite;
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
