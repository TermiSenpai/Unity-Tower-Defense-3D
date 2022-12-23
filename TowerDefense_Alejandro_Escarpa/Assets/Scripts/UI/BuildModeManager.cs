using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    BuildManager buildManager;
    [SerializeField] GameObject buildsystem;


    private void Start()
    {
        buildManager = BuildManager.instance;
        StartCoroutine(IBuildUIUpdate());
    }

    private IEnumerator IBuildUIUpdate()
    {
        while (true)
        {
            switch (buildManager.CanBuild)
            {
                case true:
                    buildsystem.SetActive(true);
                    break;
                case false:
                    buildsystem.SetActive(false);
                    break;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
