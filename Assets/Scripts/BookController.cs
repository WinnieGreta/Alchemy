using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    [Header("Book Pages")]
    public GameObject[] pages;

    [Header("Buttons To Press")]
    [SerializeField]
    private GameObject prevButton;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject closeButton;

    private int pageNum = 0;

    private void ChangePage(int newNum)
    {
        pages[pageNum].SetActive(false);
        pages[newNum].SetActive(true);
        pageNum = newNum;
    }

    private void AdjustBookmarkButtons()
    {
        if(pageNum == 0)
        {
            prevButton.SetActive(false);
        } 
        else if (!prevButton.activeSelf)
        {
            prevButton.SetActive(true);
        }
        
        if (pageNum == pages.Length - 1)
        {
            nextButton.SetActive(false);
        }
        else if (!nextButton.activeSelf)
        {
            nextButton.SetActive(true);
        }
    }

    private void PrevButtonClicked()
    {
        ChangePage(pageNum - 1);
        AdjustBookmarkButtons();
    }
    
    private void NextButtonClicked()
    {
        ChangePage(pageNum + 1);
        AdjustBookmarkButtons();
    }

    private void CloseButtonClicked()
    {
        Debug.Log("Book Closed");
    }

    // Start is called before the first frame update
    void Awake()
    {
        prevButton.GetComponentInChildren<Button>().onClick.AddListener(PrevButtonClicked);
        nextButton.GetComponentInChildren<Button>().onClick.AddListener(NextButtonClicked);
        closeButton.GetComponentInChildren<Button>().onClick.AddListener(CloseButtonClicked);

        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[pageNum].SetActive(true);
        
        AdjustBookmarkButtons();
    }

}
