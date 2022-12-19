using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIncreaseHP : MonoBehaviour
{
    public float HPIncreasedPerRound = 1;
    public float multiplyHP;

    public void IncreaseHP()
    {
        HPIncreasedPerRound *= multiplyHP;
    }

    public float GetIncreasedHP()
    {
        return HPIncreasedPerRound;
    }
}
