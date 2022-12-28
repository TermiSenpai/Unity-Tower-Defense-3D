using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowWaveTxt : MonoBehaviour
{
    public static ShowWaveTxt instance;
    TextMeshProUGUI waveTxt;
    public float debugTime = 0;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("more than 1 showWaveTxt in scene");
        instance = this;
    }

    private void Start()
    {
        waveTxt = GetComponent<TextMeshProUGUI>();
        Color color = waveTxt.color;

        color.a = 0f;
        waveTxt.color = color;
    }

    public IEnumerator OnStartWaveBtnPressed()
    {
        Color color = waveTxt.color;

        while (waveTxt.color.a < 1f)
        {
            color.a += 0.1f;
            waveTxt.color = color;
            debugTime += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        debugTime= 0f;

        while(waveTxt.color.a > 0f)
        {
            color.a -= 0.1f;
            waveTxt.color = color;
            debugTime += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
