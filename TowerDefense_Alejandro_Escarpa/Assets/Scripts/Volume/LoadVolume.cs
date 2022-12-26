using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadVolume : MonoBehaviour
{
    [SerializeField] VolumeManager[] volumes;
    [SerializeField] Slider[] sliders;

    private void Start()
    {
        for (int i = 0; i < volumes.Length; i++)
        {
            sliders[i].value = PlayerPrefs.GetFloat(volumes[i].mixerName, 1);
        }
    }
}
