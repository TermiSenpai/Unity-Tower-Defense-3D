using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    public void PlayUISound(AudioClip clip) => source.PlayOneShot(clip);

}
