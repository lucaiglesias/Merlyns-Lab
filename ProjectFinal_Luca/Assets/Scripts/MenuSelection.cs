using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultItem;


    public void PanelToggle(int select)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == select);
            if (i == select)
            {
                defaultItem[i].Select();
            }
        }
    }

    IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
        PanelToggle(0);

    }

}
