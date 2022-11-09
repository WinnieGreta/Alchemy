using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabController : MonoBehaviour
{
    [Header("Active Areas Scripts")]
    [SerializeField]
    private ActiveAreasLightUp bookcaseScript;
    [SerializeField]
    private ActiveAreasLightUp tableScript;
    [SerializeField]
    private ActiveAreasLightUp cauldronScript;

    private void BookcaseClicked()
    {
        Debug.Log("Bookcase clicked from controller");
    }

    public void TableClicked()
    {
        Debug.Log("Table clicked from controller");
        //FindObjectOfType<ActiveAreasLightUp>().objectClicked -= TableClicked;
    }

    private void CauldronClicked()
    {
        Debug.Log("Cauldron clicked from controller");
    }

    void Start()
    {
        //FindObjectOfType<ActiveAreasLightUp>().objectClicked += TableClicked;
        bookcaseScript.objectClicked += BookcaseClicked;
        tableScript.objectClicked += TableClicked;
        cauldronScript.objectClicked += CauldronClicked;
    }
}
