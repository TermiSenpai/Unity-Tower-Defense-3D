using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    [SerializeField] GameObject cheatBtn;

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_EDITOR || DEVELOPMENT_BUILD
        cheatBtn.SetActive(true);
#endif

    }
}
