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

    private void OptionsBackButton()
    {
        Destroy(gameObject);
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
        //PlayerPrefs.SetFloat("MusicVolume", AudioListener.volume);
        //PlayerPrefs.SetFloat("EffectsVolume", AudioListener.volume);
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
        backButton.onClick.AddListener(OptionsBackButton);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

}
