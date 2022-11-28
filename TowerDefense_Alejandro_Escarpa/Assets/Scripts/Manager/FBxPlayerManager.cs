using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBxPlayerManager : MonoBehaviour
{
    [SerializeField] Transform parent;
    public void ImpactFbxPlay(ParticleSystem fbx, Transform pos)
    {
        Instantiate(fbx, pos.position, Quaternion.identity, parent);
    }
}
