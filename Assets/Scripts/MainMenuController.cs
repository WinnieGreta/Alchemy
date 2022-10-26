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
        GameObject newDialog = Instantiate(newGameDialog, new Vector3(0, 0, 0), Quaternion.identity);
        newDialog.transform.SetParent(GameObject.Find("Popout Dialog Container").transform, false);
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
