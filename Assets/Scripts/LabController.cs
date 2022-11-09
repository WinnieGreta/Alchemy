using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabController : MonoBehaviour
{
    [Header("Active Areas Scripts")]
    [SerializeField]
    private ActiveAreasLightUp BookcaseScript;
    [SerializeField]
    private ActiveAreasLightUp TableScript;
    [SerializeField]
    private ActiveAreasLightUp CauldronScript;

    private void BookcaseClicked()
    {
        Debug.Log("Bookcase clicked from controller");
        //BookcaseScript.objectClicked -= BookcaseClicked;
    }

    public void TableClicked()
    {
        Debug.Log("Table clicked from controller");
        //TableScript.objectClicked -= TableClicked;
    }

    private void CauldronClicked()
    {
        Debug.Log("Cauldron clicked from controller");
        //CauldronScript.objectClicked -= CauldronClicked;
    }

    void Start()
    {
        AudioManager.instance.PlayMusic("LabAmbience");

        //FindObjectOfType<ActiveAreasLightUp>().objectClicked += TableClicked;
        BookcaseScript.objectClicked += BookcaseClicked;
        TableScript.objectClicked += TableClicked;
        CauldronScript.objectClicked += CauldronClicked;
    }
}
