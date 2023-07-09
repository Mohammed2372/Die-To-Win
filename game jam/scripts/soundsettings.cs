using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class soundsettings : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("mastervolume", Mathf.Log10(sliderValue) * 20);
    }
}