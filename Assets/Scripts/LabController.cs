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

    [Header("Active Areas To Open")]
    [SerializeField]
    private GameObject bookPrefab;

    private void BookcaseClicked()
    {
        Debug.Log("Bookcase clicked from controller");
        //BookcaseScript.objectClicked -= BookcaseClicked;
        AudioManager.instance.PlaySound("BookOpen");
        GameObject openedBook = Instantiate(bookPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        openedBook.transform.SetParent(GameObject.Find("Canvas").transform, false);
        openedBook.transform.SetSiblingIndex(0);
        bookPrefab.SetActive(true);
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
