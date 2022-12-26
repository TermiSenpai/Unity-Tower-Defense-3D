using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;
    public string mixerName;


    public void setVolume(float sliderValue)
    {
        mixer.SetFloat(mixerName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(mixerName, sliderValue);
    }
}
