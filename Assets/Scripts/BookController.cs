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

    [Header("Table Of Contents")]
    public Button[] tableOfContents;

    public int pageNum;

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
        AudioManager.instance.PlaySound("BookPrev");
        AdjustBookmarkButtons();
    }
    
    private void NextButtonClicked()
    {
        ChangePage(pageNum + 1);
        AudioManager.instance.PlaySound("BookNext");
        AdjustBookmarkButtons();
    }

    private void CloseButtonClicked()
    {
        PlayerPrefs.SetInt("PageNumber", pageNum);
        //Debug.Log("Book Closed");
        AudioManager.instance.PlaySound("BookClose");
        Destroy(transform.parent.gameObject);
    }

    private void TableOfContentsClicked(int i)
    {
        ChangePage(i);
        AudioManager.instance.PlaySound("BookNext");
        AdjustBookmarkButtons();
    }

    // Start is called before the first frame update
    void Awake()
    {
        prevButton.GetComponent<Button>().onClick.AddListener(PrevButtonClicked);
        nextButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);
        closeButton.GetComponent<Button>().onClick.AddListener(CloseButtonClicked);

        for(int i = 0; i < tableOfContents.Length; i++)
        {
            // doesen't work without a copy of a variable inside the loop
            // because clousures duh https://csharpindepth.com/Articles/Closures
            int closureIndex = i;
            tableOfContents[closureIndex].GetComponent<Button>().onClick.AddListener(delegate { TableOfContentsClicked(closureIndex + 1); });
        }

        pageNum = PlayerPrefs.GetInt("PageNumber", 0);

        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[pageNum].SetActive(true);
        
        AdjustBookmarkButtons();
    }

}
