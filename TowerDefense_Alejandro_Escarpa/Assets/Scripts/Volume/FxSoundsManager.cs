using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSoundsManager : MonoBehaviour
{
    public static FxSoundsManager instance;
    [SerializeField] private AudioSource source;
    [SerializeField] AudioClip defaultBuildClip;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one FxSoundsManager in scene");
        }
        instance = this;
    }

    public void PlayFx(AudioClip clip) => source.PlayOneShot(clip);
    public void PlayDefaultBuildClip() => source.PlayOneShot(defaultBuildClip);
}
