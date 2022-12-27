using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRangeInBuildMode : MonoBehaviour
{
    BuildManager _buildManager;
    [SerializeField] GameObject sphere;

    public static ShowRangeInBuildMode instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one ShowRangeInBuildMode in scene");
        }
        instance = this;
    }

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (!_buildManager.CanBuild) sphere.SetActive(false);
       
    }

    public void SphereToGroundPos(GroundSelector ground)
    {
        sphere.transform.position = ground.GetBuildPos();
    }

    public void showSphere()
    {
        sphere.SetActive(true);

    }
}
