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
    private Button exitButton;

    public void NewGameButtonClick()
    {
        newGameDialog.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Debug.Log("Me quitting!");
        Application.Quit();
    }

    private void Awake()
    {
        newGameButton.onClick.AddListener(NewGameButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
    }

}
