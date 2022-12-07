using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayLoader : MonoBehaviour
{


    public void LoadGameplay()
    {
        SceneManager.LoadScene("ForestLevel");
    }

}