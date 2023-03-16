using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    float vol;
    public Slider slider;
    public AudioMixer audioMixer;

    void Start(){
        audioMixer.GetFloat("volume", out vol);
        slider.value=vol;
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
}
