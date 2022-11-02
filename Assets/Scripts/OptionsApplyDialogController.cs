using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsApplyDialogController : MonoBehaviour
{
    [Header("Buttons To Click")]
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

    [Header("Parent Options Dialog")]
    [SerializeField]
    private GameObject optionsMainDialog;
    private OptionsDialogController opt;

    public void OptionsApplyDialogNo() 
    {
        opt = FindObjectOfType<OptionsDialogController>();
        opt.SetMusicVolume(opt.prevMusicVol);
        opt.SetEffectsVolume(opt.prevEffectVol);
        opt.CloseOptionsDialog();
        Destroy(gameObject);
    }

    public void OptionsApplyDialogYes()
    {
        opt = FindObjectOfType<OptionsDialogController>();
        opt.VolumeApply();
        opt.CloseOptionsDialog();
        Destroy(gameObject);
    }

    private void Awake()
    {
        noButton.onClick.AddListener(OptionsApplyDialogNo);
        yesButton.onClick.AddListener(OptionsApplyDialogYes);
    }
}
