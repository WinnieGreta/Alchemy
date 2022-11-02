using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsDialogController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField]
    private Text musicVolumeTextValue;
    [SerializeField]
    private Text effectsVolumeTextValue;
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider effectsVolumeSlider;

    [Header("Buttons To Click")]
    [SerializeField]
    private Button applyButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button defaultButton;

    private bool changesMade;

    [Header("Apply Dialog")]
    [SerializeField]
    private GameObject applyDialog;

    //temporary saved volume values before applying changes
    [HideInInspector]
    public float prevEffectVol;
    [HideInInspector]
    public float prevMusicVol;

    private void OptionsBackButton()
    {
        if (changesMade)
        {
            GameObject newDialog = Instantiate(applyDialog, new Vector3(0, 0, 0), Quaternion.identity);
            newDialog.transform.SetParent(GameObject.Find("Popout Dialog Container").transform, false);
            applyDialog.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CloseOptionsDialog()
    {
        changesMade = false;
        Destroy(gameObject);
    }

    private void OptionsDefaultButton()
    {
        SetMusicVolume(0.3f);
        SetEffectsVolume(0.6f);
        SetVolume();
        VolumeApply();
        //after activation stays selected WHY?
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        musicVolumeTextValue.text = (volume * 100).ToString("0");
        AudioManager.instance.MusicVolumeChanged();
        changesMade = true;
    }

    public void SetEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat("EffectsVolume", volume);
        //Debug.Log($"We set {volume}");
        effectsVolumeTextValue.text = (volume * 100).ToString("0");
        AudioManager.instance.EffectVolumeChanged();
        changesMade = true;
    }

    public void VolumeApply()
    {
        prevEffectVol = PlayerPrefs.GetFloat("EffectsVolume");
        prevMusicVol = PlayerPrefs.GetFloat("MusicVolume");
        changesMade = false;
    }

    private void SetVolume()
    {
        //setValueWithoutNotify
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        musicVolumeTextValue.text = (PlayerPrefs.GetFloat("MusicVolume", 0.75f) * 100).ToString("0");
        effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);
        effectsVolumeTextValue.text = (PlayerPrefs.GetFloat("EffectsVolume", 0.75f) * 100).ToString("0");
    }

    private void Awake()
    {
        SetVolume();
        VolumeApply();
        backButton.onClick.AddListener(OptionsBackButton);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);
        applyButton.onClick.AddListener(VolumeApply);
        defaultButton.onClick.AddListener(OptionsDefaultButton);
    }

    private void Update()
    {
        if(!changesMade)
        {
            applyButton.interactable = false;
        }
        else
        {
            applyButton.interactable = true;
        }
    }

}
