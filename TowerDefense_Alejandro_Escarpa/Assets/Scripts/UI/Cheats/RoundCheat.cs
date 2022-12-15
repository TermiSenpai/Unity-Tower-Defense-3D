using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCheat : MonoBehaviour
{
    [SerializeField] EnemyWaveSpawner wave;

    public void changeRound(int value)
    {
        wave.ChangeRound(value);
        wave.changeRoundTxt();
    }
}
