using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonClose : MonoBehaviour
{
    private void ClickOnPanel()
    {
        GameObject parent = transform.parent.gameObject;
        BookController controller = parent.GetComponentInChildren<BookController>();
        
        PlayerPrefs.SetInt("PageNumber", controller.pageNum);
        Debug.Log("Panel Clicked");
        Destroy(transform.parent.gameObject);
    }

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ClickOnPanel);
    }

}
