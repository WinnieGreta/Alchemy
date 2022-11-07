using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabController : MonoBehaviour
{
    [Header("Active Areas")]
    [SerializeField]
    private GameObject bookcase;
    [SerializeField]
    private GameObject table;
    [SerializeField]
    private GameObject cauldron;

    private void BookcaseClicked()
    {
        Debug.Log("Bookcase clicked");
    }

    private void TableClicked()
    {
        Debug.Log("Table clicked");
    }

    private void CauldronClicked()
    {
        Debug.Log("Cauldron clicked");
    }

    void Update()
    {
        
    }
}
