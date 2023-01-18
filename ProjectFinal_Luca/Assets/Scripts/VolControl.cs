using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private string nameParam;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        float vol = PlayerPrefs.GetFloat(nameParam, 0.3f);
        slider.value = vol;
        audioM.SetFloat(nameParam, Mathf.Log10(vol) * 30f);

    }

    public void SetVolume(float vol)
    {
        audioM.SetFloat(nameParam, Mathf.Log10(vol) * 30f);
        PlayerPrefs.SetFloat(nameParam, vol);

    }
}
