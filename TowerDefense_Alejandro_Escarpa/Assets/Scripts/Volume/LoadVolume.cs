using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadVolume : MonoBehaviour
{
    [SerializeField] VolumeManager[] volumes;

    private void Start()
    {
        for (int i = 0; i < volumes.Length; i++)
        {
            volumes[i].slider.value = PlayerPrefs.GetFloat(volumes[i].mixerName, 1);
        }
    }
}
