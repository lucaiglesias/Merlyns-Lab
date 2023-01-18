using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    private Dropdown dropdown;
    private Resolution[] ResNames;


    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        ResNames = Screen.resolutions;
        List<string> dropOptions = new List<string>();
        int i = 0;
        int pos = 0;
        Resolution currentRes = Screen.currentResolution;
        foreach (Resolution r in ResNames)
        {
            string val = r.ToString();
            dropOptions.Add(val);
            if (r.width == currentRes.width &&
                r.height == currentRes.height &&
                r.refreshRate == currentRes.refreshRate)
            {
                pos = i;
            }
            i++;
        }
        dropdown.AddOptions(dropOptions);
        dropdown.value = pos;

    }

    public void SetRes()
    {
        Resolution res = ResNames[dropdown.value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode, res.refreshRate);

    }
}

