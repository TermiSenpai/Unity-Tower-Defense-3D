using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public void SetGameSpeed(float speed)
    {
        Time.timeScale = speed;
    }
}
