using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _newGameLevel;
    
    [Header("Dialogs To Open")]
    [SerializeField]
    private GameObject newGameDialog;

    [Header("Buttons To Click")]
    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button continueGameButton;
    [SerializeField]
    private Button exitButton;

    [Header("Has Saved Game")]
    //for now, just to check if there is a game to continue
    [SerializeField]
    private bool gameExists;

    public void NewGameButtonClick()
    {
        AudioManager.instance.PlaySound("ButtonPress");
        GameObject newDialog = Instantiate(newGameDialog, new Vector3(0, 0, 0), Quaternion.identity);
        newDialog.transform.SetParent(GameObject.Find("Popout Dialog Container").transform, false);
        newGameDialog.SetActive(true);
    }

    public void ExitButtonClick()
    {
        AudioManager.instance.PlaySound("ButtonPress");
        Debug.Log("Me quitting!");
        Application.Quit();
    }

    private void Awake()
    {
        newGameButton.onClick.AddListener(NewGameButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
        
        //TODO: make continueGameButton not interactable if there is no save file
        if (!gameExists)
        {
            continueGameButton.interactable = false;
        }
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic("MainMenu");
    }
}
