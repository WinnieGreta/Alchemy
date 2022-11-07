using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameDiailogController : MonoBehaviour
{
    [Header("New Game Level Scene")]
    public string _newGameLevel;

    [Header("Buttons To Click")]
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

    public void NewGameDialogYes()
    {
        AudioManager.instance.StopMusic("MainMenu");
        AudioManager.instance.PlayMusic("LabAmbience");
        SceneManager.LoadScene(_newGameLevel);
    }

    public void NewGameDialogNo()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void Awake()
    {
        yesButton.onClick.AddListener(NewGameDialogYes);
        noButton.onClick.AddListener(NewGameDialogNo);
    }

}
